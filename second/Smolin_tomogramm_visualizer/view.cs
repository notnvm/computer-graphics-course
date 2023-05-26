using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using OpenTK;
using OpenTK.Graphics.OpenGL;


namespace Smolin_tomogramm_visualizer
{
    internal class view
    {
        int VBO_texture;
        Bitmap texture_img;

        public void load_2D_texture()
        {
            GL.BindTexture(TextureTarget.Texture2D, VBO_texture);
            BitmapData data = texture_img.LockBits(
                new System.Drawing.Rectangle(0, 0, texture_img.Width, texture_img.Height),
                ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba,
                data.Width, data.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra,
                PixelType.UnsignedByte, data.Scan0);

            texture_img.UnlockBits(data);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter,
                (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter,
                (int)TextureMagFilter.Linear);

            ErrorCode er = GL.GetError();
            string str = er.ToString();
        }

        public void generate_texture_image(int layer_number)
        {
            texture_img = new Bitmap(bin_read.X, bin_read.Y);
            for (int i = 0; i < bin_read.X; ++i)
                for(int j = 0; j < bin_read.Y; ++j)
                {
                    int pxl_number = i + j * bin_read.X + layer_number * bin_read.X * bin_read.Y;
                    texture_img.SetPixel(i, j, transfer_function(bin_read.array[pxl_number]));
                }
        }

        public void draw_texture()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, VBO_texture);

            GL.Begin(BeginMode.Quads);
            GL.Color3(Color.White);
            GL.TexCoord2(0f, 0f);
            GL.Vertex2(0, 0);
            GL.TexCoord2(0f, 1f);
            GL.Vertex2(0, bin_read.Y);
            GL.TexCoord2(1f, 1f);
            GL.Vertex2(bin_read.X, bin_read.Y);
            GL.TexCoord2(1f, 0f);
            GL.Vertex2(bin_read.X, 0);
            GL.End();

            GL.Disable(EnableCap.Texture2D);
        }

        public void setup_view(int width, int height)
        {
            GL.ShadeModel(ShadingModel.Smooth);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, bin_read.X, 0, bin_read.Y, -1, 1);
            GL.Viewport(0, 0, width, height);
        }

        private int clamp(int value, int min, int max)
        {
            if (value < min)
            {
                return min;
            }
            else if (value > max)
            {
                return max;
            }
            return value;
        }

        Color transfer_function(short value)
        {
            int min = 0;
            int max = 2000;
            int new_val = clamp((value - min) * 255 / (max - min), 0, 255);
            return Color.FromArgb(255, new_val, new_val, new_val);
        }

        public void draw_quads(int layer_num, bool flag)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Begin(BeginMode.Quads);
            for(int x_coord = 0; x_coord < bin_read.X - 1; ++x_coord)
                for(int y_coord = 0; y_coord < bin_read.Y - 1; ++y_coord)
                {
                    short value;
                    if (flag == false)
                    {
                        // 1 вершина
                        value = bin_read.array[x_coord + y_coord * bin_read.X
                            + layer_num * bin_read.X * bin_read.Y];
                        GL.Color3(transfer_function(value));
                        GL.Vertex2(x_coord, y_coord);

                        // 2 вершина
                        value = bin_read.array[x_coord + (y_coord + 1) * bin_read.X
                            + layer_num * bin_read.X * bin_read.Y];
                        GL.Color3(transfer_function(value));
                        GL.Vertex2(x_coord, y_coord + 1);

                        // 3 вершина
                        value = bin_read.array[x_coord + 1 + (y_coord + 1) * bin_read.X
                                                + layer_num * bin_read.X * bin_read.Y];
                        GL.Color3(transfer_function(value));
                        GL.Vertex2(x_coord + 1, y_coord + 1);

                        // 4 вершина
                        value = bin_read.array[x_coord + 1 + y_coord * bin_read.X
                                                + layer_num * bin_read.X * bin_read.Y];
                        GL.Color3(transfer_function(value));
                        GL.Vertex2(x_coord + 1, y_coord);
                    }
                    else
                    {
                        //1 вершина 
                        value = bin_read.array[x_coord + y_coord * bin_read.X
                            + layer_num * bin_read.X * bin_read.Y];
                        GL.Color3(transfer_function(value));//установка текущего цвета
                                                           //GL.Vertex2(x_coord, y_coord);//указать вершину
                        GL.Vertex2(x_coord, bin_read.Y - y_coord - 1);
                        //2 вершина
                        value = bin_read.array[x_coord + (y_coord + 1) * bin_read.X
                            + layer_num * bin_read.X * bin_read.Y];
                        GL.Color3(transfer_function(value));
                        //GL.Vertex2(x_coord, y_coord + 1);
                        GL.Vertex2(x_coord, bin_read.Y - y_coord);
                        //3 вершина
                        value = bin_read.array[x_coord + 1 + (y_coord + 1) * bin_read.X
                            + layer_num * bin_read.X * bin_read.Y];
                        GL.Color3(transfer_function(value));
                        //GL.Vertex2(x_coord + 1, y_coord + 1);
                        GL.Vertex2(x_coord + 1, bin_read.Y - y_coord);
                        //4 вершина 
                        value = bin_read.array[x_coord + 1 + y_coord * bin_read.X
                            + layer_num * bin_read.X * bin_read.Y];
                        GL.Color3(transfer_function(value));
                        //GL.Vertex2(x_coord + 1, y_coord);
                        GL.Vertex2(x_coord + 1, bin_read.Y - y_coord - 1);
                    }

                }
            GL.End();
        }
    }
}
