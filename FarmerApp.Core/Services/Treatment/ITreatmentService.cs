using FarmerApp.Core.Models.Treatment;
using FarmerApp.Core.Services.Common;
using FarmerApp.Data.Entities;

namespace FarmerApp.Core.Services.Treatment
{
    public interface ITreatmentService : IBaseService<TreatmentModel, TreatmentEntity>
    {
    }
}
