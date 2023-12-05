namespace QaAssessment;

interface ISorterProductBase
{
    List<ProductsModel> SortByProperty(ProductProperty productProperty, string productsJson, bool descending);
}
