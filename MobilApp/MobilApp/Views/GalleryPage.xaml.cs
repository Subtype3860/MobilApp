﻿using MobilApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobilApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GalleryPage : ContentPage
    {
        string path = @"/storage/emulated/0/Pictures/";
        private ObservableCollection<InfoImage> _pictureList { get; set; }
        private InfoImage _currentPicture;

        public GalleryPage()
        {
            InitializeComponent();
            _pictureList = new ObservableCollection<InfoImage>();
            pictureList.ItemsSource = _pictureList;
            InitializeData();
        }

        private void InitializeData()
        {
            LoadPictureList();
        }

        private async void LoadPictureList()
        {
            if (Device.RuntimePlatform != Device.Android || !Directory.Exists(path))
                return;

            DirectoryInfo dir = new DirectoryInfo(path);

            var files = dir.GetFileSystemInfos("*.jpg");

            foreach (var file in files)
            {
                _pictureList.Add(new InfoImage(file.Name, file.FullName, file.CreationTime));
            }
        }

        private void OpenPicrureButton_Clicked(object sender, EventArgs e)
        {
            if (pictureList.SelectedItem is null)
                return;

            Navigation.PushAsync(new PhotoPage(pictureList.SelectedItem as InfoImage));
        }

        private async void RemovePictureButton_Clicked(object sender, EventArgs e)
        {
            if (pictureList.SelectedItem is null)
                return;
            InfoImage pic = pictureList.SelectedItem as InfoImage;
            var answer = await DisplayAlert("Внимание!", $"Удалить {pic.NameFile}", "Да", "Нет");

            if (answer == false)
            {
                return;
            }

            try
            {
                if (File.Exists(pic.PathToPicture))
                {
                    File.Delete(pic.PathToPicture);
                }
                _pictureList.Remove(pic);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка!", ex.Message, "OK");
            }
        }
    }
}