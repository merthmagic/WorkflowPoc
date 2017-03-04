using Dapper;
using MedWorkflow.Data.Entity;

namespace MedWorkflow.Data.Mapper
{
    public class WorkflowBookmarkMapper : AbstractMapper<WorkflowBookmarkEntity, string>
    {

        public WorkflowBookmarkMapper(DbContext dbContext)
            : base(dbContext)
        {

        }

        public override WorkflowBookmarkEntity SelectByPrimaryKey(string key)
        {
            throw new System.NotImplementedException();
        }

        public override int Insert(WorkflowBookmarkEntity entity)
        {
            const string sql = @"INSERT INTO MSC_WORKFLOW_BOOKMARK VALUES(
                                :BOOKMARK_ID,
                                :WORKFLOW_INSTANCE_ID,
                                :FORM_TYPE,
                                :FORM_ID,
                                :USER_ID,
                                :CURRENT_ACTIVITY_NAME,
                                :NEXT_ACTIVITY_NAME,
                                :CREATED_ON,
                                :LAST_UPDATED_ON,
                                :ALLOWED_OPERATIONS
                                )";
            return Context.Connection.Execute(sql, entity, Context.Transaction);
        }

        public override int UpdateByPrimaryKeySelective(WorkflowBookmarkEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}