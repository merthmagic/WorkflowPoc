using System.IO;

namespace MedWorkflow.Core
{
    public abstract class AbstractProcessDefinitionResolver
    {
        public abstract ProcessDefinition Resolve(string processName);
    }
}