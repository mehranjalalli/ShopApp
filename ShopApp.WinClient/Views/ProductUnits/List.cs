using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopApp.WinClient.Views.ProductUnits
{
    public partial class List : Framework.ViewBase
    {
        RepositoryAbstracts.IProductUnitsRepository unitsRepo;
        Framework.GridControl<Entities.ProductUnit> unitsGrid;

        public List(RepositoryAbstracts.IProductUnitsRepository unitsRepo)
        {
            this.unitsRepo = unitsRepo;
            InitializeComponent();
            AddAction("جدید", btn =>
            {
                var editor = ViewEngine.ViewInForm<Editor>(null, true);
                if (editor.DialogResult == DialogResult.OK)
                {
                    unitsRepo.Add(editor.Entity);
                    unitsGrid.AddItem(editor.Entity);
                    unitsGrid.ResetBindings();
                }
            });
            AddAction("ویرایش", btn =>
            {
                var view = ViewEngine.ViewInForm<Editor>(editor =>
                {
                    editor.Entity = unitsGrid.CurrentItem;
                }, true);
                if (view.DialogResult == DialogResult.OK)
                {
                    unitsRepo.Update(view.Entity);
                    unitsGrid.ResetBindings();
                }
            });
            AddAction("حذف", btn =>
            {
                if (MessageBox.Show("آیا حذف را تائید می کنید؟", "حذف واحد اندازه گیری", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    unitsGrid.CurrentItem.Deleted = true;
                    unitsGrid.CurrentItem.DeleteDate = DateTime.Now;
                    unitsRepo.Update(unitsGrid.CurrentItem);
                    unitsGrid.SetDataSource(unitsRepo.GetByDeleted(false));
                }
            });
        }

        protected override void OnLoad(EventArgs e)
        {
            unitsGrid = new Framework.GridControl<Entities.ProductUnit>(this);
            unitsGrid.AddTextBoxColumn(entity => entity.Title, "عنوان");
            unitsGrid.SetDataSource(unitsRepo.GetByDeleted(false));
            base.OnLoad(e);
        }

        public override string ViewTitle
        {
            get
            {
                return "مدیریت واحدهای اندازه گیری";
            }
        }
    }
}
