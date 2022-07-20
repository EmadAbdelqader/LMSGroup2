using LMSGroup2.BAL;
using LMSGroup2.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMSGroup2.Web.Users
{
	public partial class UsersList : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if(!IsPostBack)
            {
				FillDefaultData();
            }

			FillData();
		}

        private void FillDefaultData()
        {
        }

        private void FillData()
        {
            try
            {
                UsersBO usersBo = new UsersBO();

                usersBo.UserId = txtUserId.Text == String.Empty ? -1 : Convert.ToInt32(txtUserId.Text);
                usersBo.FirstName = txtFirstName.Text;
                usersBo.lastName = txtLastName.Text;

                List<User> usersList = usersBo.GetUsersBySearch();
                lvUsers.DataSource = usersList;
                lvUsers.DataBind();
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void btAddNewUser_Click(object sender, EventArgs e)
        {
            //Response.RedirectToRoute
        }
    }
}