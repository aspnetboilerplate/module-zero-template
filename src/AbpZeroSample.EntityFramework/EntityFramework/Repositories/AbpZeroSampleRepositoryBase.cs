using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace AbpZeroSample.EntityFramework.Repositories
{
    public abstract class AbpZeroSampleRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<AbpZeroSampleDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected AbpZeroSampleRepositoryBase(IDbContextProvider<AbpZeroSampleDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class AbpZeroSampleRepositoryBase<TEntity> : AbpZeroSampleRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected AbpZeroSampleRepositoryBase(IDbContextProvider<AbpZeroSampleDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
