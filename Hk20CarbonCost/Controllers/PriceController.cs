using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hk20CarbonCostML.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ML;
using RestSharp;

namespace Hk20CarbonCost.Controllers
{
   // [Route("api/[controller]")]
   // [ApiController]
    public class PriceController : ControllerBase
    {
        //[HttpPost]
        //public IActionResult Price([FromBody] ModelInput input)
        //{
        //    // Load the model  
        //    MLContext mlContext = new MLContext();
        //    // Create predection engine related to the loaded train model  
        //    ITransformer mlModel = mlContext.Model.Load(@"..\Hk20CarbonCostML.Model\MLModel.zip", out var modelInputSchema);
        //    var predEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);

        //    // Try model on sample data to predict fair price  
        //    ModelOutput result = predEngine.Predict(input);
        //    return Ok();
        //}
        //[HttpGet]
        //public IActionResult AuthTest() {
        //    var client = new RestClient("https://api.preprod.fusionfabric.cloud/login/v1/sandbox/oidc/token");
        //    var request = new RestRequest(Method.POST);
        //    request.AddHeader("cache-control", "no-cache");
        //    request.AddHeader("content-type", "application/x-www-form-urlencoded");
        //    request.AddParameter("application/x-www-form-urlencoded", "grant_type=client_credentials&client_id=3419ca18-1f69-426b-ab3a-3e5b630c7e74&client_secret=9ac38344-08e8-4c93-9100-fee893fd5728", ParameterType.RequestBody);
        //    IRestResponse response = client.Execute(request);
        //    return Ok();
        //}
    }
}
