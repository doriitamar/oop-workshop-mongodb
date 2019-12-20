using MongoDB.Driver;
using MongoDB.Bson;
using Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace MongoDAL 
{
    public class UserDAL 
    {
        #region initialization
        private readonly IMongoCollection<User> users;

        public UserDAL() 
        {
            var client = DBAccess.GetClient();
            var db = client.GetDatabase("sample_mflix");

            users = db.GetCollection<User>("users");
        }
        #endregion initialization

        #region get
        public List<User> GetAll() => users.Find(user => true).ToList();

        public User GetUserByName(string name) => users.Find(user => user.Name.ToLower() == name.ToLower()).First();
        #endregion get

        #region create,read,delete

        public void Update(User ToUpdate) => users.ReplaceOne(user => user.Id == ToUpdate.Id, ToUpdate);

        public User Create(User ToCreate)
        {
            users.InsertOne(ToCreate);
            return ToCreate;
        }

        public void Delete(User ToDelete) => users.DeleteOne(user => user.Id == ToDelete.Id);

        #endregion create,read,delete


        #region simple_agg
            public List<string> GetDistinctPasswordHashes() => users.Distinct<string>("password","{}").ToList();
        #endregion 

        #region  aggs
            public List<User> CommentsByUser()
            {
                var pipeline = new List<BsonDocument>
                {
                    new BsonDocument("$lookup", 
                        new BsonDocument
                            {
                                { "from", "comments" }, 
                                { "localField", "email" }, 
                                { "foreignField", "email" }, 
                                { "as", "comments" }
                            }),
                    new BsonDocument("$addFields", 
                        new BsonDocument("posts", 
                            new BsonDocument("$size", "$comments"))),
                        new BsonDocument("$project", 
                            new BsonDocument("comments", 0))
                };
                
                return users.Aggregate<User>(pipeline).ToList();
            }
        #endregion
    }
}