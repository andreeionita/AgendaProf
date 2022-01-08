using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AgendaProf.Data;
namespace AgendaProf
{
    public partial class App : Application
    {
        static NoteListDatabase database;
        public static NoteListDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new NoteListDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                    LocalApplicationData), "NoteList.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new ListEntryPage()) { BarBackgroundColor = Color.Pink };
        }


        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
