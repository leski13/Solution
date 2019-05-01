﻿using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ClassLibrary.Controller
{
    public abstract class ControllerBase
    {
        protected void Save(string filename, object item)
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }
        protected T Load<T>(string filename)
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                if(fs.Length>0 && formatter.Deserialize(fs) is T items)
                {
                    return items;
                }
                else
                {
                    return default(T);
                }
            }
        }
    }
}
