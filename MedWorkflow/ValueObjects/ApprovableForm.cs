namespace MedWorkflow.ValueObjects
{
    public class ApprovableForm
    {
        public ApprovableForm(FormType type, string formId)
        {
            FormType = type;
            FormId = formId;
        }

        public FormType FormType { get; private set; }

        public string FormId { get; private set; }
    }
}