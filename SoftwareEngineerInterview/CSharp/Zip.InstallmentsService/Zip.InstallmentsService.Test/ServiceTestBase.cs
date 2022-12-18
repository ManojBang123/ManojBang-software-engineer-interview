using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zip.InstallmentsService.Contracts;
using Zip.InstallmentsService.Domain;
using Zip.InstallmentsService.Domain.UnitOfWork;
using Zip.InstallmentsService.Persistence.Repositories;
using Zip.InstallmentsService.Services.Mapper;

namespace Zip.InstallmentsService.Test
{
    public class ServiceTestBase
    {
        public Mock<IUnitOfWork> _unitOfWork;
        public IMapper _mapper;

        public ServiceTestBase()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
         
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new PaymentPlanMapper());
                });

                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        /// <summary>
        /// Generates <see cref="CreatePaymentPlanRequest"/> based on inputs
        /// </summary>
        /// <param name="purchaseAmount">The purchase amount</param>
        /// <param name="numberOfInstallments">Number of installments</param>
        /// <param name="frequency">Frequency</param>
        /// <returns></returns>
        public PaymentPlanRequest CreatePaymentPlanRequest(decimal purchaseAmount,
                                                                   int numberOfInstallments,
                                                                   int frequency)
        {
            return new PaymentPlanRequest()
            {
                PurchaseAmount = purchaseAmount,
                NumberOfInstallments = numberOfInstallments,
                Frequency = frequency,
                PurhcaseDate = DateTime.UtcNow
            };
        }

    }
}
