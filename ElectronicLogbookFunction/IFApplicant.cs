using ElectronicLogbookModel;
using System.Collections.Generic;

namespace ElectronicLogbookFunction
{
    public interface IFApplicant
    {
        #region CREATE
        Applicant Create(Applicant applicant);
        #endregion
        #region RETRIEVE
        Applicant Read(int applicantId);
        List<Applicant> List();
        #endregion
        #region UPDATE
        Applicant Update(Applicant applicant);
        #endregion
        #region DELETE
        void Delete(Applicant applicant);
        #endregion
        #region CREATEFOLDER
        void CreateFolder();
        #endregion
    }
}
