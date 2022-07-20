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
            UsersBO usersBo = new UsersBO();
            User user = usersBo.GetUserById(Convert.ToInt32(Page.RouteData.Values["Id"]));

            if (Page.RouteData.Values["mode"].ToString() == "View")
            {
                lblUserId.Text = user.UserId.ToString();
                txtFirstName.Text = user.FirstName;
                txtLastName.Text = user.LastName;

                BindLeaveApps();
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
            if (Save())
                Response.Redirect("~/Users/UsersList.aspx");
        }

        private bool Save()
        {
            try
            {
                UsersBO usersBO = new UsersBO();
                User user = new User();

                user.UserId = Convert.ToInt32(lblUserId.Text);
                user.FirstName = txtFirstName.Text;
                user.LastName = txtLastName.Text;

                usersBO.Save(user);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}