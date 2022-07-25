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
            if (!IsPostBack)
            {
                FillDefaultData();
            }

            // Always fill the data
			FillData();
		}

        private void FillDefaultData()
        {
            // This method to fill the default data such as drop down lists
        }

        private void FillData()
        {
            try
            {
                // Create new users business object
                UsersBO usersBo = new UsersBO();

                // Fill the search properties with the asp control values
                usersBo.UserId = txtUserId.Text == String.Empty ? -1 : Convert.ToInt32(txtUserId.Text);
                usersBo.FirstName = txtFirstName.Text;
                usersBo.lastName = txtLastName.Text;

                // Get users with search
                List<User> usersList = usersBo.GetUsersBySearch();
                
                // Fill the result to the listview
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
            Response.RedirectToRoute("UserDetails", new { mode = "New", Id = 0 });
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            FillData();
        }

        protected void lvUsers_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            UsersBO usersBO = new UsersBO();
            if(e.CommandName == "Delete")
            {
                usersBO.Delete(Convert.ToInt32(e.CommandArgument));

            } else if(e.CommandName == "View")
            {
                Response.RedirectToRoute("UserDetails", new { mode = "View", Id = Convert.ToInt32(e.CommandArgument) });
            }
        }

        protected void lvUsers_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            FillData();
        }
    }
}