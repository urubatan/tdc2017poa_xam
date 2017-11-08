using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace tdc2017poa_xam
{
	public partial class MainPage : ContentPage
	{
        private ReaderRestAPI clientApi;
        public MainPage(ReaderRestAPI clientApi)
        {
            this.clientApi = clientApi;
            InitializeComponent();
            Task.Factory.StartNew(async () =>
            {
                var articles = await clientApi.ListArticles();

                Device.BeginInvokeOnMainThread(() =>
                {
                    this.ArticlesList.ItemsSource = articles;
                });
            });
        }
        public MainPage()
        {
            InitializeComponent();
        }
        public void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            }
            Navigation.PushAsync(new ArticlePage(this.clientApi, (e.SelectedItem as Article).Id));

        }
    }
}
