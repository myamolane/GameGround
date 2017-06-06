using GameGround.Core;
using GameGround.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GameGround.Api.Controllers
{
    [Authorize]
    [RoutePrefix("api/game")]
    public class GameController : ApiController
    {
        private readonly IGameService _service;

        public GameController(IGameService service)
        {
            _service = service;
        }
        [Authorize]
        [HttpPost, Route("search")]
        public SearchMetadata<VmGame> Search(VmGameSearch condition)
        {
            var total = 0L;
            var games = this._service.SearchGame(condition, out total);

            return new SearchMetadata<VmGame>(games, total);
        }

        [HttpPost,Route("add")]
        public Metadata Add(VmGame model)
        {
            long id=this.GetUserId();
            model.AuthorId = id;
            this._service.AddGame(model);
            return new Metadata(id.ToString());
        }
        [HttpGet]
        public Metadata GetId()
        {
            long id = this.GetUserId();
            return new Metadata(id.ToString());
        }
    }
}
