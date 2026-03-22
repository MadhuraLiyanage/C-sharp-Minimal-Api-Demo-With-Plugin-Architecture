using System.Text.Json.Serialization;

namespace Trading.BaseModels
{
    public class SharesBaseModel: ModelBase
    {
        [JsonRequired]
        public Guid Id { get; set; } = Guid.Empty;
        public string Name { get; set; } = string.Empty;
        public int Count { get; set; } = 0;
        public decimal Price { get; set; } = 0;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public Guid CreatedBy { get; set; } = Guid.Empty;
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
        public Guid UpdatedBy { get; set; } = Guid.Empty;
        public decimal TotalPrice => Count * Price;
    }
}
