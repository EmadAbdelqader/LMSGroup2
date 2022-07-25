using LMSGroup2.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSGroup2.BAL
{
    public class LookupsBO
    {
        #region Private Variables

        private LMDbContext dc;

        #endregion

        #region Ctors..

        public LookupsBO()
        {
            dc = new LMDbContext();
        }

        #endregion

        #region Get Methods

        public List<LookUp> GetLookupsByTypeId(int typeId)
        {
            return dc.LookUps.Where(l => l.TypeId == typeId).ToList();
        }

        public LookUp GetLookupByIdandTypeId(int typeId, int lookupId)
        {
            return dc.LookUps.SingleOrDefault(l => l.TypeId == typeId && l.LookUpId == lookupId);
        }

        #endregion

        #region Insert Methods

        public int Save(LookUp lookup)
        {
            bool isInsert = false;
            LookUp newLookup = dc.LookUps.Where(lt => lt.TypeId == lookup.TypeId && lt.LookUpId == lookup.LookUpId).SingleOrDefault();

            if (newLookup == null)
            {
                newLookup = new LookUp();
                newLookup.CreatedOn = DateTime.Now;
                newLookup.CreatedBy = lookup.CreatedBy;
                isInsert = true;
            }
            else
            {
                newLookup.UpdatedOn = DateTime.Now;
                newLookup.UpdatedBy = lookup.UpdatedBy;
            }

            newLookup.LookupDescription= lookup.LookupDescription;

            if (isInsert)
                dc.LookUps.InsertOnSubmit(lookup);

            dc.SubmitChanges();

            return lookup.LookUpId;
        }

        #endregion

    }
}
