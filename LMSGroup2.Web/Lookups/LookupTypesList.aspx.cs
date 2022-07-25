using LMSGroup2.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMSGroup2.Web.Lookups
{
    public partial class LookupTypesList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDefaultData();
                FillData();
            }
        }

        private void FillDefaultData()
        {
            // To be implemented
        }

        private void FillData()
        {
            LookupTypesBO lookupsBo = new LookupTypesBO();

            lookupsBo.TypeId = txtTypeId.Text == String.Empty ? -1 : Convert.ToInt32(txtTypeId.Text);
            lookupsBo.TypeName = txtTypeName.Text;

            var lookupTypes = lookupsBo.GetLookupTypesBySearch();

            lvLookupTypes.DataSource = lookupTypes;
            lvLookupTypes.DataBind();
        }

        protected void btAddNewType_Click(object sender, EventArgs e)
        {
            Response.RedirectToRoute("LookupTypeDetails", new { mode = "New", Id = 0 });
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            FillData();
        }
    }
}