using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using Common.Data.Contracts;
using Common.Dtos;

namespace Common.Controllers
{
    public abstract class EFController<T>: BaseApiController where T: class
    {
        [HttpGet]
        [Route("get")]
        public virtual IHttpActionResult Get()
        {
            return Ok(repository.GetAll());
        }

        [HttpGet]
        [Route("getById")]
        public virtual IHttpActionResult GetById(int id)
        {
            return Ok(repository.GetById(id));
        }

        [HttpPost]
        [Route("add")]
        public virtual IHttpActionResult Add(T entity)
        {
            repository.Add(entity);
            uow.SaveChanges();
            return Ok(entity);
        }

        [HttpPut]
        [Route("update")]
        public virtual IHttpActionResult Update(T entity)
        {
            repository.Update(entity);
            uow.SaveChanges();
            return Ok(entity);
        }

        [HttpDelete]
        [Route("delete")]
        public virtual IHttpActionResult Delete(int id)
        {
            repository.Delete(id);
            uow.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route("page")]
        public virtual IHttpActionResult Page([FromUri]int offSet = 0, [FromUri]int setSize = 10)
        {
            var pagedResult = new PagedResultDto<T>(repository.GetAll().ToList(),setSize,offSet);
            return Ok(pagedResult);
        }

        protected IRepository<T> repository;

        protected IUow uow;
    }
}
