using System;

namespace Microsoft.OneDrive.RestProxy
{
    public class ComplexTypeBase
    {
        private Func<Tuple<EntityBase, string>> _entity;

        protected ComplexTypeBase()
        {
        }

        public virtual void SetContainer(Func<Tuple<EntityBase, string>> entity)
        {
            _entity = entity;
        }

        protected Tuple<EntityBase, string> GetContainingEntity(string propertyName)
        {
            return _entity != null ? _entity() : null;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            var tuple = GetContainingEntity(propertyName);

            if (tuple != null)
            {
                tuple.Item1.OnPropertyChanged(tuple.Item2);
            }
        }
    }
}