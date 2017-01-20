using System.Data.Entity;

using SocialNetwork.Data;
using SocialNetwork.Data.Migrations;
using SocialNetwork.Client.Searcher;

namespace SocialNetwork.Client
{
    public static class Startup
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SocialNetworkDbContext, Configuration>());

            var importer = new Importer();
            importer.Import();

            var searchNetworkService = new SocialNetworkService();
            DataSearcher.Search(searchNetworkService);
        }
    }
}
