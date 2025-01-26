using System.ComponentModel.DataAnnotations;

namespace Entities
{

    public class Plan
    {
        [Key]
        public required string Id { get; set; }
        public required string ProductId { get; set; }
        public required string ProductName { get; set; }
        //public required long NumberRequests { get; set; }
        public string? Description { get; set; }
        public List<string>? Images { get; set; }
        public required string BillingPeriod { get; set; }        // daily , weekly , monthly ,.. 
        public required double Amount { get; set; }
        public bool Active { get; set; } = true;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ICollection<Subscription>? Subscriptions { get; set; }
        public ICollection<PlanServices> PlanServices { get; set; } = new List<PlanServices>();

        public ICollection<PlanFeature> PlanFeatures { get; set; } = new List<PlanFeature>();

    }
}
