using LMSGroup2.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSGroup2.BAL
{
    public class LookupTypesBO
    {
        #region Private Variables

        private LMDbContext dc;

        #endregion

        #region Public Properties

        public int TypeId { get; set; }
        public string TypeName { get; set; }

        #endregion

        #region Ctors...

        public LookupTypesBO()
        {
            dc = new LMDbContext();
        }

        #endregion

        #region Get Methods

        public List<LookUpType> GetLookupTypes()
        {
            return dc.LookUpTypes.ToList();
        }

        public LookUpType GetLookupTypeById(int typeId)
        {
            return dc.LookUpTypes.SingleOrDefault(lt => lt.TypeId == typeId);
        }

        public List<LookUpType> GetLookupTypesBySearch()
        {
            var Query = (
                from lt in dc.LookUpTypes
                where
                (TypeId == -1 || TypeId == lt.TypeId) &&
                (TypeName == string.Empty || lt.TypeName.Contains(TypeName))
                select lt
                );

            var result = Query.ToList();
            return result;
        }

        #endregion

        #region Insert Methods

        public int Save(LookUpType type)
        {
            bool isInsert = false;
            LookUpType newType = dc.LookUpTypes.Where(lt => lt.TypeId == type.TypeId).SingleOrDefault();

            if (newType == null)
            {
                newType = new LookUpType();
                newType.CreatedOn = DateTime.Now;
                newType.CreatedBy = type.CreatedBy;
                isInsert = true;
            }
            else
            {
                newType.UpdatedOn = DateTime.Now;
                newType.UpdatedBy = type.UpdatedBy;
            }

            newType.TypeName = type.TypeName;

            if (isInsert)
                dc.LookUpTypes.InsertOnSubmit(type);

            dc.SubmitChanges();

            return newType.TypeId;
        }


        #endregion
    }
}
