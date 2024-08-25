using System.Collections.Generic;

namespace BajajFinservTest.Repositories
{
        public interface IDataRepository
        {
            Dictionary<string, object> ProcessData(List<string> data);
            Dictionary<string, int> GetOperationCode();
        }
    }
