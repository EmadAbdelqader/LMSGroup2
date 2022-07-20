using LMSGroup2.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSGroup2.BAL
{
    public class LeaveApplicatoinsBO
    {
        private LMDbContext dc;

        public LeaveApplicatoinsBO()
        {
            dc = new LMDbContext();
        }

        #region Get Methods

        public List<LeaveApplication> GetLeaveAppsByUserId(int userId)
        {
            return dc.LeaveApplications.Where(l => l.UserId == userId).ToList();
        }

        #endregion
    }
}
