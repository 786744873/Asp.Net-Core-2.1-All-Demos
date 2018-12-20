using NewsPublish.Model.Entity;
using NewsPublish.Model.Request;
using NewsPublish.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NewsPublish.Service
{
    public class NewsService
    {
        private Db _db;
        public NewsService(Db db)
        {
            this._db = db;
        }


        /// <summary>
        /// 添加一个新闻类别
        /// </summary>
        public ResponseModel AddNewsClassify(AddNewsClassify newsClassify)
        {
            var exit = _db.NewsClassify.FirstOrDefault(c => c.Name == newsClassify.Name) != null;
            if (exit)
                return new ResponseModel { code = 0, result = "该类别已存在" };
            var classify = new NewsClassify { Name = newsClassify.Name, Sort = newsClassify.Sort, Remark = newsClassify.Remark };
            _db.NewsClassify.Add(classify);
            int i = _db.SaveChanges();
            if (i > 0)
                return new ResponseModel { code = 200, result = "新闻类别添加成功" };
            return new ResponseModel { code = 0, result = "新闻类别添加失败" };
        }

        /// <summary>
        /// 获取一个新闻类别
        /// </summary>
        public ResponseModel GetOneNewsClassify(int id)
        {
            var classify = _db.NewsClassify.Find(id);
            if (classify == null)
                return new ResponseModel { code = 0, result = "该类别不存在" };
            return new ResponseModel
            {
                code = 200,
                result = "新闻类别获取成功",
                data = new NewsClassifyModel
                {
                    Id = classify.Id,
                    Sort = classify.Sort,
                    Name = classify.Name,
                    Remark = classify.Remark
                }
            };
        }

        /// <summary>
        /// 获取一个新闻类别
        /// </summary>
        private NewsClassify GetOneNewsClassify(Expression<Func<NewsClassify, bool>> where)
        {
            return _db.NewsClassify.FirstOrDefault(where);
        }

        /// <summary>
        /// 编辑一个新闻类别
        /// </summary>
        public ResponseModel EditNewsClassify(EditNewsClassify newsClassify)
        {
            var classify = this.GetOneNewsClassify(c => c.Id == newsClassify.Id);
            if (classify == null)
                return new ResponseModel { code = 0, result = "该类别不存在" };
            classify.Name = newsClassify.Name;
            classify.Sort = newsClassify.Sort;
            classify.Remark = newsClassify.Remark;
            _db.NewsClassify.Update(classify);
            int i = _db.SaveChanges();
            if (i > 0)
                return new ResponseModel { code = 200, result = "新闻类别编辑成功" };
            return new ResponseModel { code = 0, result = "新闻类别编辑失败" };
        }

        /// <summary>
        /// 获取新闻类别集合
        /// </summary>
        public ResponseModel GetNewsClassifyList()
        {
            var classifys = _db.NewsClassify.OrderByDescending(c => c.Sort).ToList();
            var response = new ResponseModel { code = 200, result = "新闻类别集合获取成功" };
            response.data = new List<NewsClassifyModel>();
            foreach (var classify in classifys)
            {
                response.data.Add(new NewsClassifyModel
                {
                    Id = classify.Id,
                    Name = classify.Name,
                    Sort = classify.Sort,
                    Remark = classify.Remark
                });
            }
            return response;
        }
    }
}
