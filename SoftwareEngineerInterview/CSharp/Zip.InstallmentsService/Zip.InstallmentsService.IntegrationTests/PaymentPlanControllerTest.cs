using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Shouldly;
using System.Text;
using Xunit;
using Zip.InstallmentsRestApi.Controllers;
using Zip.InstallmentsService.Contracts;
using Zip.InstallmentsService.Services;
using Zip.InstallmentsService.Test;
using Zip.InstallmentsService.Validator;

namespace Zip.InstallmentsService.IntegrationTests
{
    public class PaymentPlanControllerTest :  IClassFixture<WebApplicationFactory<Program>>
    {

        private readonly WebApplicationFactory<Program> _factory;

        public PaymentPlanControllerTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }


        [Fact] 
        public async void PostPaymentPlan()
        {
            var client = _factory.CreateClient();

            ServiceTestBase paymentPlanTestBase= new ServiceTestBase();

            PaymentPlanRequest request = paymentPlanTestBase.CreatePaymentPlanRequest(1000,4,14);

            var json = JsonConvert.SerializeObject(request);

            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            var response = await client.PostAsync("/PaymentPlan1/InstallmentCalcualtor", stringContent);

            response.EnsureSuccessStatusCode();
            response.StatusCode.ShouldBe(System.Net.HttpStatusCode.OK);

        }
   

    }
}