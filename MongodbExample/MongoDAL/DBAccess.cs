using System;
using MongoDB.Driver;

namespace MongoDAL
{
    public class DBAccess
    {
        public static String connString = "mongodb+srv:///test?retryWrites=true&w=majority";
        private static MongoClient client;
        public static MongoClient GetClient() {
            if(client == null) {
                client = new MongoClient(connString);
            }

            return client;
        }
    }
}
