using System;
using MongoDB.Driver;

namespace MongoDAL
{
    public class DBAccess
    {
        public static readonly string connString = "mongodb+srv://itamar:t/test?retryWrites=true&w=majority";
        private static MongoClient client;


        public static MongoClient GetClient() {
            if(client == null) {
                client = new MongoClient(connString);
            }

            return client;
        }
    }
}
