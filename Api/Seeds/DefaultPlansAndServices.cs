using Data;
using Dto;
using Dto.Plan;
using Entities;
using Microsoft.EntityFrameworkCore;
using Utilities;

namespace Api.Seeds
{
    public static class DefaultPlansAndServices
    {


      
        public static async Task SeedAsync(DataContext context)
        {
            //var Name = new Dictionary<string, string>
            //{
            //    { "en", "AI Models" },
            //    { "ar", "عدد النماذج AI" }
            //};
            //var Description = new Dictionary<string, string>
            //{
            //    { "en", "3" },
            //    { "ar", "3" }
            //};
            //var c = new Plan()
            //{
            //    Id = "price_1QSOh8KMQ7LabgRTu8QHKFJEfgg",
            //    BillingPeriod = "month",
            //    //NumberRequests = 10,
            //    ProductId = "prod_RL4cPSzDwjdQyh",
            //    ProductName = HelperTranslation.ConvertTranslationDataToText(Name),
            //    Description = HelperTranslation.ConvertTranslationDataToText(Description),
            //    Amount = 0,
            //    Images = null,
            //    Active = true,
            //    UpdatedAt = DateTime.Today,
            //    CreatedAt = DateTime.Today

            //};



            await context.Plans.ExecuteDeleteAsync();
            await context.SaveChangesAsync();

            var planss = GetPlanCreateList();
 



var plansss = new List<PlanCreate>
{
    new PlanCreate
    {
        Id = "1",
        Name = new Dictionary<string, string>
        {
            { "en", "Free" },
            { "ar", "الخطة المجانية" }
        },
        Description = new Dictionary<string, string>
        {
            { "en", "Basic subscription plan" },
            { "ar", "خطة الاشتراك الأساسية" }
        },
        Price = 0m,
        Amount = 0.0
    },
    new PlanCreate
    {
        Id = "1",
        Name = new Dictionary<string, string>
        {
            { "en", "AI Models" },
            { "ar", "عدد النماذج AI" }
        },
        Description = new Dictionary<string, string>
        {
            { "en", "3" },
            { "ar", "3" }
        },
        Price = 0m,
        Amount = 0.0
    },
    new PlanCreate
    {

        Id = "1",
        Name = new Dictionary<string, string>
        {
            { "en", "Requests" },
            { "ar", "الطلبات" }
        },
        Description = new Dictionary<string, string>
        {

            { "en", "1,000 requests" },
            { "ar", "1,000 طلب" }
        },
        Price = 0m,
        Amount = 0.0
    },
    new PlanCreate
    {
        Id = "1",
        Name = new Dictionary<string, string>
        {
            { "en", "Processor" },
            { "ar", "المعالج" }
        },
        Description = new Dictionary<string, string>
        {
            { "en", "Shared" },
            { "ar", "مشترك" }
        },
        Price = 0,
        Amount = 0.0
    },
    new PlanCreate
    {
        Id = "1",
        Name = new Dictionary<string, string>
        {
            { "en", "RAM" },
            { "ar", "الذاكرة العشوائية" }
        },
        Description = new Dictionary<string, string>
        {
            { "en", "2 GB" },
            { "ar", "2 جيجابايت" }
        },
        Price = 0m,
        Amount = 0.0
    },
    new PlanCreate
    {
        Id = "1",
        Name = new Dictionary<string, string>
        {
            { "en", "Speed" },
            { "ar", "السرعة" }
        },
        Description = new Dictionary<string, string>
        {
            { "en", "1 pre/Second" },
            { "ar", "1 عملية/ثانية" }
        },
        Price = 0m,
        Amount = 0.0
    },
    new PlanCreate
    {
        Id = "1",
        Name = new Dictionary<string, string>
        {
            { "en", "Support" },
            { "ar", "الدعم" }
        },
        Description = new Dictionary<string, string>
        {
            { "en", "No" },
            { "ar", "لا" }
        },
        Price = 0m,
        Amount = 0.0
    },
    new PlanCreate
    {
        Id = "1",
        Name = new Dictionary<string, string>
        {
            { "en", "Customization" },
            { "ar", "التخصيص" }
        },
        Description = new Dictionary<string, string>
        {
            { "en", "No" },
            { "ar", "لا" }
        },
        Price = 0m,
        Amount = 0.0
    },
    new PlanCreate
    {
        Id = "1",
        Name = new Dictionary<string, string>
        {
            { "en", "API" },
            { "ar", "API" }
        },
        Description = new Dictionary<string, string>
        {
            { "en", "No" },
            { "ar", "لا" }
        },
        Price = 0m,
        Amount = 0.0
    },
    new PlanCreate
    {
        Id = "1",
        Name = new Dictionary<string, string>
        {
            { "en", "Space" },
            { "ar", "المساحة" }
        },
        Description = new Dictionary<string, string>
        {
            { "en", "1" },
            { "ar", "1" }
        },
        Price = 0m,
        Amount = 0.0
    }
};



            foreach (var item in plansss)
            {

                var plan = new Plan
                {
                    Id = Guid.NewGuid().ToString(),
                    BillingPeriod = "month",

                    ProductId = item.Id,

                    ProductName = HelperTranslation.ConvertTranslationDataToText(item.Name) ,
                    Description = HelperTranslation.ConvertTranslationDataToText(item.Description),
                    Amount = item.Amount,
                    Images = null,
                    Active = true,
                    UpdatedAt = DateTime.Today,
                    CreatedAt = DateTime.Today,


                };
                await context.Plans.AddAsync(plan);
                await context.SaveChangesAsync();

            }
            var result = GetPlans();
         
            //Seed Default User
            if (await context.ModelAis.FirstOrDefaultAsync(p => p.Name == "Wasm Speeker") == null)
            {
                ModelAi modelAi = new ModelAi
                {
                    Name = "Wasm Speeker",
                    AbsolutePath = "wasm-speeker"
                };


                await context.ModelAis.AddAsync(modelAi);
                await context.SaveChangesAsync();




               var plans = GetPlans();
                var services = GetServices(modelAi.Id);
                PlanServices[] planServices = [
                    new() { NumberRequests = 10, Plan = plans[0], Service = services[0],Processor = ProcessorType.Cpu, ConnectionType = ConnectionType.Server, },
                    new() { NumberRequests = 200, Plan = plans[1], Service = services[1] },
                    new() { NumberRequests = 200, Plan = plans[1], Service = services[2] },
                    ];

          
                //await context.PlanServices.AddRangeAsync(planServices);
                //await context.SaveChangesAsync();
                
            }
        }


//        private static Plan[] GetPlan()
//        {



//            var planFeatures = new List<PlanFeatureCreate>
//{
//    new PlanFeatureCreate
//    {
//        Name = new Dictionary<string, string>
//        {
//            { "en", "AI Models" },
//            { "ar", "عدد النماذج AI" }
//        },
//        Description = new Dictionary<string, string>
//        {
//            { "en", "3" },
//            { "ar", "3" }
//        }
//    },
//    new PlanFeatureCreate
//    {
//        Name = new Dictionary<string, string>
//        {
//            { "en", "Requests" },
//            { "ar", "الطلبات" }
//        },
//        Description = new Dictionary<string, string>
//        {
//            { "en", "1,000 requests" },
//            { "ar", "1,000 طلب" }
//        }
//    },
//    new PlanFeatureCreate
//    {
//        Name = new Dictionary<string, string>
//        {
//            { "en", "Processor" },
//            { "ar", "المعالج" }
//        },
//        Description = new Dictionary<string, string>
//        {
//            { "en", "Shared" },
//            { "ar", "مشترك" }
//        }
//    },
//    new PlanFeatureCreate
//    {
//        Name = new Dictionary<string, string>
//        {
//            { "en", "RAM" },
//            { "ar", "الذاكرة العشوائية" }
//        },
//        Description = new Dictionary<string, string>
//        {
//            { "en", "2 GB" },
//            { "ar", "2 جيجابايت" }
//        }
//    },
//    new PlanFeatureCreate
//    {
//        Name = new Dictionary<string, string>
//        {
//            { "en", "Speed" },
//            { "ar", "السرعة" }
//        },
//        Description = new Dictionary<string, string>
//        {
//            { "en", "2 pre/Second" },
//            { "ar", "2 pre/Second" }
//        }
//    },
//    new PlanFeatureCreate
//    {
//        Name = new Dictionary<string, string>
//        {
//            { "en", "Support" },
//            { "ar", "الدعم" }
//        },
//        Description = new Dictionary<string, string>
//        {
//            { "en", "No" },
//            { "ar", "لا" }
//        }
//    },
//    new PlanFeatureCreate
//    {
//        Name = new Dictionary<string, string>
//        {
//            { "en", "Customization" },
//            { "ar", "تخصيص" }
//        },
//        Description = new Dictionary<string, string>
//        {
//            { "en", "No" },
//            { "ar", "لا" }
//        }
//    },
//    new PlanFeatureCreate
//    {
//        Name = new Dictionary<string, string>
//        {
//            { "en", "API" },
//            { "ar", "API" }
//        },
//        Description = new Dictionary<string, string>
//        {
//            { "en", "No" },
//            { "ar", "لا" }
//        }
//    },
//    new PlanFeatureCreate
//    {
//        Name = new Dictionary<string, string>
//        {
//            { "en", "Space" },
//            { "ar", "Space" }
//        },
//        Description = new Dictionary<string, string>
//        {
//            { "en", "1" },
//            { "ar", "1" }
//        }
//    }
//};



//            Plan[] plans = 
//                [
                
                
                
                
//                ];
//            return plans;


//        }





