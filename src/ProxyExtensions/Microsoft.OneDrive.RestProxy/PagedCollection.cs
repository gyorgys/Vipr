using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.OneDrive.RestProxy
{
    public class PagedCollection<TElement, TConcrete> : IPagedCollection, IPagedCollection<TElement> where TConcrete : TElement
    {
        private DataServiceContextWrapper _context;
        private string _continuationToken;
        private IReadOnlyList<TElement> _currentPage;
        private object p;

        // Creator - should be faster than Activator.CreateInstance
        public static PagedCollection<TElement, TConcrete> Create(DataServiceContextWrapper context,
            QueryOperationResponse<TConcrete> qor)
        {
            return new PagedCollection<TElement, TConcrete>(context, qor);
        }

        public PagedCollection(DataServiceContextWrapper context,
            QueryOperationResponse<TConcrete> qor)
        {
            _context = context;
            _currentPage = (IReadOnlyList<TElement>)qor.ToList();
            _continuationToken = qor.GetContinuationToken();
        }

        public PagedCollection(DataServiceContextWrapper context, Collection<TConcrete> collection)
        {
            _context = context;
            _currentPage = (IReadOnlyList<TElement>)collection;
            if (_currentPage != null)
            {
                _continuationToken = collection.ContinuationToken;
            }
        }

        public PagedCollection(DataServiceContextWrapper _context, object p)
        {
            // TODO: Complete member initialization
            this._context = _context;
            this.p = p;
        }

        public bool MorePagesAvailable
        {
            get
            {
                return _continuationToken != null;
            }
        }

        public System.Collections.Generic.IReadOnlyList<TElement> CurrentPage
        {
            get
            {
                return _currentPage;
            }
        }

        public async Task<IPagedCollection<TElement>> GetNextPageAsync()
        {
            if (_continuationToken != null)
            {
                var task = _context.ExecuteAsync<TConcrete, TElement>(_continuationToken);

                return null; // new PagedCollection<TElement, TConcrete>(_context, await task);
            }

            return (IPagedCollection<TElement>)null;
        }

        IReadOnlyList<object> IPagedCollection.CurrentPage
        {
            get { return (IReadOnlyList<object>)this.CurrentPage; }
        }

        async System.Threading.Tasks.Task<IPagedCollection> IPagedCollection.GetNextPageAsync()
        {
            var retval = await GetNextPageAsync();

            return (PagedCollection<TElement, TConcrete>)retval;
        }
    }
}