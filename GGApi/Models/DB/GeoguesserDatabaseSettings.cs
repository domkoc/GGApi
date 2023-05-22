namespace GGApi.Models.DB
{
    public class GeoguesserDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string LocationCollectionName { get; set; } = null!;
        public string ScoreboardCollectionName { get; set; } = null!;

    }
}
