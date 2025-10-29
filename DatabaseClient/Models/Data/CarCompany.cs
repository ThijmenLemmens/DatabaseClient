using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DatabaseClient.Models.Data
{
    internal class CarCompany
    {

        private int _id;

        private int _fkHeadquaters;
        
        private string _name;

        private byte[]? _logoData;

        public int ID
        {
            get => _id;
            set => _id = value;
        }

        public int FkHeadquaters
        {
            get => _fkHeadquaters;
            set => _fkHeadquaters = value;
        }

        public string Name
        {
            get => _name;
            set {

                if (_name != value)
                {
                    _name = value;
                }
            }
        }

        public byte[] LogoData
        {
            get => _logoData;
        }

        public ImageSource? Logo
        {
            set {
                
                // Setting the images

            }
            get {

                return null;

                if (_logoData == null || _logoData.Length == 0)
                    return null;

                using MemoryStream memoryStream = new(_logoData);
                BitmapImage image = new();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = memoryStream;
                image.EndInit();
                image.Freeze();
                return image;
            }
        }

        public CarCompany(int fkHeadquaters, string name, byte[] logoData)
        {
            _fkHeadquaters = fkHeadquaters;
            _name = name;
            _logoData = logoData;
        }

        public CarCompany(int id, int fkHeadquaters, string name, byte[] logoData)
        {
            _id = id;
            _fkHeadquaters = fkHeadquaters;
            _name = name;
            _logoData = logoData;
        }
    }
}
