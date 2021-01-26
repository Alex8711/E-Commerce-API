using E_Commerce_API.Models;

namespace E_Commerce_API.Specifications
{
    public class ProductWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecParams productParams) 
            : base(x=>
                (string.IsNullOrEmpty(productParams.Search)|| x.Name.ToLower().Contains(productParams.Search))&&
                (!productParams.BrandId.HasValue||x.ProductBrandId==productParams.BrandId) && 
                (!productParams.TypeId.HasValue|| x.ProductTypeId==productParams.TypeId)
            )
        {
            
        }
    }
}