using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.OneDrive.RestProxy
{
    public class QueryOperationResponse<T>
    {
        internal string GetContinuationToken()
        {
            throw new NotImplementedException();
        }

        internal IReadOnlyList<T> ToList()
        {
            throw new NotImplementedException();
        }
    }
}
