using AppMallas.Data;
using AppMallas.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMallas
{
    public partial class App : Application
    {
        private static MallaDatabase database;
        public static MallaDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new MallaDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("malladb.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
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
