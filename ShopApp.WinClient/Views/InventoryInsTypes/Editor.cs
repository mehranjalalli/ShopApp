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
    public partial class Editor : Framework.EntityEditor<Entities.InventoryInsType>
    {
        public Editor()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            TextBox(type => type.Title, "عنوان");
            TextBox(type => type.Description, "توضیحات", true);
            AdjustControls();
            base.OnLoad(e);
        }
    }
}
