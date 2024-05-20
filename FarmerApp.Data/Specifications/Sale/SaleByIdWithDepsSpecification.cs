namespace FarmerApp.Data.Specifications.Sale
{
    public class SaleByIdWithDepsSpecification : SalesWithDepsSpecification
    {
        public SaleByIdWithDepsSpecification(int id) : base(x => x.Id == id)
        {
        }
    }
}
