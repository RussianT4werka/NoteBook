using NoteBook.Classes;
using NoteBook.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NoteBook
{
    
    public partial class MainPage : ContentPage
    {
        public Database Database { get; set; }
        public MainPage(Database database)
        {
            InitializeComponent();
            Database = database;
            
        }

       

        private void Button_Add(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AboutDetail(Database, new About()));
            
        }

        private void collectionView_SelectionChenged(object sender, SelectionChangedEventArgs e)
        {
            if (collectionView.SelectedItem != null)
                Navigation.PushAsync(new AboutDetail(Database, (About)collectionView.SelectedItem));
        }

        protected override async void OnAppearing()
        {
            collectionView.ItemsSource = new List<About>();
            collectionView.ItemsSource = await Database.GetAbouts();
            collectionView.SelectedItem = null;
            base.OnAppearing();
        }
    }
}
