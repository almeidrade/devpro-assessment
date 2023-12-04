namespace QaAssessment;

interface ISorterProductBase
{
    List<ProductsModel> SortByProperty(ProductProperty productProperty, List<ProductsModel> productsList);
}
