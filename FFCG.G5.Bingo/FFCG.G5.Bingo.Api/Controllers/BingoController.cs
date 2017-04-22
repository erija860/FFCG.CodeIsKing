using System.Net;
using System.Net.Http;
using System.Web.Http;
using FFCG.G5.Bingo.Domain;

namespace FFCG.G5.Bingo.Api.Controllers
{
    public class BingoController : ApiController
    {
        private readonly BingoCard _bingoCard;

        public BingoController()
        {
            _bingoCard = new BingoCard(5, 3);
        }

        // POST
        [Route("api/bingogame/newround")]
        public HttpResponseMessage Post()
        {
            return Request.CreateResponse(HttpStatusCode.Accepted, _bingoCard.DrawNewRound());
        }

        // Get
        [Route("api/bingogame/isbingo")]
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.Accepted, _bingoCard.IsBingo());
        }
    }
}