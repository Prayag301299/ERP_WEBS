using ERP.Repository.Interface;
using ERP.ViewModel;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ERP.Repository.Implement
{
    public class CommonApiClass : ICommonApiClass
    {
        IConfiguration _config;
        public CommonApiClass(IConfiguration _configuration)
        {
            _config = _configuration;
        }
        public ResponseViewModel GetApi(string ControlerName, string methodName)
        {
            try
            {
                string Output = "";
                ResponseViewModel response = new ResponseViewModel();

                var GetApiUrl = _config["ApiUrl"].ToString();
                var fullURL = GetApiUrl + ControlerName + "/" + methodName;
                HttpClient client = new HttpClient();
                HttpResponseMessage responseToken;
                //client.DefaultRequestHeaders.Add("Token", "Token");
                responseToken = client.GetAsync(fullURL).Result;
                if (responseToken.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Output = responseToken.Content.ReadAsStringAsync().Result;
                    //response = JsonSerializer.Deserialize<ResponseViewModel>(Output);
                    response = JsonConvert.DeserializeObject<ResponseViewModel>(Output.ToString());
                }
                else
                {
                    Output = responseToken.Content.ReadAsStringAsync().Result;
                    response = JsonConvert.DeserializeObject<ResponseViewModel>(Output);
                }

                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public ResponseViewModel GetDataById(string ControlerName, string methodName, string para)
        {
            try
            {

                string Output = "";
                ResponseViewModel response = new ResponseViewModel();

                var GetApiUrl = _config["ApiUrl"].ToString();
                var fullURL = GetApiUrl + ControlerName + "/" + methodName + "?" + para;
                HttpClient client = new HttpClient();
                HttpResponseMessage responseToken;
                //client.DefaultRequestHeaders.Add("Token", "Token");
                responseToken = client.PostAsync(fullURL,null).Result;
                if (responseToken.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Output = responseToken.Content.ReadAsStringAsync().Result;
                    //response = JsonSerializer.Deserialize<ResponseViewModel>(Output);
                    response = JsonConvert.DeserializeObject<ResponseViewModel>(Output.ToString());
                }
                else
                {
                    Output = responseToken.Content.ReadAsStringAsync().Result;
                    response = JsonConvert.DeserializeObject<ResponseViewModel>(Output);
                }

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        public ResponseViewModel DeleteApi(string ControlerName, string methodName, string para)
        {
            try
            {

                string Output = "";
                ResponseViewModel response = new ResponseViewModel();

                var GetApiUrl = _config["ApiUrl"].ToString();
                var fullURL = GetApiUrl + ControlerName + "/" + methodName + "?"+ para;
                HttpClient client = new HttpClient();
                HttpResponseMessage responseToken;
                //client.DefaultRequestHeaders.Add("Token", "Token");
                responseToken = client.DeleteAsync(fullURL).Result;
                if (responseToken.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Output = responseToken.Content.ReadAsStringAsync().Result;
                    //response = JsonSerializer.Deserialize<ResponseViewModel>(Output);
                    response = JsonConvert.DeserializeObject<ResponseViewModel>(Output.ToString());
                }
                else
                {
                    Output = responseToken.Content.ReadAsStringAsync().Result;
                    response = JsonConvert.DeserializeObject<ResponseViewModel>(Output);
                }

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public HttpResponseMessage PostApi(string ControlerName, string methodName, string BodyData)
        {
            var GetApiUrl = _config["ApiUrl"].ToString();
            var fullURL = GetApiUrl + ControlerName + "/" + methodName;

            var data = new StringContent(BodyData, Encoding.UTF8, "application/json");

            //HttpClient client = new HttpClient();
            //HttpResponseMessage responseToken;
            //using var client = new HttpClient();



            HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("http://localhost:1379/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.PostAsync(fullURL, data).Result;
            return response;






            //client.DefaultRequestHeaders.Add("Token", "Token");
            //var response = client.PostAsync(fullURL, data);
            //var responseString = response.Content.ReadAsStringAsync();
            //string result = response.Content.ReadAsStringAsync().Result;

            //return "";
        }

    }
}
