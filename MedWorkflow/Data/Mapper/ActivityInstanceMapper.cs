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
            throw new NotImplementedException();
        }

        public override int Insert(ActivityInstanceEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}