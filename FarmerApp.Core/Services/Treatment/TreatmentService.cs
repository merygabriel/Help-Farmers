using AutoMapper;
using FarmerApp.Core.Models.Treatment;
using FarmerApp.Core.Services.Common;
using FarmerApp.Data.Entities;
using FarmerApp.Data.Specifications.Product;
using FarmerApp.Data.Specifications.Treatment;
using FarmerApp.Data.UnitOfWork;

namespace FarmerApp.Core.Services.Treatment
{
    internal class TreatmentService : BaseService<TreatmentModel, TreatmentEntity>, ITreatmentService
    {
        public TreatmentService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public override async Task<TreatmentModel> Add(TreatmentModel model, int depth = 1, IEnumerable<string> propertyTypesToExclude = null)
        {
            var entity = ValidateAndMap(model, "Model to be added was null");

            if (model.TreatedProductsIds is null || !model.TreatedProductsIds.Any())
                BadRequest("No treated products specified");

            var products = await _uow.Repository<ProductEntity>().GetAllBySpecification(new ProductsByGivenIdsSpecification(model.TreatedProductsIds));
            entity.Products = products;

            await _uow.Repository<TreatmentEntity>().Add(entity);
            await _uow.SaveChangesAsync();

            return await GetById(entity.Id, false, depth, propertyTypesToExclude);
        }

        public override async Task<TreatmentModel> Update(TreatmentModel model, int depth = 1, IEnumerable<string> propertyTypesToExclude = null)
        {
            var entity = ValidateAndMap(model, "Model to be updated was null");
            if (entity.Id == default)
                throw BadRequest("Model must have an Id for updating");

            var existingEntity = await GetEntityBySpecification(new TreatmentWithDepsByIdSpecification(entity.Id));

            var products = await _uow.Repository<ProductEntity>().GetAllBySpecification(new ProductsByGivenIdsSpecification(model.TreatedProductsIds));
            existingEntity.Products = products;

            _mapper.Map(entity, existingEntity);
            await _uow.SaveChangesAsync();

            return await GetById(entity.Id, false, depth, propertyTypesToExclude);
        }
    }
}