using CodeGenerator.Forms;
using CodeGenerator.Helpers.Project;

namespace CodeGenerator.Helpers
{
    public class FormFactory
    {
        public static ProjectForm CreateProjectForm()
        {
            return new ProjectForm(new ProjectManager());
        }

        public static SelectProjectForm CreateSelectProjectForm()
        {
            return new SelectProjectForm();
        }

        public static GenerateForm CreateGenerateForm()
        {
            return new GenerateForm();
        }

        public static TableObjectForm CreateTableObjectForm()
        {
            return new TableObjectForm();
        }
    }
}