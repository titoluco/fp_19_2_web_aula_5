using CodeHollow.FeedReader;
using Fiap.Core.Models;
using Microsoft.Extensions.Caching.Memory;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.Core.Services
{
    public class NoticiaService : INoticiaService
    {
        private IMemoryCache _memoryCache;
        //private IMemcachedClient _memoryCache;

        public NoticiaService(IMemoryCache memoryCache)
        //public NoticiaService(IMemcachedClient memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public List<Noticia> Load()
        {
            var key = "noticias";

            //var noticias = _memoryCache.Get(key) as List<Noticia>;


            //if (noticias == null)
            if (!_memoryCache.TryGetValue(key, out List<Noticia> noticias))
            {
                noticias = new List<Noticia>();

                var feed = FeedReader.ReadAsync("https://g1.globo.com/rss/g1/turismo-e-viagem/").Result;

                foreach (var item in feed.Items)
                {
                    var feedItem = item.SpecificItem as CodeHollow.FeedReader.Feeds.MediaRssFeedItem;
                    var media = feedItem.Media;
                    var url = "";
                    if (media.Any())
                        url = media.FirstOrDefault().Url;
                    noticias.Add(new Noticia() { Id = 1, Titulo = item.Title, Link = item.Link, Imagem = url });
                }


                var cacheOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(DateTime.Now.AddMinutes(10));
                //var cacheOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(new TimeSpan(0,1,0));

                _memoryCache.Set(key, noticias, cacheOptions);

                //_memoryCache.SetAsync(key, noticias, 60).Wait();

            }

            return noticias;
        }

    }
}
