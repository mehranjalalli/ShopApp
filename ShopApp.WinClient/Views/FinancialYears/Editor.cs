using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopApp.WinClient.Views.FinancialYears
{
    public partial class Editor : Framework.EntityEditor<Entities.FinancialYear>
    {
        RepositoryAbstracts.ICorporationsRepository corpsRepo;
        public Editor(RepositoryAbstracts.ICorporationsRepository corpsRepo)
        {
            this.corpsRepo = corpsRepo;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            ComboBox(entity => entity.CorporationId, "شرکت/موسسه", corpsRepo.GetByDeleted(false), corp => corp.Title, corp => corp.Id);
            TextBox(entity => entity.Title, "عنوان");
            TextBox(entity => entity.Description, "توضیحات", true);
            DatePicker(entity => entity.StartDate, "تاریخ شروع");
            DatePicker(Entity => Entity.FinishDate, "تاریخ پایان");
            AdjustControls();
            base.OnLoad(e);
        }

        public override string ViewTitle
        {
            get
            {
                return Entity.Id == 0 ? "تعریف سال مالی" : "ویرایش سال مالی";
            }
        }
    }
}
