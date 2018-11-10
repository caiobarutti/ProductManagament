namespace ProductManagement.Domain.Products.Services
{
    public interface IImportProductFromCsvService
    {
        void Import(string csv);
    }
}