using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BackwardChainingMVVM.Infrastructure;
using BackwardChainingMVVM.ViewModel;
using DevExpress.XtraGrid.Views.Grid;

namespace BackwardChainingMVVM
{
    public partial class TemperamentView : Form
    {
        #region Fields and properties

        private bool _isHypothesisTrue;
        private TemperamentViewModel _viewModel;

        public TemperamentViewModel ViewModel
        {
            get
            {
                return _viewModel;
            }
        }

        public List<GridViewData> RowsList = new List<GridViewData>();

        #endregion

        #region Ctor

        public TemperamentView(TemperamentViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
            AfterInitialized();
        }

        #endregion

        #region Methods

        public void AfterInitialized()
        {
            _bsUserTemperament.DataSource = ViewModel.Model;
            _gcConclusions.DataSource = RowsList;
            _lueHypothesis.Properties.DataSource = EnumHelper.TranslationsDictionary;
            _lueHypothesis.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value"));
        }

        #endregion

        #region Events handlers

        private void _ceIsUnsociable_CheckedChanged(object sender, EventArgs e)
        {
            var checkEdit = sender as DevExpress.XtraEditors.CheckEdit;

            if (checkEdit.Checked && ViewModel.Model.IsSociable)
            {
                _ceIsSociable.Checked = false;
                ViewModel.Model.IsSociable = false;
            }
        }

        private void _ceIsSociable_CheckedChanged(object sender, EventArgs e)
        {
            var checkEdit = sender as DevExpress.XtraEditors.CheckEdit;

            if (checkEdit.Checked && ViewModel.Model.IsUnsociable)
            {
                _ceIsUnsociable.Checked = false;
                ViewModel.Model.IsUnsociable = false;
            }
        }

        private void _sbConclude_Click(object sender, EventArgs e)
        {
            try
            {
                RowsList.Clear();
                _isHypothesisTrue = ViewModel.IsHypothesisTrue(_lueHypothesis.EditValue.ToString(), ViewModel.Model);
                PushMessageToGridMethod();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Properties.Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void PushMessageToGridMethod()
        {
            foreach (var message in ViewModel.Service.MessagesList)
            {
                RowsList.Add(new GridViewData(_gvConclusions.RowCount, message));
            }

            ViewModel.Service.MessagesList.Clear();
            _gcConclusions.RefreshDataSource();
        }

        #endregion

        private void _gvConclusions_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;

            if (e.RowHandle < view.RowCount - 1)
            {
                if(!RowsList[e.RowHandle].Conclusion.Contains(Properties.Resources.Not))
                    e.Appearance.BackColor = Color.DarkSeaGreen;
            }

            else
            {
                e.Appearance.BackColor = _isHypothesisTrue ? Color.Green : Color.Red;
            }
        }
    }
}
