﻿using FluentValidation.Results;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using Zip.InstallmentsService;
using Zip.InstallmentsService.Contracts;
using Zip.InstallmentsService.Domain.UnitOfWork;
using Zip.InstallmentsService.Services;
using Zip.InstallmentsService.Validator;
using Zip.InstallmentsService.ViewModels;

namespace Zip.InstallmentsRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentPlanController : ControllerBase
    {

        private readonly ILogger<PaymentPlanController> _logger;
        private  IPaymentPlanService _paymentPlanService;

        public PaymentPlanController(ILogger<PaymentPlanController> logger, IPaymentPlanService paymentPlanService)
        {
            _logger = logger;
            _paymentPlanService = paymentPlanService;
        }
        [HttpPost("InstallmentCalcualtor")]
        [Produces("application/json")]

        [SwaggerResponse((int)HttpStatusCode.OK,"Sucesss", typeof(PaymentPlanResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, "Bad Request", typeof(ValidationErrors))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, "Not Found",typeof(Error))]
      

        [SwaggerOperation(Summary = "InstallmentCalcualtor", Description ="This is to just calculate installments with given amount and frequency")]
        public async Task<IActionResult> InstallmentCalcualtor([FromBody] PaymentPlanRequest paymentPlanViewModel)
        {

            _logger.Log(LogLevel.Information, "InstallmentCalcualtor Action is Invoked");

            IActionResult responseResult = BadRequest();

            var paymentPlanValidator = new PaymentPlanValidator();
            var requestvalidationResult = paymentPlanValidator.Validate(paymentPlanViewModel);

            try
            {
                if (requestvalidationResult.IsValid)
                {
                   var paymentplan = await _paymentPlanService.CreatePaymentPlan(paymentPlanViewModel);
                    if (paymentplan != null)
                        responseResult = Ok(paymentplan);
                    else
                        responseResult = BadRequest();
                }
                else
                {
                    foreach(ValidationFailure validationFailure in requestvalidationResult.Errors)
                    {
                        ModelState.AddModelError(validationFailure.PropertyName, validationFailure.ErrorMessage);
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                return BadRequest(new Error("Error Occured", ex.Message));
            }
            finally
            {
                _logger.Log(LogLevel.Information, "InstallmentCalcualtor action is completed");
            }

            return responseResult;


        }
    }
}
