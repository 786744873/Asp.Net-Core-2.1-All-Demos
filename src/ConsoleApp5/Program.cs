using System;
using System.Text;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.MongoDB;
using Microsoft.Extensions.Caching.Redis;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Redis
            {
                RedisCache redisCache = new RedisCache(new RedisCacheOptions()
                {
                    Configuration = "127.0.0.1:6379",
                    InstanceName = "test"
                });

                //在Redis中是以Hash的模式存放的
                redisCache.SetString("username", "jack", new DistributedCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddDays(1),
                });

                var info = redisCache.GetString("username");

                Console.WriteLine(info);
            }

            //MongoDB
            {
                MongoDBCache mongoDBCache = new MongoDBCache(new MongoDBCacheOptions()
                {
                    ConnectionString = "mongodb://127.0.0.1:27017",
                    DatabaseName = "mydb",
                    CollectionName = "mytest"
                });

                mongoDBCache.Set("username", Encoding.UTF8.GetBytes("jack"), new DistributedCacheEntryOptions {
                    AbsoluteExpiration = DateTime.Now.AddDays(1)
                });

                var info= Encoding.UTF8.GetString(mongoDBCache.Get("username"));
                Console.WriteLine(info);
            }


        }
    }
}
