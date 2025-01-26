using Dto.PlanServices;
using System.ComponentModel.DataAnnotations;

namespace Dto.Plan
{

    public class PlanFeatureCreate
    {




        public bool Active { get; set; }

        public Dictionary<string, string>? Name { get; set; }
        public Dictionary<string, string>? Description { get; set; }
    }
    public class PlanCreate
    {
        //[Required(ErrorMessage = "Product id is Required")]
        //public string ProductId { get; set; }

        [Required(ErrorMessage = "Price id is Required")]
        public decimal Price { get; set; }
        public required  Dictionary<string, string> Name { get; set; }
        public  Dictionary<string, string>? Description { get; set; }
        public required double Amount { get; set; }
        public PlanFeatureCreate Features { get; set; }
        public string PriceId { get; set; }
        public string Id { get; set; }


        [Required, MinLength(1)]
        public PlanServicesCreate[] PlanServices { get; set; }

        //public bool IsFree { get; set; } = false;

    }

}
