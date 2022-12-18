using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using Moq;
using Shouldly;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using System.Threading;
using Xunit;
using Zip.InstallmentsService.Contracts;
using Zip.InstallmentsService.Domain.Repositories;
using Zip.InstallmentsService.Services;
using Zip.InstallmentsService.Domain;


namespace Zip.InstallmentsService.Test
{
    public class PaymentPlanServiceTests : ServiceTestBase
    {
        private Mock<ILogger<PaymentPlanService>> _logger;
       

        public PaymentPlanServiceTests() : base()
        {
            _logger = new Mock<ILogger<PaymentPlanService>>();
           
        }
        [Fact]
        public void WhenCreatePaymentPlanWithValidOrderAmount_ShouldReturnValidPaymentPlan()
        {
            // Arrange
            IPaymentPlanService paymentPlanFactory = new PaymentPlanService(_unitOfWork.Object,_mapper,_logger.Object);

            //mock data
            var paymentPlanVM = new PaymentPlanRequest();

            paymentPlanVM.Frequency = 14;
            paymentPlanVM.NumberOfInstallments = 4;
            paymentPlanVM.PurhcaseDate = DateAndTime.Today.Date;
            paymentPlanVM.PurchaseAmount = 100;


            _unitOfWork.Setup(m => m.PaymentPlanRepository).Returns(() => new Mock<IPaymentPlanRepository>().Object);
       
            // Act
            var paymentPlan = paymentPlanFactory.CreatePaymentPlan(paymentPlanVM);

            // Assert
            paymentPlan.ShouldNotBeNull();
        }


        /// <summary>
        ///   Validate Valid Installments are getting generated 
        /// </summary>
        [Theory]
        [InlineData(1000, 4, 14, 250.00)]
        [InlineData(4000, 3, 14,1333.33)]
        [InlineData(40, 2, 14, 20)]
      
        public async Task PaymentPlan_With_ValidInstallments(decimal purchaseAmount,
                                                       int numberOfInstallments,
                                                       int frequency,
                                                       decimal installmentAmount)
        {

            //Arrange 
            IPaymentPlanService paymentPlanFactory = new PaymentPlanService(_unitOfWork.Object, _mapper, _logger.Object);

            // Mock data
            var request = CreatePaymentPlanRequest(purchaseAmount, numberOfInstallments, frequency);

            _unitOfWork.Setup(m => m.PaymentPlanRepository).Returns(() => new Mock<IPaymentPlanRepository>().Object);

            // Act
            var paymentPlan = await paymentPlanFactory.CreatePaymentPlan(request);

            Assert.NotNull(paymentPlan);
            Assert.True(paymentPlan.PurchaseAmount == purchaseAmount);
            Assert.True(paymentPlan.Installments.Count == numberOfInstallments);
            

            paymentPlan.Installments.ForEach(installment =>
            {
                Assert.True(installment.Amount.ToString("0.00") == installmentAmount.ToString("0.00"));
            });
        }

        /// <summary>
        ///  To Validate Invalid installments when we have invalid frequency and numberofInstallments
        /// </summary>
        [Theory]
  
        [InlineData(1000, 0, 14)]
        [InlineData(2000, 4, 0)]
        public async Task PaymentPlan_With_InvalidValidInstallments(decimal purchaseAmount,
                                                         int numberOfInstallments,
                                                         int frequency)
        {
            //Arrange 
            IPaymentPlanService paymentPlanFactory = new PaymentPlanService(_unitOfWork.Object, _mapper, _logger.Object);

            // Mock data
            var request = CreatePaymentPlanRequest(purchaseAmount, numberOfInstallments, frequency);

            _unitOfWork.Setup(m => m.PaymentPlanRepository).Returns(() => new Mock<IPaymentPlanRepository>().Object);

            // Act
            var paymentPlan = await paymentPlanFactory.CreatePaymentPlan(request);

            Assert.NotNull(paymentPlan);
            Assert.True(paymentPlan.Installments.Count == 0);
        }


    }
}
