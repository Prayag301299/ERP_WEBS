using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System.Net.Http;

namespace ERP_WEB.Helper
{

    public interface IDataAccess
    {
        string GetApi(string ControlerName, string methodName);
        //DateTime GetDate();
    }
    public class Common : IDataAccess
    {
        IConfiguration _config;
        public Common(IConfiguration _configuration)
        {
            _config = _configuration;
        }

        public string GetApi(string ControlerName ,string methodName)
        {
            var GetApiUrl = _config["ApiUrl"].ToString();
            var fullURL = GetApiUrl + ControlerName + "/" + methodName;
            HttpClient client = new HttpClient();
            HttpResponseMessage responseToken;

            //client.DefaultRequestHeaders.Add("Token", "Token");
            responseToken = client.GetAsync(fullURL).Result;
            string Output = responseToken.Content.ReadAsStringAsync().Result;

            return Output;
        }

        public string GetApiWithPara(string APiName, string para)
        {
            var GetApiUrl = _config["ApiUrl"].ToString();
            HttpClient client = new HttpClient();
            HttpResponseMessage responseToken;
            client.DefaultRequestHeaders.Add("Token", "Token");
            responseToken = client.GetAsync(GetApiUrl + APiName + para).Result;
            string PendingListOutput = responseToken.Content.ReadAsStringAsync().Result;

            return "";
        }

        public string PostApi(string APiName, string BodyData)
        {
            var GetApiUrl = _config["ApiUrl"].ToString();

            //var json = JsonConvert.SerializeObject(person);
            //var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = GetApiUrl;
            HttpClient client = new HttpClient();

            //var response = client.PostAsync(url, BodyData);
            //var result = response.Content.ReadAsStringAsync();


            HttpResponseMessage responseToken;
            client.DefaultRequestHeaders.Add("Token", "Token");
            responseToken = client.GetAsync("http://10.0.0.4:9191/PrintSmith/Commerce/PendingList").Result;
            string PendingListOutput = responseToken.Content.ReadAsStringAsync().Result;

            return "";
        }
    }
}
