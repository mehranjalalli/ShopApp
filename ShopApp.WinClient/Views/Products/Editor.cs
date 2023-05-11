using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopApp.WinClient.Views.Products
{
    public partial class Editor : Framework.EntityEditor<Entities.Product>
    {
        RepositoryAbstracts.IProductCategoriesRepository catRepo;
        RepositoryAbstracts.IProductUnitsRepository unitsRepo;
        RepositoryAbstracts.IProductParametersRepository paramsRepo;
        RepositoryAbstracts.IProductParametersValuesRepository paramsValuesRepo;

        public Dictionary<Entities.ProductParameter, TextBox> ParametersControls = new Dictionary<Entities.ProductParameter, TextBox>();

        public Editor(RepositoryAbstracts.IProductCategoriesRepository catRepo, RepositoryAbstracts.IProductUnitsRepository unitsRepo, RepositoryAbstracts.IProductParametersRepository paramsRepo, RepositoryAbstracts.IProductParametersValuesRepository paramsValuesRepo)
        {
            this.catRepo = catRepo;
            this.unitsRepo = unitsRepo;
            this.paramsRepo = paramsRepo;
            this.paramsValuesRepo = paramsValuesRepo;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {

            var catCombo = ComboBox(p => p.ProductCategoryId, "دسته بندی", catRepo.All(), cat => cat.Title, cat => cat.Id);
            TextBox(p => p.Code, "کد محصول");
            TextBox(p => p.Title, "عنوان محصول");
            ComboBox(p => p.ProductUnitId, "واحد اندازه گیری", unitsRepo.All(), unit => unit.Title, unit => unit.Id);
            TextBox(p => p.Description, "توضیحات", true);
            if (Entity.ProductCategoryId > 0)
            {
                catCombo.Enabled = false;
                var parameters = paramsRepo.GetByProductCategoryId(Entity.ProductCategoryId);
                var oldParameters = paramsValuesRepo.GetByProductId(Entity.Id);
                foreach (var parameter in parameters.Where(p=>!p.Deleted))
                {
                    var txt = TextBox(parameter.Title);
                    var relatedValue = oldParameters.FirstOrDefault(p => p.ProductParameterId == parameter.Id);
                    if (relatedValue != null)
                        txt.Text = relatedValue.Value;
                    ParametersControls.Add(parameter, txt);
                }
            }
            AdjustControls();
            base.OnLoad(e);
        }
    }
}
