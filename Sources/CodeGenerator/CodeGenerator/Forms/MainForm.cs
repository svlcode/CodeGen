using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CodeGenerator.Helpers;
using CodeGenerator.Helpers.BO;
using CodeGenerator.Helpers.DBO;
using CodeGenerator.Helpers.Project;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace CodeGenerator.Forms
{
    public partial class MainForm : XtraForm
    {
        private ProjectData _currentProject;

        public MainForm()
        {
            InitializeComponent();
        }

        private void barButtonItemNewProj_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var projectForm = FormFactory.CreateProjectForm())
            {
                projectForm.ShowDialog();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            SelectProject();
        }

        private void SelectProject()
        {
            ProjectData project = GetSelectedProject();
            if (project != null)
            {
                gridView1.Layout -= gridView1_Layout;
                FindPanelVisibilityChanged -= MainForm_FindPanelVisibilityChanged;
                _currentProject = project;
                this.Text = string.Format("Project: {0}", project.Name);
                LoadTables();
                SetupGridColums();
                
                gridView1.Layout += gridView1_Layout;
                FindPanelVisibilityChanged += MainForm_FindPanelVisibilityChanged;
            }
        }

        void MainForm_FindPanelVisibilityChanged(object sender, EventArgs e)
        {
            if (!_isChkFindClicked)
            {
                chkFind.Checked = _isFindPanelVisible;    
            }
        }

        private void SetupGridColums()
        {
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[1].OptionsColumn.FixedWidth = true;
            gridView1.Columns[1].OptionsColumn.AllowSize = false;
            gridView1.Columns[1].OptionsColumn.AllowMove = false;
            gridView1.Columns[1].OptionsFilter.AllowFilter = false;
            gridView1.Columns[1].OptionsColumn.AllowSort = DefaultBoolean.False;
            gridView1.Columns[1].OptionsColumn.ShowCaption = false;
            gridView1.Columns[1].Width = 30;
            foreach (GridColumn gridColumn in gridView1.Columns)
            {
                gridColumn.OptionsColumn.AllowEdit = false;
                if (gridColumn.FieldName == "IsSelected")
                {
                    gridColumn.OptionsColumn.AllowEdit = true;
                    gridColumn.ImageIndex = 0;
                }
            }
        }

        private void LoadTables()
        {
            var tableDbo = new TableDbo(_currentProject.ConnString);
            var list = tableDbo.GetTablesBindingList();
            gridControl1.DataSource = list;
        }

        private ProjectData GetSelectedProject()
        {
            ProjectData project = null;
            using (SelectProjectForm selectProjectForm = FormFactory.CreateSelectProjectForm())
            {
                if(selectProjectForm.ShowDialog() == DialogResult.OK)
                {
                    project = selectProjectForm.SelectedProject;
                }
            }
            return project;
        }

        private void btnOpenProj_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SelectProject();
        }

        private void btnGenerate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (GenerateForm generateForm = FormFactory.CreateGenerateForm())
            {
                generateForm.ShowDialog();
            }
        }

        private bool _selectAllColumns = Constants.DEFAULT_SELECTION_STATE;

        private void gridView_Click(object sender, EventArgs e)
        {
            GridView view = sender as GridView;
            if (view != null)
            {
                Point p = view.GridControl.PointToClient(MousePosition);
                GridHitInfo info = view.CalcHitInfo(p);
                if (info.HitTest == GridHitTest.Column && info.Column.FieldName == "IsSelected")
                {
                    _selectAllColumns = !_selectAllColumns;
                    var list = gridControl1.DataSource as BindingList<TableBo>;
                    if(list != null)
                    {
                        foreach (var tableBo in list)
                        {
                            tableBo.IsSelected = _selectAllColumns;
                        }
                    }
                    gridView1.RefreshData();
                }
            }
        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                var data = gridView1.GetRow(gridView1.FocusedRowHandle) as TableBo;
                if(data != null)
                {
                    data.IsSelected = !data.IsSelected;
                    gridView1.RefreshData();
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                OpenSelectedTable();
            }
        }
        
        private bool _isFindPanelVisible;

        private event EventHandler FindPanelVisibilityChanged;

        private void gridView1_Layout(object sender, EventArgs e)
        {
            if(_isFindPanelVisible != gridView1.IsFindPanelVisible)
            {
                _isFindPanelVisible = gridView1.IsFindPanelVisible;
                OnFindPanelVisibilityChanged();
            }
        }

        private void OnFindPanelVisibilityChanged()
        {
            if(FindPanelVisibilityChanged != null)
            {
                FindPanelVisibilityChanged(this, new EventArgs());
            }
        }

        private bool _isChkFindClicked;
        private void chkFind_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _isChkFindClicked = true;
            if(chkFind.Checked)
            {
                gridView1.ShowFindPanel();
            }
            else
            {
                gridView1.HideFindPanel();
            }
            _isChkFindClicked = false;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            GridView view = gridView1;
            if (view != null)
            {
                Point p = view.GridControl.PointToClient(MousePosition);
                GridHitInfo info = view.CalcHitInfo(p);
                if (info.HitTest == GridHitTest.RowCell || info.HitTest == GridHitTest.RowEdge)
                {
                    var tableBo = view.GetRow(info.RowHandle) as TableBo;
                    if (tableBo != null)
                    {
                        OpenTableForm(tableBo);
                    }
                }
            }
        }

        private void OpenSelectedTable()
        {
            var tableBo = gridView1.GetRow(gridView1.FocusedRowHandle) as TableBo;
            if (tableBo != null)
            {
                OpenTableForm(tableBo);
            }
        }

        private void OpenTableForm(TableBo tableBo)
        {
            using (TableObjectForm tableObjectForm = FormFactory.CreateTableObjectForm())
            {
                tableObjectForm.CurrentTable = tableBo;
                tableObjectForm.ShowDialog();
            }
        }
    }
}
