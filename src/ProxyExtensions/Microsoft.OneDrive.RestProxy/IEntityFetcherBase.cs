using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.OneDrive.RestProxy
{
    public interface IEntityFetcherBase
    {
        /// <param name=""dontSave"">true to delay saving until batch is saved; false to save immediately.</param>
        global::System.Threading.Tasks.Task UpdateAsync(bool dontSave = false);
        /// <param name=""dontSave"">true to delay saving until batch is saved; false to save immediately.</param>
        global::System.Threading.Tasks.Task DeleteAsync(bool dontSave = false);

    }
}
