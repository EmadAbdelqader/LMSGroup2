using LMSGroup2.BAL;
using LMSGroup2.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSGroup2.TestingOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UsersBO usersBO = new UsersBO();

            // Get the user by userId
            //var users = usersBO.GetUserById(2);

            //// Get all users
            //var usersList = usersBO.GetUsers();

            //// Getting user by username
            //var user = usersBO.GetUserByUsername("Ahmadss");

            //var usersFullNames = usersBO.GetUserFullNames();

            //User user = new User()
            //{
            //    FirstName = "Hikmat",

            //};

            //User user = new User()
            //{
            //    FirstName = "Saleem",
            //    LastName = "..",
            //    MIddleName = "Mahmoud",
            //    UserName = "sam"
            //};

            //usersBO.Save(user);
            //usersBO.GetUserByUsername("Ahmadss");
            //usersBO.Delete(8);

            MathOperations math = new MathOperations();





            Console.WriteLine(math.Add());
            Console.WriteLine(math.Subtract());

            Console.ReadLine();
        }
    }
}