using Trading.BaseModels;

namespace Trading.BusinessModels
{
    public class SharesModel : SharesBaseModel
    {
        public string Message { get; set; } = string.Empty;
        
        public SharesModel(string name, int count, decimal price, Guid createdBy) 
        {
            this.PluginId = "SharesApi";
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Count = count;
            this.Price = price;
            this.CreatedBy = createdBy;
        }
    }
}
