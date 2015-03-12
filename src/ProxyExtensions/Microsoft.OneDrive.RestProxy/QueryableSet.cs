using System;
using System.Linq;
using System.Linq.Expressions;

namespace Microsoft.OneDrive.RestProxy
{
    public class QueryableSet<TSource> : ReadOnlyQueryableSetBase<TSource>
    {
        protected string _path;
        protected object _entity;

        public void SetContainer(Func<EntityBase> entity, string property)
        {
            // Unneeded
        }

        protected System.Uri GetUrl()
        {
            return new Uri(Context.BaseUri.ToString().TrimEnd('/') + "/" + _path);
        }


        public QueryableSet(
            Query inner,
            DataServiceContextWrapper context,
            EntityBase entity,
            string path)
            : base(inner, context)
        {
            Initialize(inner, context, entity, path);
        }

        public void Initialize(Query inner,
            DataServiceContextWrapper context,
            EntityBase entity,
            string path)
        {
            base.Initialize(inner, context);
            _path = path;
            _entity = entity;
        }
    }
}