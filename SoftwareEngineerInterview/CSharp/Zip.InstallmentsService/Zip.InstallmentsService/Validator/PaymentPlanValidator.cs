using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zip.InstallmentsService.Contracts;
using Zip.InstallmentsService.ViewModels;

namespace Zip.InstallmentsService.Validator
{
    public class PaymentPlanValidator : AbstractValidator<PaymentPlanRequest>
    {
        public PaymentPlanValidator()
        {
            RuleFor(property => property.Frequency).NotEmpty().WithMessage(String.Format("Frequency {0}", RequestValidationMessages.NotEmptyMessage));
            RuleFor(property => property.PurchaseAmount).NotEmpty().WithMessage(String.Format("Purchase Amount {0}", RequestValidationMessages.NotEmptyMessage));
            RuleFor(property=>property.NumberOfInstallments).NotEmpty().WithMessage(String.Format("NumberOfInstallments {0}", RequestValidationMessages.NotEmptyMessage));
           
        }
    }
}
