using BLL;
using BLL.BEnt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NewsPortal.Controllers
{
    public class UserController : ApiController
    {
        [Route("api/User/getAllNews")]
        [HttpGet]
        public List<NewsWithInfoModel> getAllNews()
        {
            return NewsService.getAllNews();
        }

        [Route("api/User/AddComment")]
        [HttpPost]
        public void Add(CommentModel n)
        {
            NewsService.AddComment(n);
        }

        [Route("api/User/AddReact")]
        [HttpPost]
        public void AddReact(ReactModel r)
        {
            NewsService.AddReact(r);
        }
    }
}
