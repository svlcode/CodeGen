namespace CodeGenerator.Helpers.Project
{
    public interface IProjectManager
    {
        bool Exits(string name);
        void Save(ProjectData project);
    }
}