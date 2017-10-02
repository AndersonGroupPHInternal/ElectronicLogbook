using ElectronicLogbookModel;
using ElectronicLogbookData;
using ElectronicLogbookEntity;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;

namespace ElectronicLogbookFunction
{
    public class FApplicant : IFApplicant
    {
        private IDApplicant _iDApplicant;

        public FApplicant()
        {
            _iDApplicant = new DApplicant();
        }

        #region CREATE
        public Applicant Create(Applicant applicant)
        {
            EApplicant eApplicant = EApplicant(applicant);
            eApplicant = _iDApplicant.Create(eApplicant);

            //EApplicantHistory eApplicantHistory = new EApplicantHistory
            //{
            //    ApplicantID = eApplicant.ApplicantID,
            //    Date = eApplicant.Date,
            //    Name = eApplicant.Name,
            //    Purpose = eApplicant.Purpose,
            //    TimeIn = eApplicant.TimeIn,
            //    TimeOut = eApplicant.TimeOut
            //};
            //_iDApplicant.Create(eApplicantHistory);
            return (Applicant(eApplicant));
        }
        #endregion

        #region READ
        public Applicant Read(int applicantId)
        {
            EApplicant eApplicant = _iDApplicant.Read<EApplicant>(a => a.ApplicantID == applicantId);
            return Applicant(eApplicant);
        }

        public List<Applicant> List()
        {
            List<EApplicant> eApplicants = _iDApplicant.List<EApplicant>(a => true);
            return Applicants(eApplicants);
        }
        #endregion

        #region UPDATE
        public Applicant Update(Applicant applicant)
        {
            EApplicant currentApplicant = _iDApplicant.Read<EApplicant>(a => a.ApplicantID == applicant.ApplicantID);
            var eApplicant = _iDApplicant.Update(EApplicant(applicant));
            //if (applicant.ApplicantID == currentApplicant.ApplicantID)
            //{
            //    EApplicantHistory eApplicantHistory = new EApplicantHistory
            //    {
            //        ApplicantID = eApplicant.ApplicantID,
            //        Date = eApplicant.Date,
            //        Name = eApplicant.Name,
            //        ApplyingFor = eApplicant.ApplyingFor,
            //        Designation = eApplicant.Designation,
            //        TypeOfId = eApplicant.TypeOfId,
            //        IdNumber = eApplicant.IdNumber,
            //        TimeIn = eApplicant.TimeIn,
            //        TimeOut = eApplicant.TimeOut,
            //        Comment = eApplicant.Comment
            //    };
            //    _iDApplicant.Create(eApplicantHistory);
            //}
            return (Applicant(eApplicant));
        }
        #endregion

        #region DELETE
        public void Delete(Applicant applicant)
        {
            _iDApplicant.Delete(EApplicant(applicant));
        }
        #endregion

        #region OTHER FUNCTION
        private List<Applicant> Applicants(List<EApplicant> eApplicants)
        {
            var returnApplicants = eApplicants.Select(a => new Applicant
            {
                ApplicantID = a.ApplicantID,
                Date = a.Date,
                Name = a.Name,
                ApplyingFor = a.ApplyingFor,
                Designation = a.Designation,
                TypeOfId = a.TypeOfId,
                IdNumber = a.IdNumber,
                TimeIn = a.TimeIn,
                TimeOut = a.TimeOut,
                Comment = a.Comment,
                CreatedBy = a.CreatedBy,
                UpdatedBy = a.UpdatedBy
            });

            return returnApplicants.ToList();
        }

        private EApplicant EApplicant(Applicant applicant)
        {
            EApplicant returnEApplicant = new EApplicant
            {
                ApplicantID = applicant.ApplicantID,
                Date = applicant.Date,
                Name = applicant.Name,
                ApplyingFor = applicant.ApplyingFor,
                Designation = applicant.Designation,
                TypeOfId = applicant.TypeOfId,
                IdNumber = applicant.IdNumber,
                TimeIn = applicant.TimeIn,
                TimeOut = applicant.TimeOut,
                Comment = applicant.Comment,
                CreatedBy = applicant.CreatedBy,
                UpdatedBy = applicant.UpdatedBy
            };
            return returnEApplicant;
        }

        private Applicant Applicant(EApplicant eApplicant)
        {
            Applicant returnApplicant = new Applicant
            {
                ApplicantID = eApplicant.ApplicantID,
                Date = eApplicant.Date,
                Name = eApplicant.Name,
                ApplyingFor = eApplicant.ApplyingFor,
                Designation = eApplicant.Designation,
                TypeOfId = eApplicant.TypeOfId,
                IdNumber = eApplicant.IdNumber,
                TimeIn = eApplicant.TimeIn,
                TimeOut = eApplicant.TimeOut,
                Comment = eApplicant.Comment,
                CreatedBy = eApplicant.CreatedBy,
                UpdatedBy = eApplicant.UpdatedBy
            };
            return returnApplicant;
        }

        public void CreateFolder()
        {
            var date = DateTime.Now.ToString("MMMM dd, yyyy");
            if (!Directory.Exists(@"C:\AndersonLogbookFiles\Applicant\" + DateTime.Now.ToString("MMMM dd, yyyy")))
            {
                Directory.CreateDirectory(@"C:\AndersonLogbookFiles\Applicant\" + DateTime.Now.ToString("MMMM dd, yyyy") + @"\ApplicantIDCard");
                Directory.CreateDirectory(@"C:\AndersonLogbookFiles\Applicant\" + DateTime.Now.ToString("MMMM dd, yyyy") + @"\ApplicantPictures");
                Directory.CreateDirectory(@"C:\AndersonLogbookFiles\Applicant\" + DateTime.Now.ToString("MMMM dd, yyyy") + @"\ApplicantDetails");
            }
            else if (date != DateTime.Now.ToString("MMMM dd, yyyy"))
            {
                Directory.CreateDirectory(@"C:\AndersonLogbookFiles\Applicant\" + DateTime.Now.ToString("MMMM dd, yyyy") + @"\ApplicantIDCard");
                Directory.CreateDirectory(@"C:\AndersonLogbookFiles\Applicant\" + DateTime.Now.ToString("MMMM dd, yyyy") + @"\ApplicantPictures");
                Directory.CreateDirectory(@"C:\AndersonLogbookFiles\Applicant\" + DateTime.Now.ToString("MMMM dd, yyyy") + @"\ApplicantDetails");
            }
            else
            {
            }
        }
        #endregion
    }
}
