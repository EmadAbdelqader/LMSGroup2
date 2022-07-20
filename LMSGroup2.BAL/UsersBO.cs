using LMSGroup2.DAL;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSGroup2.BAL
{
    /// <summary>
    /// This is the users business object
    /// </summary>
    public class UsersBO
    {
        #region Private Variables

        /// <summary>
        /// DataContext object
        /// </summary>
        private LMDbContext dc;

        #endregion

        #region Public Properties

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string lastName { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// The main constructor
        /// </summary>
        public UsersBO()
        {
            // datacontext initialization
            dc = new LMDbContext();

        }

        #endregion

        #region Get Methods

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns><see cref="User"/></returns>
        public List<User> GetUsers()
        {
            // SELECT * FROM Users u;
            return dc.Users.ToList();
        }

        public List<User> GetUsersBySearch()
        {
            // SELECT * FROM USERS WHERE
            var Query = (
                from u in dc.Users
                where
                (UserId == -1 || u.UserId == UserId) &&
                (FirstName == String.Empty || u.FirstName.Contains(FirstName)) &&
                (lastName == String.Empty || u.LastName.Contains(lastName))
                select u
                );

            var result = Query.ToList();
            return result;
        }

        /// <summary>
        /// Get the user with a specific userId
        /// </summary>
        /// <param name="UserId">User Id</param>
        /// <returns>User object</returns>
        public User GetUserById(int UserId)
        {
            // SELECT * FROM Users WHERE userId = 2;
            return dc.Users.Where(u => u.UserId == UserId).FirstOrDefault();
        }

        public User GetUserByUsername(string username)
        {
            //string query = "SELECT *";
            return dc.Users.SingleOrDefault(u => u.Username == username);
        }

        public List<UserFullNamesView> GetUserFullNames()
        {
            return (
                from u in dc.Users
                select new UserFullNamesView()
                {
                    FullName = $"{u.FirstName} {u.LastName}"
                }).ToList();
        }

        public List<User> GetUserFullNames2()
        {
            return (
                from u in dc.Users
                select u
                ).ToList();
        }

        #endregion

        #region Insert Methods

        public int Save(User _user)
        {
            bool insert = false;

            // SELECT * FROM Users WHERE UserId = _user.userID
            User newUser = dc.Users.Where(u => u.UserId == _user.UserId).FirstOrDefault();

            if (newUser == null)
            {
                newUser = new User();
                newUser.CreatedOn = DateTime.Now;
                newUser.CreatedBy = 2;
                insert = true;
            }
            else
            {
                newUser.UpdatedBy = 2;
                newUser.UpdatedOn = DateTime.Now;
            }

            newUser.FirstName = _user.FirstName;
            newUser.LastName = _user.LastName;

            if (insert)
            {
                dc.Users.InsertOnSubmit(newUser);
            }

            dc.SubmitChanges();

            return newUser.UserId;

        }

        #endregion

        #region Delete Methods

        public void Delete(int userId) // 3
        {
            User delUser = dc.Users.Where(u => u.UserId == userId).FirstOrDefault();

            if (delUser == null) return;

            dc.Users.DeleteOnSubmit(delUser);
            dc.SubmitChanges();
        }

        public void FakeDelete(int userId)
        {
            // Trying to find the user by its Id
            User delUser = dc.Users.Where(u => u.UserId == userId).FirstOrDefault();

            // exit the delete method
            if (delUser == null) return;

            // Update IsDeleted to be 1 (True)
            delUser.IsDeleted = true;

            dc.SubmitChanges();
        }

        #endregion


    }

    public class UserFullNamesView
    {
        public string FullName { get; set; }
    }


}