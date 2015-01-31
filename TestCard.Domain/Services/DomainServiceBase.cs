using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCard.Domain.Helpers;

namespace TestCard.Domain.Services
{
    public abstract class DomainServiceBase
    {
        public DbContextConfiguration Configuration
        {
            get
            {
                return _DbContext.Configuration;
            }
        }

        protected readonly TestCardContext _DbContext;
        protected readonly PersonInfo _CurrentUser;

        public DomainServiceBase()
            : this(new TestCardContext(), null) { }

        public DomainServiceBase(PersonInfo currentUser)
            : this(new TestCardContext(), currentUser) { }

        public DomainServiceBase(DomainServiceBase service)
            : this(service._DbContext, service._CurrentUser) { }

        public DomainServiceBase(TestCardContext context, PersonInfo currentUser)
        {
            _DbContext = context;
            _CurrentUser = currentUser;
        }
    }

    public abstract class DomainServiceBase<T> : DomainServiceBase, IDisposable
        where T : class /*T=Model*/
    {
        public DomainServiceBase()
            : base()
        { }

        public DomainServiceBase(PersonInfo currentUser)
            : base(currentUser)
        { }

        public DomainServiceBase(DomainServiceBase service)
            : base(service)
        { }

        public virtual IQueryable<T> GetAll()
        {
            return _DbContext.Set<T>();
        }

        public virtual IQueryable<T> GetAll(DataFilterOption option, bool secureObject = false)
        {
            var query = _DbContext.Set<T>().AsQueryable();

            if (secureObject)
            {
                query = SecurityFilter(query);
            }

            return query.SortAndFilter<T>(option);
        }

        public virtual T Get(dynamic id, bool secureObject = false)
        {
            var obj = _DbContext.Set<T>().Find(id);

            if(secureObject)
            {
                obj = SecurityFilter(obj);
            }

            return obj;
        }

        public virtual void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _DbContext.Set<T>().Add(entity);
        }

        public virtual void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _DbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _DbContext.Set<T>().Remove(entity);
        }

        public virtual void Delete(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException("entity");
            }

            foreach (var entity in entities)
            {
                Delete(entity);
            }
        }

        public virtual void SaveChanges()
        {
            _DbContext.SaveChanges();
        }

        public void Dispose()
        {
            _DbContext.Dispose();
        }

        protected T SecurityFilter(T entity)
        {
            return SecurityFilter(new List<T>() { entity }
                .AsQueryable())
                .FirstOrDefault();
        }

        public virtual IQueryable<T> SecurityFilter(IQueryable<T> query)
        {
            return query;
        }
    }
}
