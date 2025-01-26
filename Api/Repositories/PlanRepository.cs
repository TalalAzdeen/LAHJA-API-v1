using Data;
using Dto;
using Dto.Plan;
using Dto.PlanServices;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
    public interface IPlanRepository : IBaseRepository<Plan>
    {
        Task<IEnumerable<object>> GetAllAsGroupAsync( string langauge);
        void EventOccured(Plan plan, int number);

    }
   
    public class PlanRepository(DataContext db) : BaseRepository<Plan>(db), IPlanRepository
    { 
        public async Task<IEnumerable<object>> GetAllAsGroupAsync(string lg="ar")
        {
            //var s= await db.Database.SqlQuery <PlanResponse> (@$"select ").ToListAsync();

              
            return await _dbSet.GroupBy(x => x.ProductName).Select(  p => new
            {

               

                Plans = p.Select(  o => new PlanGrouping
                {
                    

                    ProductId = o.ProductId,
                //#    BillingPeriod = o.BillingPeriod,
                    Amount = o.Amount,
                    Active = o.Active,
                    ProductName= HelperTranslation.getTranslationValueByLG(o.ProductName,lg),
                    Description= HelperTranslation.getTranslationValueByLG(o.Description,lg),
                    //PlanFeatures=new List<Dto.Plan.PlanFeature>()
                    //{
                    //    new Dto.Plan.PlanFeature()
                    //    {
                    //        Name=HelperTranslation.ConvertTextToTranslationData(o.),
                    //        Description=""
                    //    }
                    //},
                   

                }).ToList()
            }).ToListAsync();

        }

        public void EventOccured(Plan plan, int number)
        {
            //plan.NumberRequests = number;
        }
    }
}