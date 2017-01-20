using System;
using System.Collections.Generic;
using System.Linq;

using SocialNetwork.Client.Extensions;
using SocialNetwork.Client.XmlModels;
using SocialNetwork.Data;
using SocialNetwork.Models;

namespace SocialNetwork.Client
{
    public class Importer
    {
        public void Import()
        {
            var parser = new XmlParser();
            var xmlFriendships = parser.Parse<XmlFriendship>("..\\..\\XmlFiles\\Friendships.xml", "Friendships");
            var xmlPosts = parser.Parse<XmlPost>("..\\..\\XmlFiles\\Posts.xml", "Posts");

            this.ImportUsers(xmlFriendships);
            this.ImportFriendShips(xmlFriendships);
            this.ImportPosts(xmlPosts);
        }

        private void ImportPosts(IEnumerable<XmlPost> xmlPosts)
        {
            ICollection<ICollection<XmlPost>> xmlPostsCollections = new List<ICollection<XmlPost>>();

            var currentXmlPostCollection = new List<XmlPost>();
            var count = 1;
            foreach (var xmlPost in xmlPosts)
            {
                currentXmlPostCollection.Add(xmlPost);
                if (count % 50 == 0)
                {
                    xmlPostsCollections.Add(currentXmlPostCollection);
                    currentXmlPostCollection = new List<XmlPost>();
                }

                count++;
            }
            Console.Write("Importing Posts");
            foreach (var xmlPostsColl in xmlPostsCollections)
            {
                var socialDbContext = new SocialNetworkDbContext();
                socialDbContext.Configuration.AutoDetectChangesEnabled = false;
                socialDbContext.Configuration.ValidateOnSaveEnabled = false;

                var users = socialDbContext.Users.ToList();

                xmlPostsColl
                   .Select(xmlP => new Post()
                   {
                       Content = xmlP.Content,
                       PostedOn = xmlP.PostedOn,
                       TaggedUsers = xmlP.Users.Split(new char[] { ',' }).Select(str => users.Where(u => u.Username == str).FirstOrDefault()).ToList()
                   })
                   .ToList()
                   .ForEach(p => socialDbContext.Posts.Add(p));

                socialDbContext.SaveChanges();
                socialDbContext.Configuration.AutoDetectChangesEnabled = true;
                socialDbContext.Configuration.ValidateOnSaveEnabled = true;
                socialDbContext.Dispose();
                Console.Write(".");
            }
            Console.WriteLine();
        }

        private void ImportFriendShips(IEnumerable<XmlFriendship> xmlFriendships)
        {
            ICollection<ICollection<XmlFriendship>> xmlFriendshipsCollections = new List<ICollection<XmlFriendship>>();

            var currentXmlFrColl = new List<XmlFriendship>();
            var count = 1;
            foreach (var xmlFriendship in xmlFriendships)
            {
                currentXmlFrColl.Add(xmlFriendship);
                if (count % 50 == 0)
                {
                    xmlFriendshipsCollections.Add(currentXmlFrColl);
                    currentXmlFrColl = new List<XmlFriendship>();
                }

                count++;
            }

            Console.WriteLine("Importing Friendships");
            foreach (var xmlFriendshipsCol in xmlFriendshipsCollections)
            {
                var socialDbContext = new SocialNetworkDbContext();
                socialDbContext.Configuration.AutoDetectChangesEnabled = false;
                socialDbContext.Configuration.ValidateOnSaveEnabled = false;

                var users = socialDbContext.Users.ToList();

                xmlFriendshipsCol.Select(fr => new FriendShip()
                {
                    Approved = fr.Approved,
                    FriendsSince = fr.FriendsSince,
                    FriendOne = users.FirstOrDefault(u => u.Username == fr.FirstUser.Username),
                    FriendTwo = users.FirstOrDefault(u => u.Username == fr.SecondUser.Username),
                    Messages = fr
                    .Messages
                    .Select(m => new Message()
                    {
                        Author = users.Where(u => u.Username == m.Author).FirstOrDefault(),
                        Content = m.Content,
                        SeenOn = m.SeenOn,
                        SentOn = m.SentOn
                    })
                    .ToList()
                })
                .ToList().ForEach(fr => socialDbContext.FriendShips.Add(fr));

                socialDbContext.SaveChanges();
                socialDbContext.Configuration.AutoDetectChangesEnabled = true;
                socialDbContext.Configuration.ValidateOnSaveEnabled = true;
                socialDbContext.Dispose();
                Console.Write(".");
            }
            Console.WriteLine();
        }

        private void ImportUsers(IEnumerable<XmlFriendship> xmlFriendships)
        {
            var xmlAllUsers = xmlFriendships
                .Select(u => u.FirstUser)
                .Union(
                    xmlFriendships
                        .Select(u => u.SecondUser)
                 )
                .DistinctBy(u => u.Username);

            var usersToAdd = MapXmlUsersToUserDBModel(xmlAllUsers);

            var socialDbContext = new SocialNetworkDbContext();
            socialDbContext.Configuration.AutoDetectChangesEnabled = false;
            socialDbContext.Configuration.ValidateOnSaveEnabled = false;

            Console.Write("Adding Users");
            var usersAdded = 1;
            foreach (var user in usersToAdd)
            {
                socialDbContext.Users.Add(user);
                if (usersAdded % 100 == 0)
                {
                    socialDbContext.SaveChanges();
                    socialDbContext = new SocialNetworkDbContext();
                    socialDbContext.Configuration.AutoDetectChangesEnabled = false;
                    socialDbContext.Configuration.ValidateOnSaveEnabled = false;
                    Console.Write(".");
                }
                usersAdded++;
            }

            socialDbContext.SaveChanges();
            socialDbContext.Configuration.AutoDetectChangesEnabled = true;
            socialDbContext.Configuration.ValidateOnSaveEnabled = true;
            socialDbContext.Dispose();
            Console.WriteLine();
        }


        private IEnumerable<User> MapXmlUsersToUserDBModel(IEnumerable<XmlUser> xmlAllUsers)
        {
            var usersDbModel = xmlAllUsers
               .Select(xmlU => new User()
               {
                   Username = xmlU.Username,
                   FirstName = xmlU.FirstName,
                   LastName = xmlU.LastName,
                   Images = xmlU.Images.Select(i => new Image()
                   {
                       ImgUrl = i.ImageUrl,
                       FileExtension = i.FileExtension
                   })
                           .ToList(),
                   RegisteredOn = xmlU.RegisteredOn
               });

            return usersDbModel;
        }
    }
}
