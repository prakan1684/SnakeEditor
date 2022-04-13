﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace SnakeLauncher.Utilities
{
    public static class Serializer
    {

        public static void ToFile<T>(T instance, string path)
        {

            try
            {
                using var fs = new FileStream(path, FileMode.Create);
                var serializer = new DataContractSerializer(typeof(T));
                serializer.WriteObject(fs, instance);
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
                // FIX LOG ERROR
            }

        }

        internal static T FromFile<T>(string path)
        {
            try
            {
                using var fs = new FileStream(path, FileMode.Open);
                var serializer = new DataContractSerializer(typeof(T));
                T instance = (T)serializer.ReadObject(fs);
                return instance;
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
                return default(T);
                // FIX LOG ERROR
            }
        }
    }
}
