namespace Appraisal.Api.Settings
{
    public interface IProductDatabaseSettings
    {
        string ProductCollectionName { get; set; }
        string AppraisalCollectionName { get; set; }
        string AppraisalFormCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }  
    }
    
    
    public class ProductDatabaseSettings : IProductDatabaseSettings
    {
        public string ProductCollectionName { get; set; }
        public string AppraisalCollectionName { get; set; }
        public string AppraisalFormCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}