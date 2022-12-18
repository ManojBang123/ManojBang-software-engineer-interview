using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zip.InstallmentsService.Contracts;
using Zip.InstallmentsService.Domain;
using Zip.InstallmentsService.Domain.UnitOfWork;
using Zip.InstallmentsService.ViewModels;

namespace Zip.InstallmentsService.Services
{
    /// <summary>
    /// This class is responsible for building the PaymentPlan according to the Zip product definition.
    /// </summary>
    public class PaymentPlanService : IPaymentPlanService
    {



 
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PaymentPlanService> _logger;
        public PaymentPlanService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<PaymentPlanService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }



        /// <summary>
        /// Builds the PaymentPlan instance.
        /// </summary>
        /// <param name="PaymentPlanRequest">PaymentPlanViewModel is request object</param>
        /// <returns>The PaymentPlan created with all properties set.</returns>
        public async Task<PaymentPlanResponse> CreatePaymentPlan(PaymentPlanRequest paymentPlanRequest)
        {

            _logger.Log(LogLevel.Information, "CreatePaymentPlan is Invoked");
            _logger.Log(LogLevel.Information,  "Request Details :{0}",paymentPlanRequest);

            var paymentPlan = new PaymentPlan(paymentPlanRequest.PurchaseAmount);


            List<Installment> installmentsList = new List<Installment>();

            paymentPlan.Id = Guid.NewGuid();
            paymentPlan.PurchaseAmount = paymentPlanRequest.PurchaseAmount;

            var resultAmount = paymentPlanRequest.PurchaseAmount / paymentPlanRequest.NumberOfInstallments;

            for (var count = 0; count < paymentPlanRequest.NumberOfInstallments; count++)
            {
                var installments = new Installment();
                installments.Id = Guid.NewGuid();
                installments.Amount = resultAmount;
                installments.DueDate = paymentPlanRequest.PurhcaseDate.AddDays(paymentPlanRequest.Frequency * count).ToShortDateString();
                installmentsList.Add(installments);

            }
            paymentPlan.Installments = installmentsList;

             _unitOfWork.PaymentPlanRepository.Add(paymentPlan);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<PaymentPlan, PaymentPlanResponse>(paymentPlan);
        }

       
    }
}
