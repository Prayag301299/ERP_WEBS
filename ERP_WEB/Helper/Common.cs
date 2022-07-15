using System.Net.Http;

namespace ERP_WEB.Helper
{
    public class Common
    {
        string GetApiUrl = "";
        public string GetApi(string APiName)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage responseToken;
            client.DefaultRequestHeaders.Add("Token", "Token");
            responseToken = client.GetAsync(GetApiUrl + APiName).Result;
            string PendingListOutput = responseToken.Content.ReadAsStringAsync().Result;

            return "";
        }

        public string GetApiWithPara(string APiName,string para)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage responseToken;
            client.DefaultRequestHeaders.Add("Token", "Token");
            responseToken = client.GetAsync(GetApiUrl + APiName + para).Result;
            string PendingListOutput = responseToken.Content.ReadAsStringAsync().Result;

            return "";
        }

        //public string PostApi(string APiName, string BodyData)
        //{
        //    HttpClient client = new HttpClient();
        //    HttpResponseMessage responseToken;
        //    client.DefaultRequestHeaders.Add("Token", "Token");
        //    responseToken = client.GetAsync("http://10.0.0.4:9191/PrintSmith/Commerce/PendingList").Result;
        //    string PendingListOutput = responseToken.Content.ReadAsStringAsync().Result;

        //    return "";
        //}
    }
}
