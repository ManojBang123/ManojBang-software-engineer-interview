using Zip.InstallmentsService.Domain;
using Zip.InstallmentsService.Contracts;
using AutoMapper;
namespace Zip.InstallmentsService.Services.Mapper
{
    /// <summary>
    /// Used to create auto mapper profile for <see cref="PaymentPlan"/> and <see cref="PaymentPlanResponse"/>
    /// </summary>
    public class PaymentPlanMapper : Profile
    {
        #region Constructor

        /// <summary>
        /// Creates instance of <see cref="PaymentPlanMapper"/>
        /// </summary>
        public PaymentPlanMapper()
        {
            CreateMap<PaymentPlan, PaymentPlanResponse>()
                .ForMember(dest => dest.PaymentPlanId, opt => opt.MapFrom(src => src.Id));

            CreateMap<Installment, InstallmentResponse>()
                .ForMember(dest => dest.InstallmentId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate));
        }

        #endregion
    }
}
