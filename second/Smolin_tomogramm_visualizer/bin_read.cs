﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Smolin_tomogramm_visualizer
{
    internal class bin_read
    {
        public static int X, Y, Z;
        public static short[] array;
        public bin_read() { }

        public void read_bin(string path)
        {
            if (File.Exists(path))
            {
                BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open));
                X = reader.ReadInt32();
                Y = reader.ReadInt32();
                Z = reader.ReadInt32();

                int arr_size = X * Y * Z;
                array = new short[arr_size];
                for (int i = 0; i < arr_size; ++i)
                    array[i] = reader.ReadInt16();
            }
        }

        public int layer_size()
        {
            return Z;
        }
    }
}
