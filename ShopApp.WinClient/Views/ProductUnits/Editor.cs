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
    public partial class Editor : Framework.EntityEditor<Entities.ProductUnit>
    {
        public Editor()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            TextBox(entity => entity.Title, "عنوان");
            TextBox(entity => entity.Description, "توضیحات");
            AdjustControls();
            base.OnLoad(e);
        }

        public override string ViewTitle
        {
            get
            {
                return Entity.Id == 0 ? "تعریف واحد اندازه گیری" : "ویرایش واحد اندازه گیری";
            }
        }
    }
}
