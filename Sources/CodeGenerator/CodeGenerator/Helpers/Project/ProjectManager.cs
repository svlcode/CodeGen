using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using DevExpress.Utils.Helpers;

namespace CodeGenerator.Helpers.Project
{
    public class ProjectManager : IProjectManager
    {
        private readonly string _projectsPath;

        public ProjectManager()
        {
            _projectsPath = @".\Projects";
        }
        
        public bool Exits(string projectName)
        {
            return File.Exists(GetProjectFileName(projectName));
        }

        public void Save(ProjectData project)
        {
            try
            {
                XDocument doc = new XDocument(
                              new XElement("project",
                                  new XElement("name", project.Name)
                                  , new XElement("connString", project.ConnString)));


                doc.Save(GetProjectFileName(project.Name));
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string GetProjectFileName(string projectName)
        {
            return Path.Combine(_projectsPath, string.Format("{0}.xml", projectName));
        }

        public List<ProjectData> GetProjectList()
        {
            List<ProjectData> projects = new List<ProjectData>();
            var files = Directory.GetFiles(_projectsPath, "*.xml");
            if(files.Length > 0)
            {
                foreach (string file in files)
                {
                    XDocument doc = XDocument.Load(file);
                    ProjectData project = new ProjectData();
                    project.Name = doc.Root.Element("name").Value;
                    project.ConnString = doc.Root.Element("connString").Value;
                    projects.Add(project);
                }
                
            }
            return projects;
        }
    }
}