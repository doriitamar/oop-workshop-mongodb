using System;
using MongoDAL;
using Models;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var UserAccess = new UserDAL();

            #region getAll
            // Console.WriteLine("Getting all users from the DB...");

            // UserAccess.GetAll().ForEach(user => Console.WriteLine(user.Name));
            #endregion

            #region getSpecific
            // Console.WriteLine("=============================");
            // Console.WriteLine("Finding Dona Smith's email......");

            // User Donna = UserAccess.GetUserByName("Donna Smith");
            // Console.WriteLine(Donna.Email);
            #endregion get

            #region update
            // Donna.Email = "donna.smith@realgmail.com";

            // UserAccess.Update(Donna);
            // Console.WriteLine("Finding Dona Smith's updated email......");

            // Donna = UserAccess.GetUserByName("Donna Smith");
            // Console.WriteLine(Donna.Email);

            // Console.WriteLine("=============================");
            #endregion update

            #region create
            // Console.WriteLine("Creating new user......");
            // User Itamar = new User{ Email = "me@itamar.rocks", Name = "Itamar Dori", Password="secret123"};
            // Itamar = UserAccess.Create(Itamar);
            // Console.WriteLine(Itamar.Id);
            // #endregion create

            // #region delete
            // Console.WriteLine("Deleting Itamar.....");
            // UserAccess.Delete(Itamar);
            #endregion delete
            
            #region simple_agg
            // Console.WriteLine("Printing the 5 last characters on every password hash");
            // UserAccess.GetDistinctPasswordHashes().ForEach(password => Console.WriteLine(password.Substring(password.Length - 6,5)));
            #endregion 

            #region aggs
            // Console.WriteLine("Printing each user with its posts number...");
            // UserAccess.CommentsByUser().ForEach(user => Console.WriteLine($"{user.Name} -> {user.Posts}"));
            #endregion

        }
    }
}