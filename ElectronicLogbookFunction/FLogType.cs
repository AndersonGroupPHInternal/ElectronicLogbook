using ElectronicLogbookModel;
using ElectronicLogbookData;
using ElectronicLogbookEntity;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ElectronicLogbookFunction
{
    public class FLogType : IFLogType
    {
        private IDLogType _iDLogType;

        public FLogType()
        {
            _iDLogType = new DLogType();
        }

        #region READ
        public List<LogType> Read()
        {
            List<ELogType> eLogTypes = _iDLogType.List<ELogType>(a => true);
            return LogTypes(eLogTypes);
        }
        #endregion

        #region OTHER FUNCTION
        private List<LogType> LogTypes(List<ELogType> eLogTypes)
        {
            var returnLogType = eLogTypes.Select(a => new LogType
            {
                LogTypeId = a.LogTypeId,

                Name = a.Name
            });
            return returnLogType.ToList();
        }
        #endregion
    }
}
