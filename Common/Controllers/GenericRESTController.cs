using System.Web.Http;
using Common.Services.Contracts;

namespace Common.Controllers
{
    public class GenericRESTController<TRequestDto,TResponseDto>:BaseApiController
    {
        public GenericRESTController(IGenericRESTService<TRequestDto, TResponseDto> genericRESTService)
        {
            this.genericRESTService = genericRESTService;
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Add([FromBody]TRequestDto requestDto)
        {
            var responseDto = this.genericRESTService.Add(requestDto);

            return Ok();
        }

        [HttpGet]
        [Route("/{id}")]
        public IHttpActionResult GetById([FromUri]int id)
        {
            var responseDto = this.genericRESTService.GetById(id);

            return Ok(responseDto);
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get()
        {
            var responseDto = this.genericRESTService.GetAll();

            return Ok(responseDto);
        }

        protected IGenericRESTService<TRequestDto, TResponseDto> genericRESTService { get; set; }
    }
}
