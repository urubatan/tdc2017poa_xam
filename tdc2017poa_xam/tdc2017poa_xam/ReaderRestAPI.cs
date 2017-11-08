using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace tdc2017poa_xam
{
    public class ReaderRestAPI
    {
        RestClient client;

        public ReaderRestAPI()
        {
            this.client = new RestClient("http://192.168.56.2:3000/");
            var cookieContainer = new System.Net.CookieContainer();

            client.CookieContainer = cookieContainer;
        }


        public async Task<User> RestLogin(string Username, string Password)
        {
            try
            {

                var request = new RestRequest("sessions.json", Method.POST);
                request.AddJsonBody(new { session = new { username = Username, password = Password } });
                var response = await client.Execute(request);
                if (response.IsSuccess)
                {
                    Application.Current.Properties["Password"] = Password;
                    Application.Current.Properties["Username"] = Username;
                    Application.Current.Properties["LoggedIn"] = "True";
                    await Application.Current.SavePropertiesAsync();
                    request = new RestRequest("sessions.json", Method.GET);
                    var response2 = await client.Execute<User>(request);
                    if (response2.IsSuccess)
                    {
                        var user = response2.Data;
                        return user;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<Article>> ListArticles()
        {
            var request = new RestRequest("articles.json", Method.GET);
            var resp = await client.Execute<List<Article>>(request);
            var storyList = resp.Data;
            return storyList;

        }
        public async Task<Article> getArticle(int id)
        {
            var request = new RestRequest("articles/{id}.json", Method.GET);
            request.AddUrlSegment("id", id);

            var resp = await client.Execute<Article>(request);
            var story = resp.Data;
            return story;
        }
    }
}