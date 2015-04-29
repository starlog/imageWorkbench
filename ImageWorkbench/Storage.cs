using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ImageProcessor;
using Newtonsoft.Json;

namespace ImageWorkbench
{
    public class imageSetup
    {
        public string Postfix { get; set; }
        public string SizeX { get; set; }
        public string SizeY { get; set; }
        public int Quality { get; set; }
    }

    public class TargetImage
    {
        public Image Image { get; set; }
        public string FileName { get; set; }
    }
    public static class WorkImage
    {
        public static Image OriginalImage { get; set; }
        public static string OriginalFileName { get; set; }
        public static byte[] OriginalImageBytes { get; set; }
        public static List<TargetImage> ConvertedImages { get; set; }

        public static string ImageFolderName { get; set; }

        static WorkImage()
        {
            ConvertedImages = new List<TargetImage>();
            ImageFolderName = @".\images";
        }
    }

    public static class Storage
    {
        public static string FtpAddress { get; set; }
        public static string AccountId { get; set; }
        public static string AccountPassword { get; set; }
        public static string BasePath { get; set; }
        public static BindingList<imageSetup> ImageSetups { get; set; }

        static Storage()
        {
            ImageSetups = new BindingList<imageSetup>();
        }
    }

    public class StorageTemp
    {
        public string FtpAddress { get; set; }
        public string AccountId { get; set; }
        public string AccountPassword { get; set; }
        public string BasePath { get; set; }
        public List<imageSetup> ImageSetups { get; set; }
    }



    public static class ConfigSaver
    {
        private static readonly string filename = @".\ImageWorkbench.cfg";

        public static bool Load()
        {
            return Load(filename);
        }

        public static bool Save()
        {
            return Save(filename);
        }

        public static bool Load(string filename)
        {
            try
            {
                string data = File.ReadAllText(filename);

                var xx = JsonConvert.DeserializeObject<StorageTemp>(data);

                Storage.AccountId = xx.AccountId;
                Storage.AccountPassword = StringCipher.Decrypt(xx.AccountPassword, StringCipher.PassPhrase);
                Storage.BasePath = xx.BasePath;
                Storage.FtpAddress = xx.FtpAddress;
                Storage.ImageSetups = new BindingList<imageSetup>();

                foreach (var record in xx.ImageSetups)
                {
                    var imageEntry = new imageSetup
                    {
                        Postfix = record.Postfix,
                        SizeX = record.SizeX,
                        SizeY = record.SizeY,
                        Quality = record.Quality
                    };

                    Storage.ImageSetups.Add(imageEntry);
                }

            }
            catch (Exception)
            {
                MessageBox.Show(@"ImageWorkbench.cfg 파일 오류");
            }
            return true;
        }

        public static bool Save(string filename)
        {

            var xx = new StorageTemp
            {
                AccountId = Storage.AccountId,
                AccountPassword = StringCipher.Encrypt(Storage.AccountPassword, StringCipher.PassPhrase),
                BasePath = Storage.BasePath,
                FtpAddress = Storage.FtpAddress,
                ImageSetups = new List<imageSetup>()
            };

            if (Storage.ImageSetups != null)
            {
                foreach (var record in Storage.ImageSetups)
                {
                    var entry = new imageSetup
                    {
                        Postfix = record.Postfix,
                        SizeX = record.SizeX,
                        SizeY = record.SizeY,
                        Quality = record.Quality
                    };

                    xx.ImageSetups.Add(entry);
                }
            }

            var data = JsonConvert.SerializeObject(xx);

            File.WriteAllText(filename,data);

            return true;
        }
    }
}
