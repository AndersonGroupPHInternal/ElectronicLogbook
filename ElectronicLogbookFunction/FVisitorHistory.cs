
using ElectronicLogbookData;
using ElectronicLogbookModel;
using ElectronicLogbookEntity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElectronicLogbookFunction
{
    public class FVisitorHistory : IFVisitorHistory
    {
        private IDVisitorHistory _iDVisitorHistory;

        public FVisitorHistory()
        {
            _iDVisitorHistory = new DVisitorHistory();
        }

        #region CREATE
        public VisitorHistory Create(VisitorHistory visitorHistory)
        {
            EVisitorHistory eVisitorHistory = EVisitorHistory(visitorHistory);
            eVisitorHistory = _iDVisitorHistory.Create(eVisitorHistory);
            return (VisitorHistory(eVisitorHistory));
        }
        #endregion

        #region READ
        public VisitorHistory Read(int visitorHistoryId)
        {
            EVisitorHistory eVisitorHistory = _iDVisitorHistory.Read<EVisitorHistory>(a => a.VisitorHistoryID == visitorHistoryId);
            return VisitorHistory(eVisitorHistory);
        }

        public List<VisitorHistory> List()
        {
            List<EVisitorHistory> eVisitorHistories = _iDVisitorHistory.List<EVisitorHistory>(a => true);
            return VisitorHistories(eVisitorHistories);
        }
        #endregion

        #region UPDATE
        public VisitorHistory Update(VisitorHistory visitorHistory)
        {
            var eVisitorHistory = _iDVisitorHistory.Update(EVisitorHistory(visitorHistory));
            return (VisitorHistory(eVisitorHistory));
        }
        #endregion

        #region DELETE
        public void Delete(VisitorHistory visitorHistory)
        {
            _iDVisitorHistory.Delete(EVisitorHistory(visitorHistory));
        }
        #endregion

        #region OTHER FUNCTION
        private List<VisitorHistory> VisitorHistories(List<EVisitorHistory> eVisitorHistories)
        {
            var returnVisitorHistories = eVisitorHistories.Select(a => new VisitorHistory
            {
                VisitorHistoryID = a.VisitorHistoryID,
                Date = a.Date,
                Name = a.Name,
                Purpose = a.Purpose,
                TimeIn = a.TimeIn,
                TimeOut = a.TimeOut,
                CreatedBy = a.CreatedBy,
                UpdatedBy = a.UpdatedBy
            });

            return returnVisitorHistories.ToList();
        }

        private EVisitorHistory EVisitorHistory(VisitorHistory visitorHistory)
        {
            EVisitorHistory returnEVisitorHistory = new EVisitorHistory
            {
                VisitorHistoryID = visitorHistory.VisitorHistoryID,
                Date = visitorHistory.Date,
                Name = visitorHistory.Name,
                Purpose = visitorHistory.Purpose,
                TimeIn = visitorHistory.TimeIn,
                TimeOut = visitorHistory.TimeOut,
                CreatedBy = visitorHistory.CreatedBy,
                UpdatedBy = visitorHistory.UpdatedBy
            };
            return returnEVisitorHistory;
        }

        private VisitorHistory VisitorHistory(EVisitorHistory eVisitorHistory)
        {
            VisitorHistory returnVisitorHistory = new VisitorHistory
            {
                VisitorHistoryID = eVisitorHistory.VisitorHistoryID,
                Date = eVisitorHistory.Date,
                Name = eVisitorHistory.Name,
                Purpose = eVisitorHistory.Purpose,
                TimeIn = eVisitorHistory.TimeIn,
                TimeOut = eVisitorHistory.TimeOut,
                CreatedBy = eVisitorHistory.CreatedBy,
                UpdatedBy = eVisitorHistory.UpdatedBy
            };
            return returnVisitorHistory;
        }
        #endregion
    }
}
