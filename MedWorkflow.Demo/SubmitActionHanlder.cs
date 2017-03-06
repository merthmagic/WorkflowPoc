using System;
using MedWorkflow.Core;

namespace MedWorkflow.Demo
{
    public class SubmitActionHanlder:IActionHandler
    {
        public void Execute(ExecutionContext context)
        {
            Console.WriteLine("form submit");
        }
    }
}