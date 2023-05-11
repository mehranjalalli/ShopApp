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
    public partial class Editor : Framework.EntityEditor<Entities.Inventory>
    {
        RepositoryAbstracts.ICorporationsRepository corpsRepo;
        public Editor(RepositoryAbstracts.ICorporationsRepository corpsRepo)
        {
            this.corpsRepo = corpsRepo;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            ComboBox(inv => inv.CorporationId, "شرکت/سازمان", corpsRepo.All(), corp => corp.Title, corp => corp.Id);
            TextBox(inv => inv.Title, "عنوان انبار");
            TextBox(inv => inv.Description, "توضیحات", true);
            AdjustControls();
            base.OnLoad(e);
        }
    }
}
