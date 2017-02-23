using System.Collections.Generic;

namespace MedWorkflow
{
    internal class WorkflowTemplate:IWorkflowTemplate
    {
        private readonly string _templateUuid;
        private readonly List<IActivityTemplate> _activityTemplates;

        public WorkflowTemplate(string templateUuid, int status, IEnumerable<IActivityTemplate> activityTemplates)
        {
            _templateUuid = templateUuid;
            Status = status;
            _activityTemplates = new List<IActivityTemplate>();
        }

        public string TemplateUuid
        {
            get { return _templateUuid; }
        }

        public int Status { get; set; }

        public IEnumerable<IActivityTemplate> Activities
        {
            get { return _activityTemplates ; }
        }

        public void AddActivityTemplates(IEnumerable<IActivityTemplate> activityTemplates)
        {
            _activityTemplates.AddRange(activityTemplates);
        }
    }
}