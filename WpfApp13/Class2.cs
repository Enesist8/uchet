using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp13
{
    internal class Class2
    {
        public static void MySerialize<T>(T notes, string name_file)
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string json = JsonConvert.SerializeObject(notes);
            File.WriteAllText(desktop + "\\" + name_file ,json);
        }
        public static T DeserializeObject<T>()
        {
            OpenFileDialog im = new OpenFileDialog();
            im.Filter = "json files (*.json)|*.json";
            if (im.ShowDialog() == true)
            {
                string json = File.ReadAllText(im.FileName);
                T obj = JsonConvert.DeserializeObject<T>(json);
                return obj;
            }
            else
            {
                return default(T);
            }
        }
    }
}
