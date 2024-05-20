using FarmerApp.Data.Entities;
using FarmerApp.Data.Specifications.Common;

namespace FarmerApp.Data.Specifications.Treatment
{
    public class TreatmentWithDepsByIdSpecification : BaseSpecification<TreatmentEntity>
    {
        public TreatmentWithDepsByIdSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.MeasurementUnit);
            AddInclude(x => x.Products);
        }
    }
}
