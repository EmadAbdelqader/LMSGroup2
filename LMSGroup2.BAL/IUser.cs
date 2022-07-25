using LMSGroup2.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSGroup2.BAL
{
    interface IUser
    {

        User Get(int Id);
        List<User> GetAll();

        int Save(User model);

        void Update(User model);

        void Delete(int Id);
    }
}