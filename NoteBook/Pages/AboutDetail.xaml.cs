using NoteBook.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NoteBook.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutDetail : ContentPage
    {
        public Database Database { get; set; }
        public About About { get; set; }

        public AboutDetail(Database database, About about)
        {
            InitializeComponent();
            Database = database;
            About = about;
            entryName.Text = about.Name;
            entryDescription.Text = about.Descripton;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            About.Name = entryName.Text;
            About.Descripton = entryDescription.Text;
            await Database.EditAbout(About);
            await Navigation.PopAsync();
        }

        private async void Button_Clicked1(object sender, EventArgs e)
        {
            await Database.DeleteAbout(About);
            await Navigation.PopAsync();
        }
        
    }
}