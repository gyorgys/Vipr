using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Microsoft.OneDrive.RestProxy
{
    public partial class DataServiceContextWrapper
    {
        private object _syncLock = new object();
        private string _accessToken;
        private global::System.Func<Task<string>> _accessTokenGetter;
        private System.Func<System.Threading.Tasks.Task> _accessTokenSetter;
        private HashSet<EntityBase> _modifiedEntities = new HashSet<EntityBase>();

        public Uri BaseUri { get;  }

        public void UpdateObject(EntityBase entity)
        {
        }

        private async Task SetToken()
        {
            var token = await _accessTokenGetter();
            lock (_syncLock)
            {
                _accessToken = token;
            }
        }


        internal Task<IPagedCollection> ExecuteAsync<T1, T2>(Query query)
        {
            throw new NotImplementedException();
        }


        internal Task<T> ExecuteSingleAsync<T1, T2>(Query<T> query)
        {
            throw new NotImplementedException();
        }

        internal Query CreateQuery<T1>(string p)
        {
            throw new NotImplementedException();
        }

        internal void UpdateObject(RestShallowObjectFetcher restShallowObjectFetcher)
        {
            throw new NotImplementedException();
        }

        internal void DeleteObject(RestShallowObjectFetcher restShallowObjectFetcher)
        {
            throw new NotImplementedException();
        }

        internal Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}