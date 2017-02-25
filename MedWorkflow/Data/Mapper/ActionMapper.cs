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
            throw new System.NotImplementedException();
        }

        public override int UpdateByPrimaryKeySelective(ActionEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}