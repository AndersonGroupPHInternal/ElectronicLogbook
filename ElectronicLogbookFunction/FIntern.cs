using ElectronicLogbookModel;
using ElectronicLogbookData;
using ElectronicLogbookEntity;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;

namespace ElectronicLogbookFunction
{
    public class FIntern : IFIntern
    {
        private IDIntern _iDIntern;

        public FIntern()
        {
            _iDIntern = new DIntern();
        }

        #region CREATE
        public Intern Create(Intern intern)
        {
            EIntern eIntern = EIntern(intern);
            eIntern = _iDIntern.Create(eIntern);

            //EInternHistory eInternHistory = new EInternHistory
            //{
            //    InternID = eIntern.InternID,
            //    Date = eIntern.Date,
            //    Name = eIntern.Name,
            //    School = eIntern.School,
            //    Department = eIntern.Department,
            //    IdNumber = eIntern.IdNumber,
            //    TimeIn = eIntern.TimeIn,
            //    TimeOut = eIntern.TimeOut
            //};
            //_iDIntern.Create(eInternHistory);
            return (Intern(eIntern));
        }
        #endregion

        #region READ
        public Intern Read(int internId)
        {
            EIntern eIntern = _iDIntern.Read<EIntern>(a => a.InternID == internId);
            return Intern(eIntern);
        }

        public List<Intern> List()
        {
            List<EIntern> eInterns = _iDIntern.List<EIntern>(a => true);
            return Interns(eInterns);
        }
        #endregion

        #region UPDATE
        public Intern Update(Intern intern)
        {
            EIntern currentIntern = _iDIntern.Read<EIntern>(a => a.InternID == intern.InternID);
            var eIntern = _iDIntern.Update(EIntern(intern));
            if (intern.InternID == currentIntern.InternID)
            {
                EInternHistory eInternHistory = new EInternHistory
                {
                    InternID = eIntern.InternID,
                    Date = eIntern.Date,
                    Name = eIntern.Name,
                    School = eIntern.School,
                    Department = eIntern.Department,
                    IdNumber = eIntern.IdNumber,
                    TimeIn = eIntern.TimeIn,
                    TimeOut = eIntern.TimeOut
                };
                _iDIntern.Create(eInternHistory);
            }
            return (Intern(eIntern));
        }
        #endregion

        #region DELETE
        public void Delete(Intern intern)
        {
            _iDIntern.Delete(EIntern(intern));
        }
        #endregion

        #region OTHER FUNCTION
        private List<Intern> Interns(List<EIntern> eInterns)
        {
            var returnInterns = eInterns.Select(a => new Intern
            {
                InternID = a.InternID,
                Date = a.Date,
                Name = a.Name,
                School = a.School,
                Department = a.Department,
                Supervisor = a.Supervisor,
                IdNumber = a.IdNumber,
                TimeIn = a.TimeIn,
                TimeOut = a.TimeOut,
                CreatedBy = a.CreatedBy,
                UpdatedBy = a.UpdatedBy
            });

            return returnInterns.ToList();
        }

        private EIntern EIntern(Intern intern)
        {
            EIntern returnEIntern = new EIntern
            {
                InternID = intern.InternID,
                Date = intern.Date,
                Name = intern.Name,
                School = intern.School,
                Department = intern.Department,
                Supervisor = intern.Supervisor,
                IdNumber = intern.IdNumber,
                TimeIn = intern.TimeIn,
                TimeOut = intern.TimeOut,
                CreatedBy = intern.CreatedBy,
                UpdatedBy = intern.UpdatedBy
            };
            return returnEIntern;
        }

        private Intern Intern(EIntern eIntern)
        {
            Intern returnIntern = new Intern
            {
                InternID = eIntern.InternID,
                Date = eIntern.Date,
                Name = eIntern.Name,
                School = eIntern.School,
                Department = eIntern.Department,
                Supervisor = eIntern.Supervisor,
                IdNumber = eIntern.IdNumber,
                TimeIn = eIntern.TimeIn,
                TimeOut = eIntern.TimeOut,
                CreatedBy = eIntern.CreatedBy,
                UpdatedBy = eIntern.UpdatedBy
            };
            return returnIntern;
        }

        public void CreateFolder()
        {
            var date = DateTime.Now.ToString("MMMM dd, yyyy");
            if (!Directory.Exists(@"C:\AndersonLogbookFiles\Intern\" + DateTime.Now.ToString("MMMM dd, yyyy")))
            {
                Directory.CreateDirectory(@"C:\AndersonLogbookFiles\Intern\" + DateTime.Now.ToString("MMMM dd, yyyy") + @"\InternPictures");
                Directory.CreateDirectory(@"C:\AndersonLogbookFiles\Intern\" + DateTime.Now.ToString("MMMM dd, yyyy") + @"\InternDetails");
            }
            else if (date != DateTime.Now.ToString("MMMM dd, yyyy"))
            {
                Directory.CreateDirectory(@"C:\AndersonLogbookFiles\Intern\" + DateTime.Now.ToString("MMMM dd, yyyy") + @"\InternPictures");
                Directory.CreateDirectory(@"C:\AndersonLogbookFiles\Intern\" + DateTime.Now.ToString("MMMM dd, yyyy") + @"\InternDetails");
            }
            else
            {
            }
        }
        #endregion
    }
}
