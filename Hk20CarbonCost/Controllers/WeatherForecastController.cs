using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hk20CarbonCost.Models;
using Hk20CarbonCostML.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.ML;
using RestSharp;

namespace Hk20CarbonCost.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly List<EmissionCategory> emissionCategory;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            emissionCategory = new List<EmissionCategory>();
            var item = new EmissionCategory {
            Id=1,
            Name= "housing",
            Fee=10
            };
            emissionCategory.Add(item);
            item = new EmissionCategory
            {
                Id = 2,
                Name = "travel",
                Fee = 12
            };
            emissionCategory.Add(item);
            item = new EmissionCategory
            {
                Id = 3,
                Name = "travel-ev",
                Fee = 1
            };
            emissionCategory.Add(item);
            item = new EmissionCategory
            {
                Id = 4,
                Name = "food",
                Fee = 9
            };
            emissionCategory.Add(item);
            item = new EmissionCategory
            {
                Id = 5,
                Name = "products",
                Fee = 8
            };
            emissionCategory.Add(item);
            item = new EmissionCategory
            {
                Id = 6,
                Name = "fruits & veg",
                Fee = 3
            };
            emissionCategory.Add(item);
            item = new EmissionCategory
            {
                Id = 7,
                Name = "services",
                Fee = 6
            };
            emissionCategory.Add(item);
            item = new EmissionCategory
            {
                Id = 8,
                Name = "capital",
                Fee = 8
            };
            emissionCategory.Add(item);
            item = new EmissionCategory
            {
                Id = 9,
                Name = "government",
                Fee = 6
            };
            emissionCategory.Add(item);

        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet("ToAccountList")]
        public async  Task<IActionResult> ToAccountList(string customerId)
        {
            var authenicate = await GenerateToken();
            var accountListApi = new RestClient("https://api.preprod.fusionfabric.cloud/retail-banking/accounts/v1/accounts?customerId=FFDC02");
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("X-Request-ID", "6d1a09f9-eeb0-4c17-a21a-b82b28e117f7");
            request.AddHeader("Authorization",  "Bearer " + authenicate.access_token);
            var response = await accountListApi.ExecuteAsync(request);
            return Ok(Newtonsoft.Json.JsonConvert.DeserializeObject<AccountList>(response.Content).items);
        }
        [HttpGet("FromAccountList")]
        public async Task<IActionResult> FromAccountList(string customerId)
        {
            var authenicate = await GenerateToken();
            var accountListApi = new RestClient("https://api.preprod.fusionfabric.cloud/retail-banking/accounts/v1/accounts?customerId=FFDC01");
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("X-Request-ID", "6d1a09f9-eeb0-4c17-a21a-b82b28e117f7");
            request.AddHeader("Authorization", "Bearer " + authenicate.access_token);
            var response = await accountListApi.ExecuteAsync(request);
            return Ok(Newtonsoft.Json.JsonConvert.DeserializeObject<AccountList>(response.Content).items);
        }
        [HttpGet("EmissionCategory")]
        public IActionResult EmissionCategory() { 
            return Ok(emissionCategory);
        }
        [HttpGet("Calculate")]
        public IActionResult Calculate(string amount, string category= "food")
        {
            if (string.IsNullOrEmpty(amount)) 
                amount = "500";
            var result =Convert.ToDouble(amount)* (emissionCategory.FirstOrDefault(x => x.Name.ToLower().Equals(category.ToLower())).Fee/100);
            return Ok(result);
        }
        [HttpGet("AccountBalance")]
        public async Task<IActionResult> AccountBalance(string accountId)
        {
            var authenicate = await GenerateToken();
            var accountListApi = new RestClient("https://api.preprod.fusionfabric.cloud/retail-banking/accounts/v1/accounts/01010OA00P200/balances");
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");
            request.AddHeader("X-Request-ID", "6d1a09f9-eeb0-4c17-a21a-b82b28e117f7");
            request.AddHeader("Authorization", "Bearer " + authenicate.access_token);
            var response = await accountListApi.ExecuteAsync(request);
            return Ok(Newtonsoft.Json.JsonConvert.DeserializeObject<AccountBalance>(response.Content).balances);
        }

        private async Task<FfdcAuthenticate> GenerateToken() {
            var client = new RestClient("https://api.preprod.fusionfabric.cloud/login/v1/sandbox/oidc/token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", "grant_type=client_credentials&client_id=3419ca18-1f69-426b-ab3a-3e5b630c7e74&client_secret=9ac38344-08e8-4c93-9100-fee893fd5728", ParameterType.RequestBody);
            IRestResponse response =await client.ExecuteAsync(request);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<FfdcAuthenticate>(response.Content);
        }

    }
}
