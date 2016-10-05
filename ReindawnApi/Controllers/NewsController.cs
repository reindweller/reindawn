using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.AspNet.Identity;
using Reindawn.Domain.Models;
using Reindawn.Repository;
using Reindawn.Service;
using Reindawn.Utilities.Extensions;
using ReindawnApi.Models;

namespace ReindawnApi.Controllers
{
    [RoutePrefix("api/news")]
    public class NewsController : ApiController
    {

        public IEnumerable<NewsViewModel> GetAllNews()
        {
            var newsService = new NewsService(new UnitOfWork());
            List<NewsViewModel> newsList = new List<NewsViewModel>();
            foreach (var news in newsService.GetAll())
            {
                newsList.Add(news.Convert<News, NewsViewModel>());
            }

            return newsList;
        }


        [Route("postnews")]
        [HttpPost]
        //[ResponseType(typeof(RegisterViewModel))]
        public IHttpActionResult PostNews([FromBody]NewsViewModel model)
        {

            if (ModelState.IsValid)
            {
                

                var newsService = new NewsService(new UnitOfWork());
                var news = model.Convert<NewsViewModel, News>();
                newsService.Insert(news);
                newsService.Save();
                return Ok();
            }

            List<string> errors =
                (from modelState in ModelState.Values from error in modelState.Errors select error.ErrorMessage).ToList();
            return new ResponseMessageResult(
                Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    string.Join(";", errors)));

        }
    }
}
