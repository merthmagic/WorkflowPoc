using System;
using Dapper;
using MedWorkflow.Data.Entity;

namespace MedWorkflow.Data.Mapper
{
    public class ActivityInstanceMapper : AbstractMapper<ActivityInstanceEntity, string>
    {
        public ActivityInstanceMapper(DbContext context)
            : base(context)
        {
        }

        public override ActivityInstanceEntity SelectByPrimaryKey(string key)
        {
            var conn = Context.Connection;
            const string sql = @"SELECT * FROM MSC_ACTIVITY_INSTANCE WHERE ACTIVITY_INSTANCE_ID=:InstanceId";
            return conn.QueryFirst<ActivityInstanceEntity>(sql, new { InstanceId = key }, Context.Transaction);
        }

        public override int UpdateByPrimaryKeySelective(ActivityInstanceEntity entity)
        {
            const string sql = @"UPDATE MSC_ACTIVITY_INSTANCE SET 
                                    LAST_UPDATED_ON=:LAST_UPDATED_ON,
                                    STATUS=:STATUS WHERE ACTIVITY_INSTANCE_ID=:ACTIVITY_INSTANCE_ID";
            return Context.Connection.Execute(sql, entity, Context.Transaction);
        }

        public override int Insert(ActivityInstanceEntity entity)
        {
            const string sql = @"INSERT INTO MSC_ACTIVITY_INSTANCE VALUES (
                                :ACTIVITY_INSTANCE_ID,
                                :WORKFLOW_INSTANCE_ID,
                                :ACTIVITY_TEMPLATE_ID,
                                :POLICY_DESCRIPTOR,
                                :CREATED_ON,
                                :LAST_UPDATED_ON,
                                :STATUS
                                )";
            return Context.Connection.Execute(sql, entity, Context.Transaction);
        }
    }
}