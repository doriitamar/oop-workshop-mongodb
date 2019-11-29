using System;
using MongoDAL;
using Models;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var UserAccess = new UserDAL();

            UserAccess.GetAll().ForEach(user => Console.WriteLine(user.Name));


            Console.WriteLine("=============================");
            Console.WriteLine("Finding Dona Smith's email......");

            User Donna = UserAccess.GetUserByName("Donna Smith");
            Console.WriteLine(Donna.Email);

            Donna.Email = "donna.smith@realgmail.com";

            UserAccess.Update(Donna);
            Console.WriteLine("Finding Dona Smith's updated email......");

            Donna = UserAccess.GetUserByName("Donna Smith");
            Console.WriteLine(Donna.Email);
        }
    }
}