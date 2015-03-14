using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.OneDrive.RestProxy
{
    public class QueryOperationResponse<T>
    {
        public string GetContinuationToken()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<T> ToList()
        {
            throw new NotImplementedException();
        }
    }
}
