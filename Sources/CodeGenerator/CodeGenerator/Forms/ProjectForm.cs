using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using CodeGenerator.Helpers.Connection;
using CodeGenerator.Helpers.Project;
using DevExpress.XtraEditors;

namespace CodeGenerator.Forms
{
    public partial class ProjectForm : DevExpress.XtraEditors.XtraForm
    {
        private readonly IProjectManager _projectManager;
        private string _connString;
        public ProjectData Project { get; set; }

        public ProjectForm(IProjectManager projectManager)
        {
            _projectManager = projectManager;
            InitializeComponent();
        }

        private void btnSelectDatabase_Click(object sender, EventArgs e)
        {
            using (var selectDatabaseForm = new SelectDatabaseForm())
            {
                if(selectDatabaseForm.ShowDialog() == DialogResult.OK)
                {
                    txtDatabase.Text = selectDatabaseForm.DatabaseName;
                    txtProjectName.Text = selectDatabaseForm.DatabaseName;
                    _connString = selectDatabaseForm.ConnectionString;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtDatabase.Text.Trim()))
            {
                MessageBox.Show("Please first select a database");
            }
            else if(string.IsNullOrEmpty(txtProjectName.Text.Trim()))
            {
                MessageBox.Show("Please enter a project name");
            }
            else
            {
                if(ProjectNameAlreadyExists())
                {
                    MessageBox.Show("Please choose another project name, this one already exists.");
                }
                else
                {
                    var project = new ProjectData { ConnString = _connString, Name = txtProjectName.Text };
                    Project = project;
                    _projectManager.Save(project);
                }
            }
        }

        private bool ProjectNameAlreadyExists()
        {
            return _projectManager.Exits(txtProjectName.Text);
        }

        private void ProjectForm_Load(object sender, EventArgs e)
        {
            if (Project != null)
            {
                this.Text = "Edit project";
                txtProjectName.Text = Project.Name;
                txtDatabase.Text = new ConnectionData(Project.ConnString).DatabaseName;
            }
        }
    }
}