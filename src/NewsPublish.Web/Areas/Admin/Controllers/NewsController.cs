using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsPublish.Model.Entity;
using NewsPublish.Model.Request;
using NewsPublish.Model.Response;
using NewsPublish.Service;

namespace NewsPublish.Web.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class NewsController : Controller
    {

        private NewsService _newsService;
        private IHostingEnvironment _host;
        public NewsController(NewsService newsService, IHostingEnvironment host)
        {
            this._newsService = newsService;
            this._host = host;
        }

        public ActionResult Index()
        {
            var newClassifys = _newsService.GetNewsClassifyList();
            return View(newClassifys);
        }

        [HttpGet]
        public JsonResult GetNews(int pageIndex, int pageSize, int classifyId, string keyword)
        {
            List<Expression<Func<News, bool>>> wheres = new List<Expression<Func<News, bool>>>();
            if (classifyId > 0)
            {
                wheres.Add(c => c.NewsClassifyId == classifyId);
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                wheres.Add(c => c.Title.Contains(keyword));
            }
            int total = 0;
            var news = _newsService.NewsPageQuery(pageSize, pageIndex, out total, wheres);
            return Json(new { total = total, data = news.data });
        }



        #region 新闻类别
        public ActionResult NewsClassify()
        {
            var newsClassifys = _newsService.GetNewsClassifyList();
            return View(newsClassifys);
        }

        public IActionResult NewsClassifyAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewsClassifyAdd(AddNewsClassify newsClassify)
        {
            if (string.IsNullOrEmpty(newsClassify.Name))
                return Json(new ResponseModel { code = 0, result = "请输入新闻类别名称" });
            return Json(_newsService.AddNewsClassify(newsClassify));
        }

        public ActionResult NewsClassifyEdit(int id)
        {
            return View(_newsService.GetOneNewsClassify(id));
        }
        [HttpPost]
        public JsonResult NewsClassifyEdit(EditNewsClassify newsClassify)
        {
            if (string.IsNullOrEmpty(newsClassify.Name))
                return Json(new ResponseModel { code = 0, result = "请输入新闻类别名称" });
            return Json(_newsService.EditNewsClassify(newsClassify));
        } 
        #endregion
    }
}