/// ***********************************************************************
///
/// =================================
/// CLR版本	：4.0.30319.42000
/// 命名空间	：BlogDemo.Infrastructure.Database
/// 文件名称	：MyContextSeed.cs
/// =================================
/// 创 建 者	：wyt
/// 创建日期	：2019/1/7 10:45:56 
/// 邮箱		：786744873@qq.com
/// 个人主站	：https://www.cnblogs.com/wyt007/
///
/// 功能描述	：
/// 使用说明	：
/// =================================
/// 修改者	：
/// 修改日期	：
/// 修改内容	：
/// =================================
///
/// ***********************************************************************


using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BlogDemo.Core.Entities;
using Microsoft.Extensions.Logging;
using  System.Linq;

namespace BlogDemo.Infrastructure.Database
{
    /// <summary>
    /// 
    /// <see cref="MyContextSeed" langword="" />
    /// </summary>
    public class MyContextSeed
    {
        public static async Task SeedAsync(MyContext myContext, ILoggerFactory loggerFactory, int retry = 0)
        {
            int retryForAvailability = retry;
            try
            {
                // TODO: Only run this if using a real database
                // myContext.Database.Migrate();

                if (!myContext.Posts.Any())
                {
                    myContext.Posts.AddRange(
                        new List<Post>{
                            new Post{
                                Title = "Post Title 1",
                                Body = "Post Body 1",
                                Author = "Dave",
                                LastModified = DateTime.Now
                            },
                            new Post{
                                Title = "Post Title 2",
                                Body = "Post Body 2",
                                Author = "Dave",
                                LastModified = DateTime.Now
                            },
                            new Post{
                                Title = "Post Title 3",
                                Body = "Post Body 3",
                                Author = "Dave",
                                LastModified = DateTime.Now
                            },
                            new Post{
                                Title = "Post Title 4",
                                Body = "Post Body 4",
                                Author = "Dave",
                                LastModified = DateTime.Now
                            },
                            new Post{
                                Title = "Post Title 5",
                                Body = "Post Body 5",
                                Author = "Dave",
                                LastModified = DateTime.Now
                            },
                            new Post{
                                Title = "Post Title 6",
                                Body = "Post Body 6",
                                Author = "Dave",
                                LastModified = DateTime.Now
                            },
                            new Post{
                                Title = "Post Title 7",
                                Body = "Post Body 7",
                                Author = "Dave",
                                LastModified = DateTime.Now
                            },
                            new Post{
                                Title = "Post Title 8",
                                Body = "Post Body 8",
                                Author = "Dave",
                                LastModified = DateTime.Now
                            }
                        }
                    );
                    await myContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var logger = loggerFactory.CreateLogger<MyContextSeed>();
                    logger.LogError(ex.Message);
                    await SeedAsync(myContext, loggerFactory, retryForAvailability);
                }
            }
        }
    }
}
