using ElectronicLogbookData;
using ElectronicLogbookModel;
using ElectronicLogbookEntity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElectronicLogbookFunction
{
    public class FInternHistory : IFInternHistory
    {
        private IDInternHistory _iDInternHistory;

        public FInternHistory()
        {
            _iDInternHistory = new DInternHistory();
        }
        #region CREATE
        public InternHistory Create(InternHistory internHistory)
        {
            EInternHistory eInternHistory = EInternHistory(internHistory);
            eInternHistory = _iDInternHistory.Create(eInternHistory);
            return (InternHistory(eInternHistory));
        }
        #endregion
        #region READ
        public InternHistory Read(int internHistoryId)
        {
            EInternHistory eInternHistory = _iDInternHistory.Read<EInternHistory>(a => a.InternHistoryID == internHistoryId);
            return InternHistory(eInternHistory);
        }
        public List<InternHistory> List()
        {
            List<EInternHistory> eInternHistories = _iDInternHistory.List<EInternHistory>(a => true);
            return InternHistories(eInternHistories);
        }
        #endregion
        #region UPDATE
        public InternHistory Update(InternHistory internHistory)
        {
            var eInternHistory = _iDInternHistory.Update(EInternHistory(internHistory));
            return (InternHistory(eInternHistory));
        }
        #endregion
        #region DELETE
        public void Delete(InternHistory internHistory)
        {
            _iDInternHistory.Delete(EInternHistory(internHistory));
        }
        #endregion
        #region OTHER FUNCTION
        private List<InternHistory> InternHistories(List<EInternHistory> eInternHistories)
        {
            var returnInternHistories = eInternHistories.Select(a => new InternHistory
            {
                InternHistoryID = a.InternHistoryID,
                Date = a.Date,
                Name = a.Name,
                School = a.School,
                Department = a.Department,
                IdNumber = a.IdNumber,
                TimeIn = a.TimeIn,
                TimeOut = a.TimeOut,
                CreatedBy = a.CreatedBy,
                UpdatedBy = a.UpdatedBy
            });
            return returnInternHistories.ToList();
        }
        private EInternHistory EInternHistory(InternHistory internHistory)
        {
            EInternHistory returnEInternHistory = new EInternHistory
            {
                InternHistoryID = internHistory.InternHistoryID,
                Date = internHistory.Date,
                Name = internHistory.Name,
                School = internHistory.School,
                Department = internHistory.Department,
                IdNumber = internHistory.IdNumber,
                TimeIn = internHistory.TimeIn,
                TimeOut = internHistory.TimeOut,
                CreatedBy = internHistory.CreatedBy,
                UpdatedBy = internHistory.UpdatedBy
            };
            return returnEInternHistory;
        }
        private InternHistory InternHistory(EInternHistory eInternHistory)
        {
            InternHistory returnInternHistory = new InternHistory
            {
                InternHistoryID = eInternHistory.InternHistoryID,
                Date = eInternHistory.Date,
                Name = eInternHistory.Name,
                School = eInternHistory.School,
                Department = eInternHistory.Department,
                IdNumber = eInternHistory.IdNumber,
                TimeIn = eInternHistory.TimeIn,
                TimeOut = eInternHistory.TimeOut,
                CreatedBy = eInternHistory.CreatedBy,
                UpdatedBy = eInternHistory.UpdatedBy
            };
            return returnInternHistory;
        }
        #endregion
    }
}
