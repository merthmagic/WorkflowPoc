using System;
using MedWorkflow.Core;

namespace MedWorkflow.Demo
{
    public class FindOneStopApprover:IActionHandler
    {
        public void Execute(ExecutionContext context)
        {
            Console.WriteLine("find boss");
        }
    }
}