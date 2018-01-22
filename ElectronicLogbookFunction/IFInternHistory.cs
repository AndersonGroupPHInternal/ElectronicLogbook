using ElectronicLogbookModel;
using System.Collections.Generic;

namespace ElectronicLogbookFunction
{
    public interface IFInternHistory
    {
        #region CREATE
        InternHistory Create(InternHistory internHistory);
        #endregion
        #region RETRIEVE
        InternHistory Read(int internHistoryId);
        List<InternHistory> List();
        #endregion
        #region UPDATE
        InternHistory Update(InternHistory internHistory);
        #endregion
        #region DELETE
        void Delete(InternHistory internHistory);
        #endregion
    }
}
