using System;
using MongoDAL;
using Models;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region get
            Console.WriteLine("Getting all users from the DB...");

            var UserAccess = new UserDAL();

            UserAccess.GetAll().ForEach(user => Console.WriteLine(user.Name));


            Console.WriteLine("=============================");
            Console.WriteLine("Finding Dona Smith's email......");

            User Donna = UserAccess.GetUserByName("Donna Smith");
            Console.WriteLine(Donna.Email);
            #endregion get

            #region update
            Donna.Email = "donna.smith@realgmail.com";

            UserAccess.Update(Donna);
            Console.WriteLine("Finding Dona Smith's updated email......");

            Donna = UserAccess.GetUserByName("Donna Smith");
            Console.WriteLine(Donna.Email);

            Console.WriteLine("=============================");
            #endregion update

            #region create
            Console.WriteLine("Creating new user......");
            User Itamar = new User{ Email = "me@itamar.rocks", Name = "Itamar Dori", Password="secret123"};
            Itamar = UserAccess.Create(Itamar);
            Console.WriteLine(Itamar.Id);
            #endregion create

            #region delete
            Console.WriteLine("Deleting Itamar.....");
            UserAccess.Delete(Itamar);
            #endregion delete

        }
    }
}