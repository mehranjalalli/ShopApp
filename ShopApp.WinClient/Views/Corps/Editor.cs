using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopApp.WinClient.Views.Corps
{
    public partial class Editor : Framework.EntityEditor<Entities.Corporation>
    {
        public Editor()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            TextBox(entity => entity.Title, "عنوان");
            TextBox(entity => entity.Description, "توضیحات", true);
            TextBox(entity => entity.Address, "آدرس", true);
            var phoneTextbox = TextBox(entity => entity.Telephone, "شماره تماس");
            phoneTextbox.RightToLeft = RightToLeft.No;
            var faxTextbox = TextBox(entity => entity.Fax, "فکس");
            faxTextbox.RightToLeft = RightToLeft.No;
            AdjustControls();
            base.OnLoad(e);
        }

        public override string ViewTitle
        {
            get
            {
                return Entity.Id == 0 ? "تعریف شرکت جدید" : "ویرایش شرکت";
            }
        }
    }
}
