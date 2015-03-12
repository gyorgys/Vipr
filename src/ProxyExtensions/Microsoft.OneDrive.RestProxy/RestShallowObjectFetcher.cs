using System;

namespace Microsoft.OneDrive.RestProxy
{
    public class RestShallowObjectFetcher : IEntityFetcherBase
    {
        private string _path;
        private DataServiceContextWrapper _context;

        private bool _isInitialized;

        public new DataServiceContextWrapper Context
        {
            get
            {
                return _context;
            }
            private set
            {
                _context = value;
            }
        }

        public RestShallowObjectFetcher() { }

        public void Initialize(
            DataServiceContextWrapper context,
            string path)
        {
            Context = context;
            _path = path;
            _isInitialized = true;
        }

        protected string GetPath(string propertyName)
        {
            ThrowIfNotInitialized();

            return propertyName == null ? this._path : this._path + "/" + propertyName;
        }

        public System.Uri GetUrl()
        {
            ThrowIfNotInitialized();

            return new Uri(Context.BaseUri.ToString().TrimEnd('/') + "/" + GetPath(null));
        }

        protected IReadOnlyQueryableSet<TIInstance> CreateQuery<TInstance, TIInstance>()
            where TInstance : EntityBase, TIInstance
        {
            ThrowIfNotInitialized();

            return new ReadOnlyQueryableSet<TIInstance>(this.Context.CreateQuery<TInstance>(this.GetPath(null)), this.Context);
        }

        private void ThrowIfNotInitialized()
        {
            if (!_isInitialized)
                throw new InvalidOperationException("Initialize must be called before invoking this operation.");
        }

        /// <param name=""dontSave"">true to delay saving until batch is saved; false to save immediately.</param>
        global::System.Threading.Tasks.Task IEntityFetcherBase.UpdateAsync(bool dontSave = false)
        {
            if (Context == null) throw new InvalidOperationException("Not Initialized");
            Context.UpdateObject(this);
            return SaveAsNeeded(dontSave);
        }

        /// <param name=""dontSave"">true to delay saving until batch is saved; false to save immediately.</param>
        global::System.Threading.Tasks.Task IEntityFetcherBase.DeleteAsync(bool dontSave = false)
        {
            if (Context == null) throw new InvalidOperationException("Not Initialized");
            Context.DeleteObject(this);
            return SaveAsNeeded(dontSave);
        }

        /// <param name=""dontSave"">true to delay saving until batch is saved; false to save immediately.</param>
        public global::System.Threading.Tasks.Task SaveAsNeeded(bool dontSave)
        {
            if (!dontSave)
            {
                return Context.SaveChangesAsync();
            }
            else
            {
                var retVal = new global::System.Threading.Tasks.TaskCompletionSource<object>();
                retVal.SetResult(null);
                return retVal.Task;
            }
        }
    }
}