        public static List<PlanCreate> GetPlanCreateList()
        {








            var plans = new List<PlanCreate>
    {


        new PlanCreate
        {


            Name = new Dictionary<string, string>
            {
                { "en", "Free" },
                { "ar", "الخطة المجانية" }
            },
            Description = new Dictionary<string, string>
            {

                { "en", "Basic subscription plan" },
                { "ar", "خطة الاشتراك الأساسية" }
            },
            Price = 0m,
            Amount =0.0,
            Id="1",

            Features =  new PlanFeatureCreate
            {
                Name = new Dictionary<string, string>
            {
                { "en", "AI Models" },
                { "ar", "عدد النماذج AI" }
            },
                Description = new Dictionary<string, string>
            {
                { "en", "3" },
                { "ar", "3" }
            },
                Active = true
            }





        },

         new PlanCreate
        {


            Name = new Dictionary<string, string>
            {
                { "en", "Free" },
                { "ar", "الخطة المجانية" }
            },
            Description = new Dictionary<string, string>
            {

                { "en", "Basic subscription plan" },
                { "ar", "خطة الاشتراك الأساسية" }
            },
            Price = 0m,
            Amount =0.0,
            Id="1",

            Features =  new PlanFeatureCreate
            {
                Name = new Dictionary<string, string>
            {
                { "en", "AI Models" },
                { "ar", "عدد النماذج AI" }
            },
                Description = new Dictionary<string, string>
            {
                { "en", "3" },
                { "ar", "3" }
            },
                Active = true
            }

          }


         };
 


            return plans;
        }

        private static Service[] GetServices(string modelAiId)
        {
            Service[] services = [
            new Service() { Name = "Text to text", Token = "bearer",AbsolutePath="t2t" ,ModelAiId=modelAiId},
                    new Service() { Name = "Audio",AbsolutePath="t2speech", Token = "bearer",ModelAiId=modelAiId },
                    new Service() { Name = "Speaker",AbsolutePath = "speaker", Token = "bearer" , ModelAiId = modelAiId},
                    ];

            return services;
        }

        private static List<Plan> GetPlans()
        {

            List<Plan> plans =
            [
                 new()
                {
                    Id = "price_1QSOh8KMQ7LabgRTu8QHKFJE",
                    BillingPeriod = "month",
                    //NumberRequests = 10,
                    ProductId = "prod_RL4cPSzDwjdQyh",
                    ProductName = "Free",
                    Description="DDDFGFGF",
                    Amount = 0,
                    Images=null,
                    Active=true,
                    UpdatedAt=DateTime.Today,
                    CreatedAt=DateTime.Today
                   
                   

        //public required long NumberRequests { get; set; }

 
                }
               

            ];

            return plans;

        }

    }
}