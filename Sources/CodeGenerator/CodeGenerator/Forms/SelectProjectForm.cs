using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using CodeGenerator.Helpers;
using CodeGenerator.Helpers.Project;
using DevExpress.XtraEditors;

namespace CodeGenerator.Forms
{
    public partial class SelectProjectForm : DevExpress.XtraEditors.XtraForm
    {
        public ProjectData SelectedProject { get; private set; }

        public SelectProjectForm()
        {
            InitializeComponent();
        }

        private void SelectProjectForm_Load(object sender, EventArgs e)
        {
            var projectManager = new ProjectManager();
            var list = projectManager.GetProjectList();
            foreach (ProjectData projectData in list)
            {
                listBoxControl1.Items.Add(projectData);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            using (var projectForm = FormFactory.CreateProjectForm())
            {
                projectForm.ShowDialog();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            var project = listBoxControl1.SelectedItem as ProjectData;
            if(project != null)
            {
                this.SelectedProject = project;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                XtraMessageBox.Show("You must first create/select a project!");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
             var project = listBoxControl1.SelectedItem as ProjectData;
             if (project != null)
             {
                 using (var projectForm = FormFactory.CreateProjectForm())
                 {
                     projectForm.Project = project;
                     projectForm.ShowDialog();
                 }
             }
        }
    }
}