namespace QaAssessment;
using System.Text.Json;
public class SortProdAssessment_DAO : SortProdAssessment, ISorterProductBase
{
    

    public SortProdAssessment_DAO(string directory) : base(directory, "Products.json")
    {
        FilePath = FileDirectory + "/" + FileName;
    }

    public List<ProductsModel> SortByProperty(ProductProperty productProperty, List<ProductsModel> productsList)
    {
        throw new NotImplementedException();
    }
}
