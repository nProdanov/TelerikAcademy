using System.Collections;
using System.Linq;

using SocialNetwork.Data;

namespace SocialNetwork.Client.Searcher
{
    public class SocialNetworkService : ISocialNetworkService
    {
        public IEnumerable GetUsersAfterCertainDate(int year)
        {
            var socialNetworkDbContext = new SocialNetworkDbContext();

            var filteredUsers = socialNetworkDbContext
                    .Users
                    .Where(u => u.RegisteredOn.Year > year)
                    .Select(u => new
                    {
                        Username = u.Username,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Images = u.Images.Count
                    })
                    .ToList();

            socialNetworkDbContext.Dispose();
            return filteredUsers;
        }

        public IEnumerable GetPostsByUser(string username)
        {
            var socialNetworkDbContext = new SocialNetworkDbContext();

            var filteredPosts = socialNetworkDbContext
                    .Posts
                    .Where(p => p.TaggedUsers.Any(u => u.Username == username))
                    .Select(p => new
                    {
                        PostedOn = p.PostedOn,
                        Content = p.Content,
                        Users = p.TaggedUsers.Select(u => u.Username)
                    })
                    .ToList();

            socialNetworkDbContext.Dispose();

            return filteredPosts;
        }

        public IEnumerable GetFriendships(int page = 1, int pageSize = 25)
        {
            if (page < 0)
            {
                page = 1;
            }

            if (pageSize < 0)
            {
                pageSize = 25;
            }

            var skip = (page - 1) * pageSize;
            var take = pageSize;

            var socialNetworkDbContext = new SocialNetworkDbContext();
            var filteredFriendships = socialNetworkDbContext
                    .FriendShips
                    .Where(fr => fr.Approved)
                    .OrderBy(fr => fr.FriendsSince)
                    .Skip(skip)
                    .Take(take)
                    .Select(fr => new
                    {
                        FirstUsername = fr.FriendOne.Username,
                        FirstUserImage = fr.FriendOne.Images.Select(im => im.ImgUrl).FirstOrDefault(),
                        SecondUsername = fr.FriendTwo.Username,
                        SeconduserImage = fr.FriendTwo.Images.Select(im => im.ImgUrl).FirstOrDefault()
                    })
                    .ToList();

            socialNetworkDbContext.Dispose();

            return filteredFriendships;
        }

        public IEnumerable GetChatUsers(string username)
        {
            var socialNetworkDbContext = new SocialNetworkDbContext();

            var filteredUsers = socialNetworkDbContext
                .Messages
                .Where(m => m.Friendship.FriendOne.Username == username)
                .Select(m => m.Friendship.FriendTwo.Username)
                .Union(socialNetworkDbContext
                            .Messages.Where(m => m.Friendship.FriendTwo.Username == username)
                            .Select(m => m.Friendship.FriendTwo.Username))
                .Where(u => u != username)
                .Distinct()
                .OrderBy(u => u)
                .ToList();

            socialNetworkDbContext.Dispose();

            return filteredUsers;
        }
    }
}