using ElectronicLogbookModel;
using ElectronicLogbookData;
using ElectronicLogbookEntity;
using System.Collections.Generic;
using System.Linq;

namespace ElectronicLogbookFunction
{
    public class FVisitor : IFVisitor
    {
        private IDVisitor _iDVisitor;

        public FVisitor()
        {
            _iDVisitor = new DVisitor();
        }

        #region CREATE
        public Visitor Create(Visitor visitor)
        {
            EVisitor eVisitor = EVisitor(visitor);
            eVisitor = _iDVisitor.Create(eVisitor);
            return (Visitor(eVisitor));
        }
        #endregion

        #region READ
        public Visitor Read(int visitorId)
        {
            EVisitor eVisitor = _iDVisitor.Read<EVisitor>(a => a.VisitorID == visitorId);
            return Visitor(eVisitor);
        }

        public List<Visitor> List()
        {
            List<EVisitor> eVisitors = _iDVisitor.List<EVisitor>(a => true);
            return Visitors(eVisitors);
        }
        #endregion

        #region UPDATE
        public Visitor Update(Visitor visitor)
        {
            var eVisitor = _iDVisitor.Update(EVisitor(visitor));
            return (Visitor(eVisitor));
        }
        #endregion

        #region DELETE
        public void Delete(Visitor visitor)
        {
            _iDVisitor.Delete(EVisitor(visitor));
        }
        #endregion

        #region OTHER FUNCTION
        private List<Visitor> Visitors(List<EVisitor> eVisitors)
        {
            var returnVisitors = eVisitors.Select(a => new Visitor
            {
                VisitorID = a.VisitorID,
                Date = a.Date,
                Name = a.Name,
                CompanyName = a.CompanyName,
                Purpose = a.Purpose,
                PersonToVisit = a.PersonToVisit,
                IdNumber = a.IdNumber,
                TimeIn = a.TimeIn,
                TimeOut = a.TimeOut,
                CreatedBy = a.CreatedBy,
                UpdatedBy = a.UpdatedBy
            });

            return returnVisitors.ToList();
        }

        private EVisitor EVisitor(Visitor visitor)
        {
            EVisitor returnEVisitor = new EVisitor
            {
                VisitorID = visitor.VisitorID,
                Date = visitor.Date,
                Name = visitor.Name,
                CompanyName = visitor.CompanyName,
                Purpose = visitor.Purpose,
                PersonToVisit = visitor.PersonToVisit,
                IdNumber = visitor.IdNumber,
                TimeIn = visitor.TimeIn,
                TimeOut = visitor.TimeOut,
                CreatedBy = visitor.CreatedBy,
                UpdatedBy = visitor.UpdatedBy
            };
            return returnEVisitor;
        }

        private Visitor Visitor(EVisitor eVisitor)
        {
            Visitor returnVisitor = new Visitor
            {
                VisitorID = eVisitor.VisitorID,
                Date = eVisitor.Date,
                Name = eVisitor.Name,
                CompanyName = eVisitor.CompanyName,
                Purpose = eVisitor.Purpose,
                PersonToVisit = eVisitor.PersonToVisit,
                IdNumber = eVisitor.IdNumber,
                TimeIn = eVisitor.TimeIn,
                TimeOut = eVisitor.TimeOut,
                CreatedBy = eVisitor.CreatedBy,
                UpdatedBy = eVisitor.UpdatedBy
            };
            return returnVisitor;
        }
        #endregion
    }
}
