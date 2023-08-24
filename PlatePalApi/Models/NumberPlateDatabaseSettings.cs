namespace PlatePalApi.Models
{
    public class NumberPlateDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string numberPlatesCollectionName { get; set; } = null!;
    }
}
