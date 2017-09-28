using ElectronicLogbookModel;
using System.Collections.Generic;

namespace ElectronicLogbookFunction
{
    public interface IFIntern
    {
        #region CREATE
        Intern Create(Intern intern);
        #endregion

        #region RETRIEVE
        Intern Read(int internId);
        List<Intern> List();
        #endregion

        #region UPDATE
        Intern Update(Intern intern);
        #endregion

        #region DELETE
        void Delete(Intern intern);
        #endregion
    }
}
