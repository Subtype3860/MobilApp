using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MobilApp.Models
{
    public class InfoImage : INotifyPropertyChanged
    {
        private string _nameFile;
        private string _path;
        private DateTime _createDate;

        public InfoImage(string nameFile, string pathToPicture, DateTime createDate)
        {
            _nameFile = nameFile;
            _path = pathToPicture;
            _createDate = createDate;
        }

        public string NameFile
        {
            get { return _nameFile; }
            set
            {
                if (_nameFile != value)
                {
                    _nameFile = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string PathToPicture
        {
            get { return _path; }
            set
            {
                if (_path != value)
                {
                    _path = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public DateTime CreateDate
        {
            get { return _createDate; }
            set
            {
                if (_createDate != value)
                {
                    _createDate = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
