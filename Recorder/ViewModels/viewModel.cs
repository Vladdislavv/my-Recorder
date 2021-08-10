using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.IO;
using Recorder.models;
using System.ComponentModel;

namespace Recorder.ViewModels
{
    class ViewModel : INotifyPropertyChanged
    {
        private Record record = new();

        private bool isRecord = false;
        private string _path;
        public string path
        {
            get
            {
                return _path;
            }
            set
            {
                _path = value;
                OnPropertyChanged(nameof(path));
            }
        }
        private string _nameOfFile;
        public string NameOfFile
        {
            get
            {
                return _nameOfFile;
            }
            set
            {
                _nameOfFile = value;
                OnPropertyChanged(nameof(NameOfFile));
            }
        }

        public ICommand StartRecord
        {
            get
            {
                return new ButtonCommand(_StartRecord, true);
            }
        }

        public ICommand StopRecord
        {
            get
            {
                return new ButtonCommand(_StopRecord, true);
            }
        }

        private void _StartRecord()
        {
            if (!Directory.Exists(path))//проверка на коректный путь,если путь некоректеный то  выводится сообщение о некоректеном пути
            {
                isRecord = false;
                MessageBox.Show("Not Correct Path");
                return;
            }
            isRecord = true;
            record.StartRecord(path + "/" + NameOfFile + ".wav");
        }

        private void _StopRecord()
        {
            if (!isRecord)//Проверка идет ли запись 
                return;
            isRecord = false;
            record.StopRecord();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
    
}
