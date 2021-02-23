using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.IO;
using TagSDK.Factories;
using System.Text.Json;
using TagSDK.Models.Enums;
using TagSDK.Models.Authentication;
using System;

namespace Testes
{
    [TestClass]
    public class BaseTest
    {
        public static IConfigurationRoot Configuration { get; set; }
        public static TagServiceCollection Fac { get; set; }

        private TestContext _testContextInstance;

        public TestContext TestContext
        {
            get => _testContextInstance;
            set => _testContextInstance = value;
        }

        public void Init()
        {
            SetToken();
        }

        protected void Print<T>(T value)
        {
            var obj = JsonConvert.SerializeObject(value);
            _testContextInstance.WriteLine(PrettyJson(obj));
        }

        public void SetToken()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath($"{Directory.GetDirectoryRoot("/")}/Configuration")
            .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            var creditor = Configuration.GetSection("creditor").Get<Dictionary<string, object>>();
            var acquirer = Configuration.GetSection("acquirer").Get<Dictionary<string, object>>();

            var acquirerCredentials = new TokenRequest
            {
                Audience = (string)acquirer["audience"],
                ClientId = (string)acquirer["client_id"],
                ClientSecret = (string)acquirer["client_secret"]
            };

            var creditorCredentials = new TokenRequest
            {
                Audience = (string)creditor["audience"],
                ClientId = (string)creditor["client_id"],
                ClientSecret = (string)creditor["client_secret"]
            };

            Fac = TagSdk.GetServices(options =>
            {
                options.BaseUrl = "https://integration.nonprod.taginfraestrutura.com.br";
                options.SetCredential(acquirerCredentials, Profile.ACQUIRER);
                options.SetCredential(creditorCredentials, Profile.CREDITOR);
            });


        }

        private string PrettyJson(string unPrettyJson)
        {
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            var jsonElement = System.Text.Json.JsonSerializer.Deserialize<JsonElement>(unPrettyJson);

            return System.Text.Json.JsonSerializer.Serialize(jsonElement, options);
        }

        public string GeraCNPJ()
        {
            var n = 10;
            var randObj = new Random();
            var n1 = randObj.Next(n);
            var n2 = randObj.Next(n);
            var n3 = randObj.Next(n);
            var n4 = randObj.Next(n);
            var n5 = randObj.Next(n);
            var n6 = randObj.Next(n);
            var n7 = randObj.Next(n);
            var n8 = randObj.Next(n);
            var n9 = 0;
            var n10 = 0;
            var n11 = 0;
            var n12 = 1;
            var d1 = n12 * 2 + n11 * 3 + n10 * 4 + n9 * 5 + n8 * 6 + n7 * 7 + n6 * 8 + n5 * 9 + n4 * 2 + n3 * 3 + n2 * 4 + n1 * 5;

            d1 = 11 - (d1 % 11);

            if (d1 >= 10)
            {
                d1 = 0;
            }

            var d2 = d1 * 2 + n12 * 3 + n11 * 4 + n10 * 5 + n9 * 6 + n8 * 7 + n7 * 8 + n6 * 9 + n5 * 2 + n4 * 3 + n3 * 4 + n2 * 5 + n1 * 6;

            d2 = 11 - (d2 % 11);

            if (d2 >= 10)
            {
                d2 = 0;
            }

            string returnedCNPJ;

            returnedCNPJ = "" + n1 + n2 + n3 + n4 + n5 + n6 + n7 + n8 + n9 + n10 + n11 + n12 + d1 + d2;

            return returnedCNPJ;
        }
    }
}
