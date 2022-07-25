using LMSGroup2.BAL;
using LMSGroup2.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMSGroup2.Web.Lookups
{
    public partial class LookupDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                FillData();
            }
        }

        private void FillData()
        {
            int TypeId = Convert.ToInt32(Page.RouteData.Values["TypeId"]);
            int LookupId = Convert.ToInt32(Page.RouteData.Values["Id"]);

            LookupsBO lookupsBO = new LookupsBO();
            LookUp lookup = lookupsBO.GetLookupByIdandTypeId(TypeId, LookupId);

            txtTypeId.Text = lookup.TypeId.ToString();
            txtLookupId.Text = lookup.LookUpId.ToString();
            txtDescription.Text = lookup.LookupDescription;
        }

        protected void btSave_Click(object sender, EventArgs e)
        {
            int TypeId = Convert.ToInt32(Page.RouteData.Values["TypeId"]);
            int LookupId = Convert.ToInt32(Page.RouteData.Values["Id"]);

            LookupsBO lookupsBO = new LookupsBO();
            LookUp lookup = lookupsBO.GetLookupByIdandTypeId(TypeId, LookupId);

            lookup.LookupDescription = txtDescription.Text;
            lookupsBO.Save(lookup);
        }
    }
}