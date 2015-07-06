using System.Web.Http;
using Common.Data.Contracts;

namespace Common.Controllers
{
    public abstract class BaseEntityController<T>: ApiController where T: class
    {
        [HttpGet]
        public virtual IHttpActionResult Get()
        {
            return Ok(repository.GetAll());
        }

        [HttpPost]
        public virtual IHttpActionResult Add(T entity)
        {
            repository.Add(entity);
            uow.SaveChanges();
            return Ok(entity);
        }

        [HttpPut]
        public virtual IHttpActionResult Update(T entity)
        {
            repository.Update(entity);
            uow.SaveChanges();
            return Ok(entity);
        }

        [HttpDelete]
        public virtual IHttpActionResult Delete(int id)
        {
            repository.Delete(id);
            uow.SaveChanges();
            return Ok();
        }

        protected IRepository<T> repository;

        protected IUow uow;
    }
}
