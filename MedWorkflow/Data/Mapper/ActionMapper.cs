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
                               :ACTION_ID,
                               :ACTIVITY_INSTANCE_ID,
                               :OPERATION_CODE,
                               :REQUIRED_ROLE,
                               :REQUIRED_OPERATOR_TYPE,
                               :CREATED_ON,
                               :LAST_UPDATED_ON,
                               :APPROVER_REQUIRED,
                               :STATUS
                                 )";
            return Context.Connection.Execute(sql, entity, Context.Transaction);
        }

        public override int UpdateByPrimaryKeySelective(ActionEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}