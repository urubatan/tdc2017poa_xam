using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace tdc2017poa_xam
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ArticlePage : ContentPage
	{
        public ArticlePage(ReaderRestAPI clientApi, int id)
        {
            InitializeComponent();
            Task.Factory.StartNew(async () =>
            {
                var article = await clientApi.getArticle(id);
                Device.BeginInvokeOnMainThread(() =>
                {
                    this.Header.Text = article.Headline;
                    this.Body.Text = article.Body;
                });
            });
        }
	}
}