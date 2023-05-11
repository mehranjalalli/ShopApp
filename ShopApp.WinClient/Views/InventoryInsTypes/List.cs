using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopApp.WinClient.Views.InventoryInsTypes
{
    public partial class List : Framework.ViewBase
    {
        Framework.GridControl<Entities.InventoryInsType> grid;

        RepositoryAbstracts.IInventoryInsTypesRepository typesRepo;

        public List(RepositoryAbstracts.IInventoryInsTypesRepository typesRepo)
        {
            this.typesRepo = typesRepo;

            AddAction("جدید", btn =>
            {
                var view = ViewEngine.ViewInForm<Editor>(null, true);

                if(view.DialogResult == DialogResult.OK)
                {
                    typesRepo.Add(view.Entity);
                    grid.AddItem(view.Entity);
                    grid.ResetBindings();
                }
            });

            AddAction("ویرایش", btn =>
            {
                var view = ViewEngine.ViewInForm<Editor>(v=>
                {
                    v.Entity = grid.CurrentItem;
                }, true);

                if (view.DialogResult == DialogResult.OK)
                {
                    typesRepo.Update(view.Entity);                    
                    grid.ResetBindings();
                }
            });

            AddAction("حذف", btn =>
            {
                if(MessageBox.Show("آیا حذف آیتم را تائید می کنید؟","حذف نوع رسید",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    typesRepo.Remove(grid.CurrentItem);
                    grid.RemoveCurrent();
                    grid.ResetBindings();
                }
            });

            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            grid = new Framework.GridControl<Entities.InventoryInsType>(this);
            grid.AddTextBoxColumn(type => type.Title, "عنوان");
            grid.SetDataSource(typesRepo.All());
            base.OnLoad(e);
        }

        public override string ViewTitle => "مدیریت انواع رسید";
    }
}
