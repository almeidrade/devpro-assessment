namespace TestQaAssessment;
using QaAssessment;

public class InventoryManagementTests
{
    ProductProperty productProperty;
    string directory;
    string productsJson;
    bool descending;
    [SetUp]
    public void Setup()
    {        
        directory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
        productsJson = File.ReadAllText(directory + "/" + "Products.json");
    }

    [Test]
    public void TestProdOrderedByPrice()
    {
        int minPriceJson = 50;
        productProperty = ProductProperty.PRICE;
        SortProdAssessment_DAO sbp = new SortProdAssessment_DAO(directory);
        List<ProductsModel> orderedList = sbp.SortByProperty(productProperty, productsJson, descending = false);
        Assert.True(orderedList[0].Price.Equals(minPriceJson));
        Assert.True(orderedList[0].Name.Equals("Product C"));
    }

    [Test]
    public void TestProdOrderedByPriceDescending()
    {
        int maxPriceJson = 200;
        productProperty = ProductProperty.PRICE;
        SortProdAssessment_DAO sbp = new SortProdAssessment_DAO(directory);
        List<ProductsModel> orderedList = sbp.SortByProperty(productProperty, productsJson, descending = true);
        Assert.True(orderedList[0].Price.Equals(maxPriceJson));
        Assert.True(orderedList[0].Name.Equals("Product B"));
    }

    [Test]
    public void TestProdOrderedByName()
    {
        string firstNameOrderedByAlphabet = "Product A";
        productProperty = ProductProperty.NAME;
        SortProdAssessment_DAO sbp = new SortProdAssessment_DAO(directory);
        List<ProductsModel> orderedList = sbp.SortByProperty(productProperty, productsJson, descending = false);
        Assert.True(orderedList[0].Name.Equals(firstNameOrderedByAlphabet));
        Assert.True(orderedList[0].Price.Equals(100));
    }

    [Test]
    public void TestProdOrderedByNameDescending()
    {
        string firstNameOrderedByAlphabet = "Product C";
        productProperty = ProductProperty.NAME;
        SortProdAssessment_DAO sbp = new SortProdAssessment_DAO(directory);
        List<ProductsModel> orderedList = sbp.SortByProperty(productProperty, productsJson, descending = true);
        Assert.True(orderedList[0].Name.Equals(firstNameOrderedByAlphabet));
        Assert.True(orderedList[0].Price.Equals(50));
    }

    [Test]
    public void TestProdOrderedByStock()
    {
        int firstStockNumber = 3;
        productProperty = ProductProperty.STOCK;
        SortProdAssessment_DAO sbp = new SortProdAssessment_DAO(directory);
        List<ProductsModel> orderedList = sbp.SortByProperty(productProperty, productsJson, descending = false);
        Assert.True(orderedList[0].Stock.Equals(firstStockNumber));
        Assert.True(orderedList[0].Name.Equals("Product B"));
    }

    [Test]
    public void TestProdOrderedByStockDescending()
    {
        int lastStockNumber = 10;
        productProperty = ProductProperty.STOCK;
        SortProdAssessment_DAO sbp = new SortProdAssessment_DAO(directory);
        List<ProductsModel> orderedList = sbp.SortByProperty(productProperty, productsJson, descending = true);
        Assert.True(orderedList[0].Stock.Equals(lastStockNumber));
        Assert.True(orderedList[0].Name.Equals("Product C"));
    }
}
