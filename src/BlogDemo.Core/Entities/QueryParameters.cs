/// ***********************************************************************
///
/// =================================
/// CLR版本	：4.0.30319.42000
/// 命名空间	：BlogDemo.Core.Entities
/// 文件名称	：QueryParameters.cs
/// =================================
/// 创 建 者	：wyt
/// 创建日期	：2019/1/8 20:03:05 
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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using BlogDemo.Core.Interfaces;

namespace BlogDemo.Core.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class QueryParameters : INotifyPropertyChanged
    {
        private const int DefaultPageSize = 10;
        private const int DefaultMaxPageSize = 100;

        private int _pageIndex;

        public int PageIndex
        {
            get => _pageIndex;
            set => _pageIndex = value>=0?value:0;
        }

        private int _pageSize=DefaultPageSize;

        public int PageSize
        {
            get => _pageSize;
            set => SetField(ref _pageSize,value);
        }

        private string _orderBy= nameof(IEntity.Id);

        public string OrderBy
        {
            get => _orderBy;
            set => _orderBy = value??nameof(IEntity.Id);
        }

        private int _maxPageSize= DefaultMaxPageSize;
        public virtual int MaxPageSize
        {
            get => _maxPageSize;
            set => SetField(ref _maxPageSize,value);
        }

        public string Fields { get; set; }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field,value))
            {
                return false;
            }

            field = value;
            OnPropertyChanged(propertyName);
            if (propertyName==nameof(PageSize)||propertyName==nameof(MaxPageSize))
            {
                SetPageSize();
            }

            return true;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this,new  PropertyChangedEventArgs(propertyName));
        }

        private void SetPageSize()
        {
            if (_maxPageSize<=0)
            {
                _maxPageSize = DefaultMaxPageSize;
            }
            if (_pageSize <= 0)
            {
                _pageSize = DefaultPageSize;
            }
            _pageSize = _pageSize > _maxPageSize ? _maxPageSize : _pageSize;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
