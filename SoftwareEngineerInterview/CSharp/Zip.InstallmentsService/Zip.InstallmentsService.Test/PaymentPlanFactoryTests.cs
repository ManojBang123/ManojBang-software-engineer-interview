using Microsoft.VisualBasic;
using Shouldly;
using Xunit;
using Zip.InstallmentsService.ViewModels;

namespace Zip.InstallmentsService.Test
{
    public class PaymentPlanFactoryTests
    {
        [Fact]
        public void WhenCreatePaymentPlanWithValidOrderAmount_ShouldReturnValidPaymentPlan()
        {
            // Arrange
            var paymentPlanFactory = new PaymentPlanFactory();

            //mock data
            var paymentPlanVM = new PaymentPlanViewModel();

            paymentPlanVM.Frequency = 14;
            paymentPlanVM.NumberOfInstallments = 4;
            paymentPlanVM.PurchaseDate = DateAndTime.Today.Date;
            paymentPlanVM.PurchaseAmount = 100;

            // Act
            var paymentPlan = paymentPlanFactory.CreatePaymentPlan(paymentPlanVM);

            // Assert
            paymentPlan.ShouldNotBeNull();
        }
    }
}
