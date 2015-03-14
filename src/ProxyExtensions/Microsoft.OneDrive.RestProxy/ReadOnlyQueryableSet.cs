
namespace Microsoft.OneDrive.RestProxy
{
    public class ReadOnlyQueryableSet<TSource> : ReadOnlyQueryableSetBase<TSource>, IReadOnlyQueryableSet<TSource>
    {
        public ReadOnlyQueryableSet(
            Query inner,
            DataServiceContextWrapper context)
            : base(inner, context)
        {
        }


        public global::System.Threading.Tasks.Task<IPagedCollection<TSource>> ExecuteAsync()
        {
            return base.ExecuteAsyncpublic();
        }

        public global::System.Threading.Tasks.Task<TSource> ExecuteSingleAsync()
        {
            return base.ExecuteSingleAsyncpublic();
        }
    }
}