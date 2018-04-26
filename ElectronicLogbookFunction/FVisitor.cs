using ElectronicLogbookModel;
using ElectronicLogbookData;
using ElectronicLogbookEntity;
using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;

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
            EVisitor eVisitor = _iDVisitor.Read<EVisitor>(a => a.VisitorId == visitorId);
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

                TimeIn = a.TimeIn,
                TimeOut = a.TimeOut,

                PersonToVisit = a.PersonToVisit,

                VisitorId = a.VisitorId,
                
                Comment = a.Comment,
                CompanyName = a.CompanyName,
                KindOfId = a.KindOfId,
                IdNumber = a.IdNumber,
                FirstName = a.FirstName,
                LastName = a.LastName,
                MiddleName = a.MiddleName,
                Purpose = a.Purpose,
               
                CreatedBy = a.CreatedBy,
                UpdatedBy = a.UpdatedBy
            });
            return returnVisitors.ToList();
        }
        private EVisitor EVisitor(Visitor visitor)
        {
            EVisitor returnEVisitor = new EVisitor
            {
                TimeIn = visitor.TimeIn,
                TimeOut = visitor.TimeOut,

                PersonToVisit = visitor.PersonToVisit,

                VisitorId = visitor.VisitorId,

                Comment = visitor.Comment,
                CompanyName = visitor.CompanyName,
                KindOfId = visitor.KindOfId,
                IdNumber = visitor.IdNumber,
                FirstName = visitor.FirstName,
                LastName = visitor.LastName,
                MiddleName = visitor.MiddleName,
                Purpose = visitor.Purpose,

                CreatedBy = visitor.CreatedBy,
                UpdatedBy = visitor.UpdatedBy
            };
            return returnEVisitor;
        }
        private Visitor Visitor(EVisitor eVisitor)
        {
            Visitor returnVisitor = new Visitor
            {
                TimeIn = eVisitor.TimeIn,
                TimeOut = eVisitor.TimeOut,

                PersonToVisit = eVisitor.PersonToVisit,

                VisitorId = eVisitor.VisitorId,
                
                Comment = eVisitor.Comment,
                CompanyName = eVisitor.CompanyName,
                KindOfId = eVisitor.KindOfId,
                IdNumber = eVisitor.IdNumber,
                FirstName = eVisitor.FirstName,
                LastName = eVisitor.LastName,
                MiddleName = eVisitor.MiddleName,
                Purpose = eVisitor.Purpose,
               
                CreatedBy = eVisitor.CreatedBy,
                UpdatedBy = eVisitor.UpdatedBy
            };
            return returnVisitor;
        }
        public void CreateFolder()
        {
            var date = DateTime.Now.ToString("MMMM dd, yyyy");
            if (!Directory.Exists(@"C:\AndersonLogbookFiles\Visitor\" + DateTime.Now.ToString("MMMM dd, yyyy")))
            {
                Directory.CreateDirectory(@"C:\AndersonLogbookFiles\Visitor\" + DateTime.Now.ToString("MMMM dd, yyyy") + @"\VisitorIDCard");
                Directory.CreateDirectory(@"C:\AndersonLogbookFiles\Visitor\" + DateTime.Now.ToString("MMMM dd, yyyy") + @"\VisitorPictures");
                Directory.CreateDirectory(@"C:\AndersonLogbookFiles\Visitor\" + DateTime.Now.ToString("MMMM dd, yyyy") + @"\VisitorDetails");
            }
            else if (date != DateTime.Now.ToString("MMMM dd, yyyy"))
            {
                Directory.CreateDirectory(@"C:\AndersonLogbookFiles\Visitor\" + DateTime.Now.ToString("MMMM dd, yyyy") + @"\VisitorIDCard");
                Directory.CreateDirectory(@"C:\AndersonLogbookFiles\Visitor\" + DateTime.Now.ToString("MMMM dd, yyyy") + @"\VisitorPictures");
                Directory.CreateDirectory(@"C:\AndersonLogbookFiles\Visitor\" + DateTime.Now.ToString("MMMM dd, yyyy") + @"\VisitorDetails");
            }
            else
            {
            }
        }
        
        #endregion
    }
}
