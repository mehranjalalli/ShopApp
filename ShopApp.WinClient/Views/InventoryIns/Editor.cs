using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq.Expressions;
using ShopApp.Framework.ExtensionMethods;

namespace ShopApp.WinClient.Views.InventoryIns
{
    public partial class Editor : Framework.ViewBase
    {
        public Entities.InventoryInsHeader InvHeader { get; set; }

        RepositoryAbstracts.IInventoriesRepository invRepo;
        RepositoryAbstracts.IInventoryInsTypesRepository typesRepo;

        RepositoryAbstracts.IInventoryInsHeadersRepository insRepo;
        RepositoryAbstracts.IInventoryInsDetailsRepository detailsRepo;

        Framework.GridControl<Entities.InventoryInsDetail> grid;

        List<Entities.InventoryInsDetail> details = new List<Entities.InventoryInsDetail>();

        public Editor(RepositoryAbstracts.IInventoriesRepository invRepo, RepositoryAbstracts.IInventoryInsTypesRepository typesRepo, RepositoryAbstracts.IInventoryInsHeadersRepository insRepo, RepositoryAbstracts.IInventoryInsDetailsRepository detailsRepo)
        {
            this.invRepo = invRepo;
            this.typesRepo = typesRepo;

            this.insRepo = insRepo;
            this.detailsRepo = detailsRepo;
            InitializeComponent();
            InventoriesComboBox.DataSource = this.invRepo.All();
            InventoriesComboBox.DisplayMember = "Title";
            InventoriesComboBox.ValueMember = "Id";

            InsTypeComboBox.DataSource = this.typesRepo.All();
            InsTypeComboBox.DisplayMember = "Title";
            InsTypeComboBox.ValueMember = "Id";

            AddAction("تائید", btn =>
            {
                if (InvHeader.Id == 0)
                    insRepo.Add(InvHeader);
                else
                    insRepo.Update(InvHeader);

                var oldItems = detailsRepo.GetByInventoryInsHeaderId(InvHeader.Id);

                foreach (var item in details)
                {
                    item.InventoryInsHeaderId = InvHeader.Id;
                    detailsRepo.Add(item);
                }
                CloseView(DialogResult.OK);
            });
        }

        protected override void OnLoad(EventArgs e)
        {
            if (InvHeader == null)
                InvHeader = new Entities.InventoryInsHeader { Date = DateTime.Now };

            InventoriesComboBox.DataBindings.Add("SelectedValue", InvHeader, "InventoryId");
            InsTypeComboBox.DataBindings.Add("SelectedValue", InvHeader, "TypeId");
            TitleTextBox.DataBindings.Add("Text", InvHeader, "Title");
            DescriptionsTextBox.DataBindings.Add("Text", InvHeader, "Description");

            Expression<Func<Entities.InventoryInsHeader, DateTime>> selector = header => header.Date;
            var propertyName = new Framework.ExpressionHandler().GetPropertyName(selector);
            DateDropdown.Value = selector.Compile()(InvHeader).ToString("yyyy/MM/dd");
            DateDropdown.InputMask = "0000/00/00";
            DateDropdown.RightToLeft = RightToLeft.No;
            DateDropdown.Tag = selector.Compile()(InvHeader);
            DateDropdown.OnValueChanged += (obj, args) =>
            {
                DateDropdown.Tag = DateDropdown.Value.ConvertToDate();
                InvHeader.GetType().GetProperty(propertyName).SetValue(InvHeader, DateDropdown.Tag);
            };
            DateDropdown.GetDropdownControl += () =>
            {
                var picker = new Framework.DateTimePicker();
                picker.OnDateDoubleClick += (obj, args) =>
                {
                    DateDropdown.CloseDropdown();
                };
                if (DateDropdown.Tag != null)
                {
                    picker.SelectedDate = (DateTime)DateDropdown.Tag;
                }
                picker.OnSelectedDateChanged += (s, args) =>
                {
                    DateDropdown.Value = picker.SelectedDate.ToString("yyyy/MM/dd");
                    DateDropdown.Tag = picker.SelectedDate;
                    InvHeader.GetType().GetProperty(propertyName).SetValue(InvHeader, DateDropdown.Tag);
                };
                return picker;
            };

            grid = new Framework.GridControl<Entities.InventoryInsDetail>(GridContainerPanel);
            grid.AddTextBoxColumn(detail => detail.ProductId, "شناسه محصول");
            grid.AddButtonClumn("انتخاب", row =>
            {
                var view = ViewEngine.ViewInForm<Views.Products.List>(v =>
                {
                    v.SelectorMode = true;
                }, true);
                if(view.DialogResult == DialogResult.OK)
                {
                    row.Cells[0].Value = view.SelectedProduct.Id;
                }
            });
            grid.AddTextBoxColumn(detail => detail.Amount, "مقدار");
            grid.AddTextBoxColumn(detail => detail.TotalPrice, "قیمت");

            grid.AllowAddRows = true;
            grid.AllowDeleteRows = true;
            grid.EditMode = DataGridViewEditMode.EditOnEnter;

            grid.SetDataSource(details);
            base.OnLoad(e);
        }
    }
}
