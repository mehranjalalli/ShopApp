using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopApp.WinClient.Views.Inventories
{
    public partial class List : Framework.ViewBase
    {
        Framework.GridControl<Entities.Inventory> invGrid;
        RepositoryAbstracts.IInventoriesRepository invRepo;
        public List(RepositoryAbstracts.IInventoriesRepository invRepo)
        {
            this.invRepo = invRepo;
            InitializeComponent();
            AddAction("جدید", btn =>
            {
                var view = ViewEngine.ViewInForm<Editor>(null, true);
                if (view.DialogResult == DialogResult.OK)
                {
                    invRepo.Add(view.Entity);
                    invGrid.AddItem(view.Entity);
                    invGrid.ResetBindings();
                }
            });
            AddAction("ویرایش", btn =>
             {
                 var view = ViewEngine.ViewInForm<Editor>(editor =>
                 {
                     editor.Entity = invGrid.CurrentItem;
                 }, true);
                 if(view.DialogResult == DialogResult.OK)
                 {
                     invRepo.Update(view.Entity);
                     invGrid.ResetBindings();
                 }
             });


            AddAction("حذف", btn =>
            {
                if(MessageBox.Show("آیا حذف انبار را تائید می کنید؟","حذف انبار",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    invRepo.Remove(invGrid.CurrentItem);
                    invGrid.RemoveCurrent();
                    invGrid.ResetBindings();
                }
            });
        }

        protected override void OnLoad(EventArgs e)
        {
            invGrid = new Framework.GridControl<Entities.Inventory>(this);
            invGrid.AddTextBoxColumn(inv => inv.Title, "عنوان");
            invGrid.SetDataSource(invRepo.All());
            base.OnLoad(e);
        }

        public override string ViewTitle
        {
            get
            {
                return "لیست انبارها";
            }
        }
    }
}
