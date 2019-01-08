/// ***********************************************************************
///
/// =================================
/// CLR版本	：4.0.30319.42000
/// 命名空间	：BlogDemo.Core.Entities
/// 文件名称	：PaginatedList.cs
/// =================================
/// 创 建 者	：wyt
/// 创建日期	：2019/1/8 20:35:46 
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

namespace BlogDemo.Core.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class PaginatedList<T>:List<T> where T:class 
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }

        private int _totalItemsCount;
        public int TotalItemsCount
        {
            get => _totalItemsCount;
            set => _totalItemsCount = value >= 0 ? value : 0;
        }

        public int PageCount => TotalItemsCount / PageSize + (TotalItemsCount % PageSize > 0 ? 1 : 0);

        public bool HasPrevious => PageIndex > 0;
        public bool HasNext => PageIndex < PageCount - 1;

        public PaginatedList(int pageIndex, int pageSize, int totalItemsCount, IEnumerable<T> data)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalItemsCount = totalItemsCount;
            AddRange(data);
        }
    }
}
