using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Net.Http;
using RestSharp;
using RestSharp.Serializers;
using RestSharp.Serializers.SystemTextJson;
using Newtonsoft.Json;

namespace EchoAddressApi.Models
{
    public class AddressServices
    {
        
        public async Task<string> initAddressServiceAsync()
        {
            var uri = new Uri("http://localhost:9001/address-verification/rest/api/");
            string result = null;
            using (var httpClient = new HttpClient())
            {
                try
                {
                    result = await httpClient.GetStringAsync(uri);
                }
                catch (Exception ex)
                {
                    result = "Error occurred while making API call. Error Message is: " + ex.ToString();
                }
            }
            return result;
        }


        public async Task<string> fileProcessAddressService(string data)
        {
            string result = null;
           
            try
            {
                var client = new RestClient("http://localhost:9001/address-verification/rest/api/resolve");
                var uri = new RestRequest(Method.POST)
                    .AddParameter("path", data, ParameterType.UrlSegment);
                var response = client.Execute(uri);
                result = await Task.Run(() => response.ToString());
            }
            catch (Exception ex)
            {
                result = "Error occurred while making file processing API call. Error Message is: " + ex.ToString();
            }
            
            return result;
        }

        public async Task<string> directCallAddressService(string addy, string num, string locality, string province, string country, string postcode, int output)
        {
            string result = null;

            try
            {
                var client = new RestClient("http://localhost:9001/address-verification/rest/api/process");
                var uri = new RestRequest(Method.POST)
                    .AddParameter("addy", addy, ParameterType.UrlSegment)
                    .AddParameter("housenum", num, ParameterType.UrlSegment)
                    .AddParameter("locality", locality, ParameterType.UrlSegment)
                    .AddParameter("province", province, ParameterType.UrlSegment)
                    .AddParameter("country", country, ParameterType.UrlSegment)
                    .AddParameter("postcode", postcode, ParameterType.UrlSegment)
                    .AddParameter("output", output, ParameterType.UrlSegment);
                var response = client.Execute(uri);
                result = await Task.Run(() => response.ToString());
            }
            catch (Exception ex)
            {
                result = "Error occurred while making direct processing API call. Error Message is: " + ex.ToString();
            }

            return result;
        }

    }
}