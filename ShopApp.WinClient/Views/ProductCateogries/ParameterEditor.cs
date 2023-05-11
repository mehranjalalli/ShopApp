using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopApp.WinClient.Views.ProductCateogries
{
    public partial class ParameterEditor : Framework.EntityEditor<Entities.ProductParameter>
    {
        public ParameterEditor()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            TextBox(p => p.Key, "کلید");
            TextBox(p => p.Title, "عنوان");
            TextBox(p => p.Description, "توضیحات", true);
            AdjustControls();
            base.OnLoad(e);
        }

        public override string ViewTitle => Entity == null ? "ایجاد پارامتر" : "ویرایش پارامتر";
    }
}
