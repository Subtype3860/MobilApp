using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MobilApp.Models
{
    public class InfoImage : INotifyPropertyChanged
    {
        private string _file;
        private string _path;
        private DateTime _date;

        public InfoImage(string file, string path, DateTime date)
        {
            _file = file;
            _path = path;
            _date = date;
        }

        public string NameFile
        {
            get { return _file; }
            set
            {
                if (_file != value)
                {
                    _file = value;
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
            get { return _date; }
            set
            {
                if (_date != value)
                {
                    _date = value;
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
