using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopApp.WinClient
{
    public partial class MainForm : Framework.MainFormBase
    {
        public MainForm()
        {            
            InitializeComponent();
            Text = "مدیریت انبار و فروش";
            TypesRegistry = new IoC.TypesRegistry();
            var baseInfo = AddMenu("اطلاعات پایه");
            baseInfo.AddMenu("شرکت ها", null, (s, e) =>
            {
                ViewEngine.ViewInTab<Views.Corps.List>();
            });
            baseInfo.AddMenu("سال های مالی", null, (s, e) =>
            {
                ViewEngine.ViewInTab<Views.FinancialYears.List>();
            });
            baseInfo.AddMenu("واحدهای اندازه گیری", null, (s, e) =>
            {
                ViewEngine.ViewInTab<Views.ProductUnits.List>();
            });
            baseInfo.AddSeparator();
            baseInfo.AddMenu("انبارها", null, (s, e) => ViewEngine.ViewInTab<Views.Inventories.List>());
            baseInfo.AddMenu("دسته بندی محصولات", null, (s, e) => ViewEngine.ViewInTab<Views.ProductCateogries.List>());
            baseInfo.AddMenu("محصولات", null, (s, e) => ViewEngine.ViewInTab<Views.Products.List>());
            baseInfo.AddMenu("انواع رسید", null, (s, e) => ViewEngine.ViewInTab<Views.InventoryInsTypes.List>());

            var inventoryMenu = AddMenu("انبار");

            inventoryMenu.AddMenu("رسید ها", null, (s, e) =>
              {
                  ViewEngine.ViewInTab<Views.InventoryIns.List>();
              });
        }
    }
}
