using FPL.Dal.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FPL.Api.Controllers
{
    public class TravelBudgetController : ApiController
    {
        private CustomerManagerEntities db = new CustomerManagerEntities();
        //[HttpPost]
        //public async Task<IHttpActionResult> saveTravelBudget(TravelBudgetDetails data)
        //{
        //    try
        //    {
        //        Table_TravelBudget abc = new Table_TravelBudget()
        //        {
        //            MachineNumber = data.MachineNumber,
        //            CustomerName = data.CustomerName,
        //            Purpose = data.Purpose,
        //            ClusterLocation = data.ClusterLocation,
        //            CNG = data.CNG,
        //            Mileage = data.Mileage,
        //            EstInterDistance = data.EstInterDistance,
        //            EstCompanyDistance = data.EstCompanyDistance,
        //            ActualODOReading = data.ActualODOReading,
        //            EstTravelTime = Convert.ToInt32(data.EstTravelTime),
        //            EstTimeForJob = data.EstTimeForJob,
        //            SchdETD = data.SchdETD,
        //            Totaltime = data.Totaltime,
        //            ActualTime = data.ActualTime,
        //            CNGFilledPreviously = data.CNGFilledPreviously,
        //            UserName = data.UserName,
        //            CreatedOn = DateTime.Now,
        //            TripId = data.TripId,
        //            TravelId = data.TravelId,
        //            UserId = data.UserId,
        //        };

        //        await Task.Run(() => db.Table_TravelBudget.Add(abc));
        //        await db.SaveChangesAsync();

        //        return Ok("success");
        //    }
        //    catch (Exception e)
        //    {

        //        throw e;
        //    }
        //}

        [HttpGet]
        public async Task<IHttpActionResult> GetTripSheetDetails()
        {
            var result = await Task.Run(() => db.Table_TravelBudget.ToList());
            return Ok(result);
        }


        [HttpPost]
        public async Task<IHttpActionResult> PostSaveTripSheetData(TripSheetDataVM tripSheetData)
        {
            try
            {
                var tripSheetEntity = new Table_TravelBudget
                {
                    // Map properties accordingly
                    TripSheetNo = tripSheetData.TripSheetNo,
                    IsDone = tripSheetData.IsDone,
                    TotalEstDistKms = tripSheetData.TotalEstDistKms,
                    TotalEstTravelTime = tripSheetData.TotalEstTravelTime,
                    TotalFoodFuel = tripSheetData.TotalFoodFuel,
                    TotalEstJobTime = tripSheetData.TotalEstJobTime,
                    TotalSchdET = tripSheetData.TotalSchdET,
                    MileageCNG = tripSheetData.MileageCNG,
                    MileagePetrol = tripSheetData.MileagePetrol,
                    MileageDiesel = tripSheetData.MileageDiesel,
                    FuelPriceCNG = tripSheetData.FuelPriceCNG,
                    FuelPricePetrol = tripSheetData.FuelPricePetrol,
                    FuelPriceDiesel = tripSheetData.FuelPriceDiesel,
                    FuelPriceReqd = tripSheetData.FuelPriceReqd,
                    FuelReqd = tripSheetData.FuelReqd,
                    SparesReqd = tripSheetData.SparesReqd,
                    Vehicle = tripSheetData.Vehicle,
                    StartPlace = tripSheetData.StartPlace,
                    StartCluster = tripSheetData.StartCluster,
                    EndPlace = tripSheetData.EndPlace,
                    EndCluster = tripSheetData.EndCluster,
                    InitialTime = tripSheetData.InitialTime,
                    CreatedBy = tripSheetData.CreatedBy,
                    CreatedOn = tripSheetData.CreatedOn,
                    UserId = tripSheetData.UserId,
                };

                // Add ArrayData to the Table_TravelBudget entity
                foreach (var arrayDataVM in tripSheetData.TripSheetValues)
                {
                    var arrayDataEntity = new Table_TravelBudget
                    {
                        TripSheetNo = tripSheetData.TripSheetNo,
                        IsDone = true,
                        TotalEstDistKms = tripSheetData.TotalEstDistKms,
                        TotalEstTravelTime = tripSheetData.TotalEstTravelTime,
                        TotalFoodFuel = tripSheetData.TotalFoodFuel,
                        TotalEstJobTime = tripSheetData.TotalEstJobTime,
                        TotalSchdET = tripSheetData.TotalSchdET,
                        MileageCNG = tripSheetData.MileageCNG,
                        MileagePetrol = tripSheetData.MileagePetrol,
                        MileageDiesel = tripSheetData.MileageDiesel,
                        FuelPriceCNG = tripSheetData.FuelPriceCNG,
                        FuelPricePetrol = tripSheetData.FuelPricePetrol,
                        FuelPriceDiesel = tripSheetData.FuelPriceDiesel,
                        FuelPriceReqd = tripSheetData.FuelPriceReqd,
                        FuelReqd = tripSheetData.FuelReqd,
                        SparesReqd = tripSheetData.SparesReqd,
                        Vehicle = tripSheetData.Vehicle,
                        StartPlace = tripSheetData.StartPlace,
                        StartCluster = tripSheetData.StartCluster,
                        EndPlace = tripSheetData.EndPlace,
                        EndCluster = tripSheetData.EndCluster,
                        InitialTime = tripSheetData.InitialTime,
                        CreatedBy = tripSheetData.CreatedBy,
                        UserId = tripSheetData.UserId,
                        MachineNumber = arrayDataVM.MachineNumber,
                        CompanyName = arrayDataVM.CompanyName,
                        CustomerId = arrayDataVM.CustomerId,
                        Purpose = arrayDataVM.Purpose,
                        Cluster = arrayDataVM.Cluster,
                        ModelId = arrayDataVM.ModelId,
                        ModelName = arrayDataVM.ModelName,
                        Remarks = arrayDataVM.Remarks,
                        RequestForId = arrayDataVM.RequestForId,
                        TicketId = arrayDataVM.TicketId,
                        Zone = arrayDataVM.Zone,
                        EstDistanceKms = arrayDataVM.EstDistanceKms,
                        EstTravelTime = arrayDataVM.EstTravelTime,
                        FoodFuelOthers = arrayDataVM.FoodFuelOthers,
                        EstJobTime = arrayDataVM.EstJobTime,
                        SchdET = arrayDataVM.SchdET,
                        CreatedOn = DateTime.Now,
                        // ... add other properties as needed
                    };
                    await Task.Run(() => db.Table_TravelBudget.Add(arrayDataEntity));
                    await db.SaveChangesAsync();
                }
                

                return Ok("success");
            }
            catch (Exception e)
            {

                throw e;
            }
        }


        [HttpPost]
        public async Task<IHttpActionResult> PostUpdateTripSheetData([FromBody] TripSheetDataVM updatedData)
        {
            try
            {
                //using (var db = new YourDbContext()) // Replace YourDbContext with the actual name of your database context class
                //{
                //var existingTripSheet = db.Table_TravelBudget.FirstOrDefault(t => t.TripSheetNo == updatedData.TripSheetNo);

                //if (existingTripSheet != null)
                //{
                //    // Update the properties with the new values
                //    //                existingTripSheet.FuelPriceCNG = (decimal)updatedData.FuelPriceCNG;
                //    existingTripSheet.SparesReqd = updatedData.SparesReqd;

                //    existingTripSheet.SparesReqd = updatedData.SparesReqd;

                //    existingTripSheet.FuelPricePetrol = (decimal)updatedData.FuelPricePetrol;
                //    existingTripSheet.EndCluster = updatedData.EndCluster;

                //    existingTripSheet.FuelPricePetrol = (decimal)updatedData.FuelPricePetrol;
                //    existingTripSheet.EndPlace = updatedData.EndPlace;

                //    //            existingTripSheet.FuelPriceDiesel = (decimal)updatedData.FuelPriceDiesel;
                //    existingTripSheet.StartCluster = updatedData.StartCluster;

                //    existingTripSheet.FuelPriceReqd = (decimal)updatedData.FuelPriceReqd;
                //    existingTripSheet.StartPlace = updatedData.StartPlace;

                //    existingTripSheet.FuelReqd = (decimal)updatedData.FuelReqd;
                //    existingTripSheet.Vehicle = updatedData.Vehicle;

                //    //           existingTripSheet.MileageCNG = updatedData.MileageCNG;
                //    existingTripSheet.MileagePetrol = updatedData.MileagePetrol;
                //    existingTripSheet.MileageDiesel = updatedData.MileageDiesel;



                //    existingTripSheet.TotalEstJobTime = updatedData.TotalEstJobTime;
                //    existingTripSheet.TotalEstDistKms = updatedData.TotalEstDistKms;

                //    existingTripSheet.FuelPriceCNG = (decimal)updatedData.FuelPriceCNG;
                //    existingTripSheet.TotalEstTravelTime = updatedData.TotalEstTravelTime;

                //    //           existingTripSheet.FuelPriceCNG = (decimal)updatedData.FuelPriceCNG;
                //    existingTripSheet.TotalFoodFuel = updatedData.TotalFoodFuel;

                //    //           existingTripSheet.FuelPriceCNG = (decimal)updatedData.FuelPriceCNG;
                //    existingTripSheet.TotalSchdET = updatedData.TotalSchdET;

                //    existingTripSheet.InitialTime = updatedData.InitialTime;


                

                    foreach (var arrayDataVM in updatedData.TripSheetValues)
                    {
                        var existingArrayData = db.Table_TravelBudget.FirstOrDefault(e => e.id == arrayDataVM.id);
                        if (existingArrayData != null)
                        {
                            // Update existingArrayData properties with new values
                            existingArrayData.MachineNumber = arrayDataVM.MachineNumber;
                            existingArrayData.CompanyName = arrayDataVM.CompanyName;
                            existingArrayData.CustomerId = arrayDataVM.CustomerId;

                            existingArrayData.Purpose = arrayDataVM.Purpose;
                            existingArrayData.Cluster = arrayDataVM.Cluster;

                            existingArrayData.ModelId = arrayDataVM.ModelId;
                            existingArrayData.ModelName = arrayDataVM.ModelName;
                            existingArrayData.Remarks = arrayDataVM.Remarks;
                            existingArrayData.RequestForId = arrayDataVM.RequestForId;
                            existingArrayData.TicketId = arrayDataVM.TicketId;
                            existingArrayData.Zone = arrayDataVM.Zone;

                            existingArrayData.EstDistanceKms = arrayDataVM.EstDistanceKms;
                            existingArrayData.EstTravelTime = arrayDataVM.EstTravelTime;
                            existingArrayData.FoodFuelOthers = arrayDataVM.FoodFuelOthers;
                            existingArrayData.EstJobTime = arrayDataVM.EstJobTime;
                            existingArrayData.SchdET = arrayDataVM.SchdET;

                            existingArrayData.SparesReqd = updatedData.SparesReqd;
                            existingArrayData.InitialTime = updatedData.InitialTime;
                            existingArrayData.TotalSchdET = updatedData.TotalSchdET;
                            existingArrayData.TotalFoodFuel = updatedData.TotalFoodFuel;
                            existingArrayData.TotalEstTravelTime = updatedData.TotalEstTravelTime;


                            existingArrayData.Vehicle = updatedData.Vehicle;
                            existingArrayData.StartCluster = updatedData.StartCluster;
                            existingArrayData.StartPlace = updatedData.StartPlace;
                            existingArrayData.EndPlace = updatedData.EndPlace;
                            existingArrayData.EndCluster = updatedData.EndCluster;

                        existingArrayData.FuelReqd = updatedData.FuelReqd;
                        existingArrayData.FuelPriceCNG = updatedData.FuelPriceCNG;
                        existingArrayData.FuelPricePetrol = updatedData.FuelPricePetrol;
                        existingArrayData.FuelPriceDiesel = updatedData.FuelPriceDiesel;
                        existingArrayData.FuelPriceReqd = updatedData.FuelPriceReqd;


                        existingArrayData.MileageCNG = updatedData.MileageCNG;
                        existingArrayData.MileagePetrol = updatedData.MileagePetrol;
                        existingArrayData.MileageDiesel = updatedData.MileageDiesel;
                        existingArrayData.TotalEstDistKms = updatedData.TotalEstDistKms;
                        
                        existingArrayData.CreatedBy = updatedData.CreatedBy;
                        existingArrayData.CreatedOn = DateTime.Now;




                    }
                    else
                        {
                            // Create a new entity if not found
                            var newArrayDataEntity = new Table_TravelBudget
                            {
                                // Populate properties from arrayDataVM
                                TripSheetNo = updatedData.TripSheetNo,
                                id = arrayDataVM.id, // Replace with the actual unique identifier
                                MachineNumber = arrayDataVM.MachineNumber,
                                CompanyName = arrayDataVM.CompanyName,
                                CustomerId = arrayDataVM.CustomerId,
                                Purpose = arrayDataVM.Purpose,
                                Cluster = arrayDataVM.Cluster,
                                ModelId = arrayDataVM.ModelId,
                                ModelName = arrayDataVM.ModelName,
                                Remarks = arrayDataVM.Remarks,
                                RequestForId = arrayDataVM.RequestForId,
                                TicketId = arrayDataVM.TicketId,
                                Zone = arrayDataVM.Zone,
                                EstDistanceKms = arrayDataVM.EstDistanceKms,
                                EstTravelTime = arrayDataVM.EstTravelTime,
                                FoodFuelOthers = arrayDataVM.FoodFuelOthers,
                                EstJobTime = arrayDataVM.EstJobTime,
                                SchdET = arrayDataVM.SchdET,


                                TotalEstDistKms = arrayDataVM.TotalEstDistKms,
                                TotalEstTravelTime = arrayDataVM.TotalEstTravelTime,
                                TotalFoodFuel = arrayDataVM.TotalFoodFuel,
                                TotalEstJobTime = arrayDataVM.TotalEstJobTime,
                                TotalSchdET = arrayDataVM.TotalSchdET,
                                MileageCNG = arrayDataVM.MileageCNG,
                                MileagePetrol = arrayDataVM.MileagePetrol,
                                MileageDiesel = arrayDataVM.MileageDiesel,
                                FuelPriceCNG = arrayDataVM.FuelPriceCNG,
                                FuelPricePetrol = arrayDataVM.FuelPricePetrol,
                                FuelPriceDiesel = arrayDataVM.FuelPriceDiesel,
                                FuelPriceReqd = arrayDataVM.FuelPriceReqd,
                                FuelReqd = arrayDataVM.FuelReqd,
                                SparesReqd = arrayDataVM.SparesReqd,
                                Vehicle = arrayDataVM.Vehicle,
                                StartPlace = arrayDataVM.StartPlace,
                                StartCluster = arrayDataVM.StartCluster,
                                EndPlace = arrayDataVM.EndPlace,
                                EndCluster = arrayDataVM.EndCluster,
                                InitialTime = arrayDataVM.InitialTime,

                                // ... (populate other properties)
                            };
                            db.Table_TravelBudget.Add(newArrayDataEntity);
                        }
                    await Task.Run(() => db.Entry(existingArrayData).State = EntityState.Modified);
                    // Save changes to the database
                    await db.SaveChangesAsync();


                }





                return Ok("success");
                }

            
            
            catch (Exception e)
            {
                throw e;
            }
        }





        [HttpGet]
        public async Task<IHttpActionResult> GetTripDetailsbyTripSheetNo([FromUri(Name = "id")] int id)
        {
            var tripData = await Task.Run(() => db.Table_TravelBudget.Where(c => c.TripSheetNo == id).Select(c => c).ToList());
            return Ok(tripData);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetTripSheetNos()
        {
            var tripData = await Task.Run(() => db.Table_TravelBudget.GroupBy(c => c.TripSheetNo).Select(group => group.FirstOrDefault()).ToList());

            return Ok(tripData);
        }

        [HttpGet]
        public async Task<IHttpActionResult> DeleteTripData([FromUri(Name = "id")] int id)
        {
            
            var data = await db.Table_TravelBudget.Where(c => c.TripSheetNo == id).ToListAsync();

            db.Table_TravelBudget.RemoveRange(data);
            await db.SaveChangesAsync();

            return Ok("success");
        }



        [HttpGet]
        public async Task<IHttpActionResult> GetTripSheetNo()
        {
            try
            {
                var lastTripSheet = db.Table_TravelBudget.OrderByDescending(c => c.TripSheetNo).FirstOrDefault();

                if (lastTripSheet != null)
                {
                    return Ok(lastTripSheet.TripSheetNo);
                }
                else
                {
                    return Ok(0);
                }
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }



        //[HttpGet]
        //public async Task<IHttpActionResult> GetTravelBudgetbyTravelId([FromUri(Name = "id")] int id)
        //{

        //    var result = await Task.Run(() => db.Table_TravelBudget.Where(c => c.TravelId == id).ToList());
        //    return Ok(result);
        //}
    }

    public partial class TripSheetDataVM
    {
        public int id { get; set; }
        public List<ArrayDataVM> TripSheetValues { get; set; }
        //public List<ArrayDataVM> TripSheetValues { get; set; }
        public Nullable<int> TripSheetNo { get; set; }
        public Nullable<bool> IsDone { get; set; }
        public Nullable<int> TotalEstDistKms { get; set; }
        public Nullable<System.TimeSpan> TotalEstTravelTime { get; set; }
        public Nullable<System.TimeSpan> TotalFoodFuel { get; set; }
        public Nullable<System.TimeSpan> TotalEstJobTime { get; set; }
        public Nullable<System.TimeSpan> TotalSchdET { get; set; }
        public Nullable<int> MileageCNG { get; set; }
        public Nullable<int> MileagePetrol { get; set; }
        public Nullable<int> MileageDiesel { get; set; }
        public Nullable<decimal> FuelPriceCNG { get; set; }
        public Nullable<decimal> FuelPricePetrol { get; set; }
        public Nullable<decimal> FuelPriceDiesel { get; set; }
        public Nullable<decimal> FuelPriceReqd { get; set; }
        public Nullable<decimal> FuelReqd { get; set; }
        public string SparesReqd { get; set; }
        public string Vehicle { get; set; }
        public string StartPlace { get; set; }
        public string StartCluster { get; set; }
        public string EndPlace { get; set; }
        public string EndCluster { get; set; }

        public Nullable<System.TimeSpan> InitialTime { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> UserId { get; set; }
    }

    public partial class ArrayDataVM
    {
        public int id { get; set; }
        public Nullable<int> TripSheetNo { get; set; }
        public string MachineNumber { get; set; }
        public string CompanyName { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public string Purpose { get; set; }
        public string Cluster { get; set; }
        public Nullable<int> ModelId { get; set; }
        public string ModelName { get; set; }
        public string Remarks { get; set; }
        public Nullable<int> RequestForId { get; set; }
        public Nullable<int> TicketId { get; set; }
        public string Zone { get; set; }
        public Nullable<int> EstDistanceKms { get; set; }
        public Nullable<System.TimeSpan> EstTravelTime { get; set; }
        public Nullable<System.TimeSpan> FoodFuelOthers { get; set; }
        public Nullable<System.TimeSpan> EstJobTime { get; set; }
        public Nullable<System.TimeSpan> SchdET { get; set; }
        public Nullable<bool> IsDone { get; set; }
        public Nullable<int> TotalEstDistKms { get; set; }
        public Nullable<System.TimeSpan> TotalEstTravelTime { get; set; }
        public Nullable<System.TimeSpan> TotalFoodFuel { get; set; }
        public Nullable<System.TimeSpan> TotalEstJobTime { get; set; }
        public Nullable<System.TimeSpan> TotalSchdET { get; set; }
        public Nullable<int> MileageCNG { get; set; }
        public Nullable<int> MileagePetrol { get; set; }
        public Nullable<int> MileageDiesel { get; set; }
        public Nullable<decimal> FuelPriceCNG { get; set; }
        public Nullable<decimal> FuelPricePetrol { get; set; }
        public Nullable<decimal> FuelPriceDiesel { get; set; }
        public Nullable<decimal> FuelPriceReqd { get; set; }
        public Nullable<decimal> FuelReqd { get; set; }
        public string SparesReqd { get; set; }
        public string Vehicle { get; set; }
        public string StartPlace { get; set; }
        public string StartCluster { get; set; }
        public string EndPlace { get; set; }
        public string EndCluster { get; set; }

        public Nullable<System.TimeSpan> InitialTime { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> UserId { get; set; }
    }
    public class YourDbContext : DbContext
    {
        public int id { get; set; }
        //public List<ArrayDataVM> TripSheetValues { get; set; }
        public List<ArrayDataVM> TripSheetValues { get; set; }
        public DbSet<TripSheetData> TripSheetDatas { get; set; }
        public Nullable<int> TripSheetNo { get; set; }
        public Nullable<bool> IsDone { get; set; }
        public Nullable<int> TotalEstDistKms { get; set; }
        public Nullable<System.TimeSpan> TotalEstTravelTime { get; set; }
        public Nullable<System.TimeSpan> TotalFoodFuel { get; set; }
        public Nullable<System.TimeSpan> TotalEstJobTime { get; set; }
        public Nullable<System.TimeSpan> TotalSchdET { get; set; }
        public Nullable<int> MileageCNG { get; set; }
        public Nullable<int> MileagePetrol { get; set; }
        public Nullable<int> MileageDiesel { get; set; }
        public Nullable<decimal> FuelPriceCNG { get; set; }
        public Nullable<decimal> FuelPricePetrol { get; set; }
        public Nullable<decimal> FuelPriceDiesel { get; set; }
        public Nullable<decimal> FuelPriceReqd { get; set; }
        public Nullable<decimal> FuelReqd { get; set; }
        public string SparesReqd { get; set; }
        public string Vehicle { get; set; }
        public string StartPlace { get; set; }
        public string StartCluster { get; set; }
        public string EndPlace { get; set; }
        public string EndCluster { get; set; }

        public Nullable<System.TimeSpan> InitialTime { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<int> UserId { get; set; }
    }

   

    public class TripSheetData
    {
        public int TripSheetNo { get; set; }
        public decimal FuelPriceCNG { get; set; }
        public decimal FuelPricePetrol { get; set; }
        public decimal FuelPriceDiesel { get; set; }
        public decimal FuelPriceReqd { get; set; }
        public string FuelReqd { get; set; }
        public DateTime InitialTime { get; set; }
        public decimal MileageCNG { get; set; }
        public decimal MileagePetrol { get; set; }
        public decimal MileageDiesel { get; set; }
        public string SparesReqd { get; set; }
        public string StartCluster { get; set; }
        public string StartPlace { get; set; }
        public string EndCluster { get; set; }
        public string EndPlace { get; set; }
        public string Vehicle { get; set; }
        public decimal TotalEstDistKms { get; set; }
        public string TotalEstJobTime { get; set; }
        public string TotalEstTravelTime { get; set; }
        public string TotalFoodFuel { get; set; }
        public string TotalSchdET { get; set; }
        public int UserId { get; set; }
    }

    public partial class TravelBudgetDetails
    {
        public int id { get; set; }
        public string MachineNumber { get; set; }
        public string CustomerName { get; set; }
        public string Purpose { get; set; }
        public string ClusterLocation { get; set; }
        public string CNG { get; set; }
        public string Mileage { get; set; }
        public string EstInterDistance { get; set; }
        public string EstCompanyDistance { get; set; }
        public string ActualODOReading { get; set; }
        public Nullable<System.DateTime> EstTravelTime { get; set; }
        public Nullable<System.DateTime> EstTimeForJob { get; set; }
        public Nullable<System.DateTime> SchdETD { get; set; }
        public Nullable<System.DateTime> ActualTime { get; set; }
        public Nullable<System.DateTime> Totaltime { get; set; }



        public string CNGFilledPreviously { get; set; }
        public string UserName { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string TripId { get; set; }
        public Nullable<int> TravelId { get; set; }
        public Nullable<int> UserId { get; set; }
    }
}

