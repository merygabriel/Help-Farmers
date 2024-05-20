using FarmerApp.Data.Entities;
using FarmerApp.Data.Specifications.Common;

namespace FarmerApp.Data.Specifications.Treatment
{
    public class TreatmentsWithDepsSpecification : BaseSpecification<TreatmentEntity>
    {
        public TreatmentsWithDepsSpecification()
        {
            AddInclude(x => x.Products);
            AddInclude(x => x.MeasurementUnit);
        }
    }
}
