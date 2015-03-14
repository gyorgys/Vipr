using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.OneDrive.RestProxy
{
    public class KeyAttribute : Attribute
    {
        private string key;
        public KeyAttribute(string key) { this.key = key;  }
    }
}
