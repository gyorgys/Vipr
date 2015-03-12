using System;
using System.Collections.Generic;

namespace Microsoft.OneDrive.RestProxy
{
    public class EntityBase
    {
        private Lazy<HashSet<string>> _changedProperties = new Lazy<HashSet<string>>(true);

        public Lazy<HashSet<string>> ChangedProperties
        {
            get { return _changedProperties; }
        }

        protected Tuple<EntityBase, string> GetContainingEntity(string propertyName)
        {
            return new Tuple<EntityBase, string>(this, propertyName);
        }

        public virtual void OnPropertyChanged([global::System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            _changedProperties.Value.Add(propertyName);
        }

        public void ResetChanges()
        {
            _changedProperties = new Lazy<HashSet<string>>(true);
        }

        public void Initialize()
        {
        }

    }
}