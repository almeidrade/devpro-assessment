namespace QaAssessment;
using System.Text.Json;
public class Products_DAO : SortProductBase
{
    string directory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
    JsonSerializerOptions options = new JsonSerializerOptions();

    public Products_DAO()
    {
        options.PropertyNameCaseInsensitive = true;
        var productsJson = File.ReadAllText(directory + "/" + "Products.json");

    }

    public override void sortByProperty()
    {
        throw new NotImplementedException();
    }
}
