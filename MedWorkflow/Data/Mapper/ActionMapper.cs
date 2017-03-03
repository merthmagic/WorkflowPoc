using System.Runtime.InteropServices.ComTypes;
using Dapper;
using MedWorkflow.Data.Entity;

namespace MedWorkflow.Data.Mapper
{
    public class ActionMapper:AbstractMapper<ActionEntity,string>
    {
        public ActionMapper(DbContext context)
            : base(context)
        {
        }

        public override ActionEntity SelectByPrimaryKey(string key)
        {
            throw new System.NotImplementedException();
        }

        public override int Insert(ActionEntity entity)
        {
            const string sql = @"INSERT INTO MSC_ACTION VALUES (
                                :WORKFLOW_TEMPLATE_UUID,
                                :WORKFLOW_NAME,
                                :WORKFLOW_TEMPLATE_VERSION,
                                :WORKFLOW_TEMPLATE_URI,
                                :CREATED_ON,
                                :IS_ENABLE
                                 )";
            return Context.Connection.Execute(sql, entity, Context.Transaction);
        }

        public override int UpdateByPrimaryKeySelective(ActionEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}