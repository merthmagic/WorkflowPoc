namespace MedWorkflow
{
    internal class Form:IForm
    {
        public Form(string formType, string formId)
        {
            FormType = formType;
            FormId = formId;
        }

        public string FormType { get; private set; }

        public string FormId { get; private set; }
    }
}