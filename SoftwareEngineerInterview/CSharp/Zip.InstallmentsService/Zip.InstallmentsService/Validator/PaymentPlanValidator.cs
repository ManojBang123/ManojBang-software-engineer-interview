using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zip.InstallmentsService.ViewModels;

namespace Zip.InstallmentsService.Validator
{
    public class PaymentPlanValidator : AbstractValidator<PaymentPlanViewModel>
    {
        public PaymentPlanValidator()
        {
            RuleFor(property => property.Frequency).NotEmpty().WithMessage(String.Format("Frequency {0}", RequestValidationMessages.NotEmptyMessage));
            RuleFor(property => property.PurchaseAmount).NotEmpty().WithMessage(String.Format("Amount {0}", RequestValidationMessages.NotEmptyMessage));
            RuleFor(property=>property.NumberOfInstallments).NotEmpty().WithMessage(String.Format("NumberOfInstallments {0}", RequestValidationMessages.NotEmptyMessage));
        }
    }
}
