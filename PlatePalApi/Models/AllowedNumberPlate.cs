using MongoDB.Bson;
namespace PlatePalApi.Models
    
{
    public class AllowedNumberPlate
    {
        public string PlateNumber { get; set; }
        public bool access { get; set; }

       // public string TimeCaptured {get; set; }
    }
}
