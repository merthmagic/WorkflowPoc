namespace MedWorkflow.Data.Mapper
{
    public abstract class AbstractMapper<TEntity, TKey>
    {
        private readonly DbContext _dbContext;

        protected AbstractMapper(DbContext context)
        {
            _dbContext = context;
        }

        public abstract TEntity SelectByPrimaryKey(TKey key);

        public abstract int Insert(TEntity entity);

        public abstract int UpdateByPrimaryKeySelective(TEntity entity);

        protected DbContext Context { get { return _dbContext; } }
    }
}