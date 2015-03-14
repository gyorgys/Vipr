using System;

namespace Microsoft.OneDrive.RestProxy
{
    public class BatchElementResult : IBatchElementResult
    {
        public BatchElementResult(IPagedCollection successResult)
        {
            SuccessResult = successResult;
        }

        public BatchElementResult(Exception failureResult)
        {
            FailureResult = failureResult;
        }

        public IPagedCollection SuccessResult
        {
            get;
            private set;
        }

        public Exception FailureResult
        {
            get;
            private set;
        }
    }
}