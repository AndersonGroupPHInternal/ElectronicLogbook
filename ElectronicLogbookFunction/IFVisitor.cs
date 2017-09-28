using ElectronicLogbookModel;
using System.Collections.Generic;

namespace ElectronicLogbookFunction
{
    public interface IFVisitor
    {
        #region CREATE
        Visitor Create(Visitor visitor);
        #endregion

        #region RETRIEVE
        Visitor Read(int visitorId);
        List<Visitor> List();
        #endregion

        #region UPDATE
        Visitor Update(Visitor visitor);
        #endregion

        #region DELETE
        void Delete(Visitor visitor);
        #endregion
    }
}
