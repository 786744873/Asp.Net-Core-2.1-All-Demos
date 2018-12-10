using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {

            {//cache的最大限度为100


                MemoryCache memoryCache = new MemoryCache(new MemoryCacheOptions()
                {
                    SizeLimit = 100
                });

                for (int i = 0; i < 1000; i++)
                {
                    memoryCache.Set<string>(i.ToString(), i.ToString(), new MemoryCacheEntryOptions()
                    {
                        Size = 1
                    });

                    Console.WriteLine(memoryCache.Count);
                }
            }

            {//被动过期，设置过期回调

                MemoryCache memoryCache = new MemoryCache(new MemoryCacheOptions()
                {

                });

                var cacheOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(3),//3秒过期
                };
                cacheOptions.RegisterPostEvictionCallback((key, value, reason, obj) =>
                {
                    Console.WriteLine(reason);
                    Console.WriteLine("执行过期回调");
                });

                memoryCache.Set("key", "value", cacheOptions);

                Console.WriteLine("3秒后过期将执行回调");
                while (true)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine(memoryCache.Get<string>("key"));
                }
                Console.ReadKey();
            }


            {//主动过期(10秒被动过期，2秒主动使用token让他过期)


                CancellationTokenSource tokenSource = new CancellationTokenSource();
                MemoryCache memoryCache = new MemoryCache(new MemoryCacheOptions()
                {

                });

                var cacheOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(10),//10秒过期
                };
                cacheOptions.AddExpirationToken(new CancellationChangeToken(tokenSource.Token));//加入Token
                cacheOptions.RegisterPostEvictionCallback((key, value, reason, obj) =>
                {
                    Console.WriteLine(reason);
                    Console.WriteLine("执行过期回调");
                });

                memoryCache.Set("key", "value", cacheOptions);

                Console.WriteLine("10秒后过期将执行回调");

                tokenSource.CancelAfter(TimeSpan.FromSeconds(2));
                while (true)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine(memoryCache.Get<string>("key"));
                }
                Console.ReadKey();
            }
        }
    }
}
