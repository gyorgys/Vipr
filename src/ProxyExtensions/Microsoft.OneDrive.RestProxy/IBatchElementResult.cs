using System;

namespace Microsoft.OneDrive.RestProxy
{
    public interface IBatchElementResult
    {
        IPagedCollection SuccessResult { get; }
        Exception FailureResult { get; }
    }
}