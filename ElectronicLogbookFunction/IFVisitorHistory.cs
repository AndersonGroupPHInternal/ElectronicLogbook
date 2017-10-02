using ElectronicLogbookModel;
using System.Collections.Generic;

namespace ElectronicLogbookFunction
{
    public interface IFVisitorHistory
    {
        #region CREATE
        VisitorHistory Create(VisitorHistory visitorHistory);
        #endregion

        #region RETRIEVE
        VisitorHistory Read(int visitorHistoryId);
        List<VisitorHistory> List();
        #endregion

        #region UPDATE
        VisitorHistory Update(VisitorHistory visitorHistory);
        #endregion

        #region DELETE
        void Delete(VisitorHistory visitorHistory);
        #endregion
    }
}
