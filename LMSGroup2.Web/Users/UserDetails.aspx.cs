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
    public partial class UserDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Page.RouteData.Values["mode"] == null)
                    Response.Redirect("~/Users/UsersList.aspx");

                FillData();
            }
        }

        private void FillData()
        {
            try
            {
                string Mode = Page.RouteData.Values["mode"] as string;
                int UserId = Convert.ToInt32(Page.RouteData.Values["Id"]);

                UsersBO usersBo = new UsersBO();
                User user = new User();

                if (Mode == "View")
                {
                    user = usersBo.GetUserById(Convert.ToInt32(Page.RouteData.Values["Id"]));
                    lblUserId.Text = user.UserId.ToString();
                    txtFirstName.Text = user.FirstName;
                    txtLastName.Text = user.LastName;

                    BindLeaveApps();

                    // Modifications
                    btSave.Text = "Update";

                    // To be implemented
                    //BindEvents();
                    //Bind...
                }
                else if (Mode == "New")
                {
                    btSave.Text = "Add";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void BindLeaveApps()
        {
            LeaveApplicatoinsBO leaveApplicatoinsBo = new LeaveApplicatoinsBO();
            var leaves = leaveApplicatoinsBo.GetLeaveAppsByUserId(Convert.ToInt32(Page.RouteData.Values["Id"]));

            lvLeaveApplicatoins.DataSource = leaves;
            lvLeaveApplicatoins.DataBind();
        }

        protected void btSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private bool Save()
        {
            try
            {
                UsersBO usersBO = new UsersBO();
                User user = new User();

                string Mode = Page.RouteData.Values["mode"] as string;
                int UserId = Convert.ToInt32(Page.RouteData.Values["Id"]);

                user.UserId = UserId;
                user.FirstName = txtFirstName.Text;
                user.LastName = txtLastName.Text;

                UserId = usersBO.Save(user);

                if (Mode == "New")
                    Response.RedirectToRoute("UserDetails", new { mode = "View", Id = UserId });
                else
                    FillData();


            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}