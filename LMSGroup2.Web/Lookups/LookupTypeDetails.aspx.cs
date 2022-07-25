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
    public partial class LookupTypeDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillData();
            }
        }

        private void FillData()
        {
            string Mode = Page.RouteData.Values["mode"] as string;
            int TypeId = Convert.ToInt32(Page.RouteData.Values["Id"]);

            LookupTypesBO lookupsBO = new LookupTypesBO();
            LookUpType lookupType = new LookUpType();

            if (Mode == "View")
            {
                lookupType = lookupsBO.GetLookupTypeById(TypeId);
                
                txtTypeId.Text = lookupType.TypeId.ToString();
                txtTypeName.Text = lookupType.TypeName;

                
                //lvLookups.DataSource = lookupType.LookUps.ToList();
                //lvLookups.DataBind();
                
                BindLookups();
            }
        }

        private void BindLookups()
        {
            LookupsBO lookupsBo= new LookupsBO();
            var lookups = lookupsBo.GetLookupsByTypeId(Convert.ToInt32(Page.RouteData.Values["Id"]));

            lvLookups.DataSource = lookups;
            lvLookups.DataBind();
        }

        protected void btSave_Click(object sender, EventArgs e)
        {
            try
            {
                LookupTypesBO lookupsBo = new LookupTypesBO();
                LookUpType type = new LookUpType();

                string Mode = Page.RouteData.Values["mode"] as string;
                int TypeId = Convert.ToInt32(Page.RouteData.Values["Id"]);

                type.TypeId = TypeId;
                type.TypeName = txtTypeName.Text;

                TypeId = lookupsBo.Save(type);

                if (Mode == "New")
                    Response.RedirectToRoute("LookupTypeDetails", new { mode = "View", Id = TypeId });
                else
                    FillData();

            }
            catch (Exception) { }
        }

        protected void btAddNewLookup_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("LookupDetails", new { mode = "View", TypeId = Convert.ToInt32(Page.RouteData.Values["Id"]), Id = 0 });
        }
    }
}