namespace CodeGenerator.Helpers.Project
{
    public class ProjectData
    {
        public string Name { get; set; }
        public string ConnString { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}