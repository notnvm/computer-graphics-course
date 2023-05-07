using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace tomogramm_Smolin
{
    internal class GLgraphics
    {
        public List<int> tex_ids = new List<int>();

        Vector3 camera_pos = new Vector3(-200, 100, 400);
        Vector3 camera_dir = new Vector3(0, 0, 0);
        Vector3 camera_up = new Vector3(0, 0, 1);

        public float latitude = 47.98f;
        public float longitude = 60.41f;
        public float radius = 5.385f;
        public float rotate_angle = 0f;
        public float speed = 0.001f;
        public float radius_move = 3f;

        public int load_texture(String path)
        {
            try
            {
                Bitmap img = new Bitmap(path);
                int tex_id = GL.GenTexture();
                GL.BindTexture(TextureTarget.Texture2D, tex_id);
                BitmapData data = img.LockBits(
                    new System.Drawing.Rectangle(0, 0, img.Width, img.Height),
                    ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                    OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
                img.UnlockBits(data);
                GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
                return tex_id;
            }
            catch (System.IO.FileNotFoundException e)
            {
                return -1;
            }
        }
        public void resize(int width, int height)
        {
            GL.ClearColor(Color.DarkGray);
            GL.ShadeModel(ShadingModel.Smooth);
            GL.Enable(EnableCap.DepthTest);
            setup_lightning();

            Matrix4 perspective_mat = Matrix4.CreatePerspectiveFieldOfView(
                MathHelper.PiOver4,
                width / (float)height,
                1,
                64);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective_mat);
        }
        public void update()
        {
            camera_pos = new Vector3(
                (float)(radius * Math.Cos(Math.PI / 180.0f * latitude) * Math.Cos(Math.PI / 180.0f * longitude)),
                (float)(radius * Math.Cos(Math.PI / 180.0f * latitude) * Math.Sin(Math.PI / 180.0f * longitude)),
                (float)(radius * Math.Sin(Math.PI / 180.0f * latitude))
                );

            rotate_angle += speed;

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            Matrix4 view_mat = Matrix4.LookAt(camera_pos, camera_dir, camera_up);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref view_mat);
            render();
        }

        private void draw_quad()
        {
            GL.Begin(PrimitiveType.Quads);

            GL.Color3(Color.Blue);
            GL.Vertex3(-1.0f, -1.0f, -1.0f);

            GL.Color3(Color.Red);
            GL.Vertex3(-1.0f, 1.0f, -1.0f);

            GL.Color3(Color.White);
            GL.Vertex3(1.0f, 1.0f, -1.0f);

            GL.Color3(Color.Green);
            GL.Vertex3(1.0f, -1.0f, -1.0f);

            GL.End();
        }

        private void draw_texture_quad()
        {
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, tex_ids[0]);

            GL.Begin(PrimitiveType.Quads);

            GL.Color3(Color.Blue);
            GL.TexCoord2(0.0, 0.0);
            GL.Vertex3(-1.0f, -1.0f, -1.0f);

            GL.Color3(Color.Red);
            GL.TexCoord2(0.0, 1.0);
            GL.Vertex3(-1.0f, 1.0f, -1.0f);

            GL.Color3(Color.White);
            GL.TexCoord2(1.0, 1.0);
            GL.Vertex3(1.0f, 1.0f, -1.0f);

            GL.Color3(Color.Green);
            GL.TexCoord2(1.0, 0.0);
            GL.Vertex3(1.0f, -1.0f, -1.0f);

            GL.End();
        }

        private void draw_sphere(double r, int nx, int ny)
        {
            int ix, iy;
            double x, y, z;
            for (iy = 0; iy < ny; ++iy)
            {
                GL.Begin(BeginMode.QuadStrip);
                for(ix = 0; ix <= nx; ++ix)
                {
                    x = r * Math.Sin(iy * Math.PI / ny) * Math.Cos(2 * ix * Math.PI / nx);
                    y = r * Math.Sin(iy * Math.PI / ny) * Math.Sin(2 * ix * Math.PI / nx);
                    z = r * Math.Cos(iy * Math.PI / ny);
                    GL.Normal3(x, y, z);
                    GL.Vertex3(x, y, z);

                    x = r * Math.Sin((iy + 1) * Math.PI / ny) * Math.Cos(2 * ix * Math.PI / nx);
                    y = r * Math.Sin((iy + 1) * Math.PI / ny) * Math.Sin(2 * ix * Math.PI / nx);
                    z = r * Math.Cos((iy + 1) * Math.PI / ny);
                    GL.Normal3(x, y, z);
                    GL.Vertex3(x, y, z);
                }
                GL.End();
            }
        }

        private void draw_point()
        {
            GL.PointSize(10f);
            GL.Begin(PrimitiveType.Points);

            GL.Vertex2(1.0f, 1.0f);
            GL.Color3(Color.PowderBlue);
            GL.End();
        }

        private void draw_line()
        {
            GL.LineWidth(5);
            GL.Begin(PrimitiveType.LineLoop);

            GL.Color3(Color.Blue);
            GL.Vertex2(1.0f, 1.0f);

            GL.Color3(Color.Orange);
            GL.Vertex2(2.0f, 2.0f);

            GL.Color3(Color.Yellow);
            GL.Vertex2(3, 1);

            GL.Color3(Color.Green);
            GL.Vertex2(2, 0);

            GL.End();
        }

        private void draw_triangle()
        {
            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(Color.Red);
            GL.Vertex2(-1.0f, -1.0f);

            GL.Color3(Color.Green);
            GL.Vertex2(2f, 2f);

            GL.Color3(Color.Blue);
            GL.Vertex2(4f, -1f);

            GL.End();

        }

        private void draw_triangle_strip()
        {
            GL.Begin(PrimitiveType.TriangleStrip);

            GL.Color3(Color.Red);
            GL.Vertex2(-1.0f, -1.0f);

            GL.Color3(Color.Green);
            GL.Vertex2(2f, 2f);

            GL.Color3(Color.Blue);
            GL.Vertex2(4f, -1f);

            GL.Color3(Color.Yellow);
            GL.Vertex3(3f, 3f, 3f);

            GL.End();
        }

        private void draw_triangle_fan()
        {
            GL.Begin(PrimitiveType.TriangleFan);

            GL.Color3(Color.Red);
            GL.Vertex2(-1.0f, -1.0f);

            GL.Color3(Color.Green);
            GL.Vertex2(2f, 2f);

            GL.Color3(Color.Blue);
            GL.Vertex2(4f, -1f);

            GL.Color3(Color.Yellow);
            GL.Vertex3(3f, 3f, 3f);

            GL.End();
        }

        private void draw_texture_cube()
        {
            GL.Enable(EnableCap.Texture2D);

            GL.BindTexture(TextureTarget.Texture2D, tex_ids[0]);
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(Color.White);
            GL.TexCoord2(0.0, 0.0);
            GL.Vertex3(0, 0, 0f);

            GL.Color3(Color.White);
            GL.TexCoord2(0.0, 1.0);
            GL.Vertex3(2, 0, 0f);

            GL.Color3(Color.White);
            GL.TexCoord2(1.0, 1.0);
            GL.Vertex3(2, 2, 0f);

            GL.Color3(Color.White);
            GL.TexCoord2(1.0, 0.0);
            GL.Vertex3(0, 2, 0f);
            GL.End();

            GL.BindTexture(TextureTarget.Texture2D, tex_ids[1]);
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(Color.White);
            GL.TexCoord2(0.0, 0.0);
            GL.Vertex3(0, 0, 2f);

            GL.Color3(Color.White);
            GL.TexCoord2(0.0, 1.0);
            GL.Vertex3(0, 0, 0f);

            GL.Color3(Color.White);
            GL.TexCoord2(1.0, 1.0);
            GL.Vertex3(0, 2, 0f);

            GL.Color3(Color.White);
            GL.TexCoord2(1.0, 0.0);
            GL.Vertex3(0, 2, 2f);
            GL.End();

            GL.BindTexture(TextureTarget.Texture2D, tex_ids[2]);
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(Color.White);
            GL.TexCoord2(0.0, 0.0);
            GL.Vertex3(0, 2, 2f);

            GL.Color3(Color.White);
            GL.TexCoord2(0.0, 1.0);
            GL.Vertex3(0, 0, 2f);

            GL.Color3(Color.White);
            GL.TexCoord2(1.0, 1.0);
            GL.Vertex3(2, 0, 2f);

            GL.Color3(Color.White);
            GL.TexCoord2(1.0, 0.0);
            GL.Vertex3(2, 2, 2f);
            GL.End();

            GL.BindTexture(TextureTarget.Texture2D, tex_ids[3]);
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(Color.White);
            GL.TexCoord2(0.0, 0.0);
            GL.Vertex3(2, 2, 2f);

            GL.Color3(Color.White);
            GL.TexCoord2(0.0, 1.0);
            GL.Vertex3(2, 2, 0f);

            GL.Color3(Color.White);
            GL.TexCoord2(1.0, 1.0);
            GL.Vertex3(2, 0, 0f);

            GL.Color3(Color.White);
            GL.TexCoord2(1.0, 0.0);
            GL.Vertex3(2, 0, 2f);
            GL.End();

            GL.BindTexture(TextureTarget.Texture2D, tex_ids[4]);
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(Color.White);
            GL.TexCoord2(0.0, 0.0);
            GL.Vertex3(0, 2, 2f);

            GL.Color3(Color.White);
            GL.TexCoord2(0.0, 1.0);
            GL.Vertex3(0, 2, 0f);

            GL.Color3(Color.White);
            GL.TexCoord2(1.0, 1.0);
            GL.Vertex3(2, 2, 0f);

            GL.Color3(Color.White);
            GL.TexCoord2(1.0, 0.0);
            GL.Vertex3(2, 2, 2f);
            GL.End();

            GL.BindTexture(TextureTarget.Texture2D, tex_ids[5]);
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(Color.White);
            GL.TexCoord2(0.0, 0.0);
            GL.Vertex3(0, 0, 2f);

            GL.Color3(Color.White);
            GL.TexCoord2(0.0, 1.0);
            GL.Vertex3(0, 0, 0f);

            GL.Color3(Color.White);
            GL.TexCoord2(1.0, 1.0);
            GL.Vertex3(2, 0, 0f);

            GL.Color3(Color.White);
            GL.TexCoord2(1.0, 0.0);
            GL.Vertex3(2, 0, 2f);
            GL.End();

            GL.Disable(EnableCap.Texture2D);
        }

        public void render()
        {
            // 1
            //GL.Color3(Color.BlueViolet);
            //draw_sphere(1.0f, 20, 20);

            // 2
            //draw_texture_quad();

            // 3
            //draw_point();

            // 4
            //draw_line();

            // 5
            //draw_triangle();

            // 6
            //draw_triangle_strip();

            // 7
            //draw_triangle_fan();

            // 8
            //draw_texture_cube();

            // 9
            GL.PushMatrix();
            GL.Translate(radius_move * Math.Cos(rotate_angle), radius_move * Math.Sin(rotate_angle), 0);
            draw_texture_cube();
            GL.PopMatrix();

            //rotate

            //draw_quad();

            //GL.PushMatrix();
            //GL.Translate(1, 1, 1);
            //GL.Rotate(rotate_angle, Vector3.UnitZ);
            //GL.Scale(0.5f, 0.5f, 0.5f);

            //draw_quad();
            //GL.PopMatrix();
        }

        private void setup_lightning()
        {
            setup_lightning0();
            setup_lightning1();
        }

        private void setup_lightning0()
        {
            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.Light0);
            GL.Enable(EnableCap.ColorMaterial);

            Vector4 light_pos = new Vector4(1.0f, 1.0f, 4.0f, 0.0f);
            GL.Light(LightName.Light0, LightParameter.Ambient, light_pos);

            Vector4 ambient_color = new Vector4(0.2f, 0.2f, 0.2f, 1.0f);
            GL.Light(LightName.Light0, LightParameter.Ambient, ambient_color);

            Vector4 diffuse_color = new Vector4(0.6f, 0.6f, 0.6f, 1.0f);
            GL.Light(LightName.Light0, LightParameter.Ambient, diffuse_color);

            Vector4 material_specular = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
            GL.Material(MaterialFace.Front, MaterialParameter.Specular, material_specular);

            float material_shininess = 100;
            GL.Material(MaterialFace.Front, MaterialParameter.Shininess, material_shininess);
        }

        private void setup_lightning1()
        {
            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.Light1);
            GL.Enable(EnableCap.ColorMaterial);

            Vector4 lightPosition = new Vector4(7.0f, 7.0f, 1.0f, 0.0f);
            GL.Light(LightName.Light1, LightParameter.Position, lightPosition);

            Vector4 ambientColor = new Vector4(25f, 15f, 240f, 1.0f);
            GL.Light(LightName.Light1, LightParameter.Ambient, ambientColor);

            Vector4 diffuseColor = new Vector4(0.7f, 0.7f, 0.7f, 1.0f);
            GL.Light(LightName.Light1, LightParameter.Diffuse, diffuseColor);

            Vector4 materialSpecular = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
            GL.Material(MaterialFace.Front, MaterialParameter.Specular, materialSpecular);
            float materialShininess = 100;
            GL.Material(MaterialFace.Front, MaterialParameter.Shininess, materialShininess);
        }

    }
}
