using System.Collections;

using Newtonsoft.Json;
using System.IO;

namespace SocialNetwork.Client.Searcher
{
    public class DataSearcher
    {
        private const string JsonDirectoryPath = "..\\..\\Json-Files\\";
        private const string JsonFileNameFormat = "..\\..\\Json-Files\\{0}.json";

        public static void Search(ISocialNetworkService searcher)
        {
            Directory.CreateDirectory(JsonDirectoryPath);

            var users = searcher.GetUsersAfterCertainDate(2013);
            GenerateJson(users, "users-after-2013");

            var postsByUsers = searcher.GetPostsByUser("ZtlKYHVN7h8SwMmaJs");
            GenerateJson(postsByUsers, "posts-by-user-ZtlKYHVN7h8SwMmaJs");

            var friendships = searcher.GetFriendships(2, 10);
            GenerateJson(friendships, "friendships-page-2");

            var chatUsers = searcher.GetChatUsers("ZtlKYHVN7h8SwMmaJs");
            GenerateJson(chatUsers, "all-interlocutors-of-ZtlKYHVN7h8SwMmaJs");
        }

        private static void GenerateJson(IEnumerable objectCollection, string fileName)
        {
            var json = JsonConvert.SerializeObject(objectCollection);
            File.WriteAllText(string.Format(JsonFileNameFormat, fileName), json);
        }
    }
}