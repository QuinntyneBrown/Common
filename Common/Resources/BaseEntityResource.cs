using System.Collections.Generic;
using Common.Caching;
using Common.Caching.Contracts;
using Common.Dtos;
using Common.Http;
using Common.Resources.Contracts;

namespace Common.Resources
{
    public class BaseEntityResource<T> : IEntityResource<T>
    {
        public BaseEntityResource(string baseUri, ICacheProvider cacheProvider)
        {            
            this.baseUri = baseUri;
            this.cache = cacheProvider.GetCache();
        }

        public BaseEntityResource(string baseUri)
        {
            this.baseUri = baseUri;
            this.cache = new CacheProvider().GetCache();
        }

        public T GetById(int? id, string authorizationScheme = null, string authorizationToken = null)
        {
            return FromResourceOrCache<T>(string.Format("{0}/getById?id={1}", baseUri, id), authorizationScheme, authorizationToken);
        }

        public ICollection<T> GetAll(string authorizationScheme = null, string authorizationToken = null)
        {
            return FromResourceOrCache<ICollection<T>>(string.Format("{0}/getByAll", baseUri), authorizationScheme, authorizationToken);
        }

        public PagedResultDto<T> GetPage(int setSize, int offSet, string authorizationScheme = null, string authorizationToken = null)
        {
            return FromResourceOrCache<PagedResultDto<T>>(string.Format("{0}/getPage/setSize={1}&offSet={2}", baseUri, setSize, offSet),authorizationScheme,authorizationToken);
        }

        public TResult FromResourceOrCache<TResult>(string uri, string authorizationScheme = null, string authorizationToken = null)
        {
            var key = string.Format("{0}{1}{2}", uri, authorizationScheme, authorizationToken);

            var cached = cache.Get(key);

            if (cached == null)
            {
                cached = HttpClientHelper.Get<TResult>(uri);
                cache.Add(cached, key);
            }

            return (TResult)cached;

        }

        protected string baseUri { get; set; }

        protected ICache cache { get; set; }

        
    }
}
