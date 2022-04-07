using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Avalonia.Media.Imaging;
using System.IO;

namespace Lab8.Models
{
    public class DailyTask : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        Bitmap image;
        string header;
        string mainText;
        //public string ImagePath { get; set; }
        public string MainText
        {
            get => mainText;
            set
            {
                mainText = value;
                NotifyPropertyChanged();
            }
        }
        public string Header
        {
            get => header;
            set
            {
                header = value;
                NotifyPropertyChanged();
            }
        }
        public Bitmap Image
        {
            get => image;
            set
            {
                image = value;
                NotifyPropertyChanged();
            }
        }
        public string ImagePath { get; set; }
        public string Status { get; set; }
        public DailyTask(string s, string h = "none", string t = "text", string iP = @"\Assets\plus.ico")
        {
            Status = s;
            header = h;
            mainText = t;
            if (iP == @"\Assets\plus.ico")
            {
                string directoryPath = Directory.GetCurrentDirectory();
                directoryPath = directoryPath.Remove(directoryPath.LastIndexOf("bin"));
                iP = directoryPath + iP;
            }
            ImagePath = iP;
            image = new Bitmap(iP);
        }
    }
}