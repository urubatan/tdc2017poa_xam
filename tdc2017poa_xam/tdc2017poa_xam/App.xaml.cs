using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace tdc2017poa_xam
{
    public partial class App : Application
    {
        private User currentUser;
        private ReaderRestAPI clientApi = new ReaderRestAPI();
        public App()
        {
            InitializeComponent();
            MainPage = new LoadingPage();
            Task.Factory.StartNew(async () =>
            {
                this.currentUser = await clientApi.RestLogin("rodrigo", "rodrigo");
                Device.BeginInvokeOnMainThread(() =>
                {
                    MainPage = new NavigationPage(new tdc2017poa_xam.MainPage(this.clientApi));
                });
            });
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
