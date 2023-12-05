namespace QaAssessment;
using System.Text.Json;
public class SortProdAssessment_DAO : SortProdAssessment, ISorterProductBase
{
    public SortProdAssessment_DAO(string directory) : base(directory, "Products.json")
    {
        FilePath = FileDirectory + "/" + FileName;
    }

    public List<string> readsTheJsonFile(string directory)
    {
        return File.ReadAllLines(directory + "/" + "Products.json").ToList();
    }


    public List<ProductsModel> SortByProperty(ProductProperty productProperty, string productsJson, bool descending = false)
    {
        var options = new JsonSerializerOptions();
        options.PropertyNameCaseInsensitive = true;

        List<ProductsModel> products = JsonSerializer.Deserialize<List<ProductsModel>>(productsJson, options);

        switch (productProperty)
        {
            case ProductProperty.PRICE:
                if (descending)
                {
                    return products.OrderByDescending(p => p.Price).ToList();
                }
                return products.OrderBy(p => p.Price).ToList();
            case ProductProperty.NAME:
                if (descending)
                {
                    return products.OrderByDescending(p => p.Name).ToList();
                }
                return products.OrderBy(p => p.Name).ToList();
            default:
                if (descending)
                {
                    return products.OrderByDescending(p => p.Stock).ToList();
                }
                return products.OrderBy(p => p.Stock).ToList();
        }
    }
}
