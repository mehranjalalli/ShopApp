using ShopApp.RepositoryAbstracts;
using ShopApp.Framework.ExtensionMethods;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ShopApp.WinClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Framework.Cultures.InitializePersianCulture();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var container = new StructureMap.Container(new IoC.TypesRegistry());
            var splashForm = container.GetInstance<Views.SystemForms.SplashScreenForm>();
            var result = splashForm.ShowDialog();
            if (result != DialogResult.OK)
                return;
            var usersRepo = container.GetInstance<IUsersRepository>();
            if (usersRepo.Count() == 0)
            {
                usersRepo.Add(new Entities.User
                {
                    Username = "مدیر"
                });
            }
            var corporationsRepo = container.GetInstance<ICorporationsRepository>();
            if (corporationsRepo.Count() == 0)
            {
                var corporationEditorForm = new Views.SystemForms.CorporationEditorForm();
                var corporationEntity = new Entities.Corporation();
                corporationEditorForm.Corporation = corporationEntity;
                if (corporationEditorForm.ShowDialog() == DialogResult.OK)
                {
                    corporationsRepo.Add(corporationEntity);
                }
                else
                {
                    Application.Exit();
                    return;
                }
            }
            var financialYearsRepo = container.GetInstance<IFinancialYearsRepository>();
            if(financialYearsRepo.Count() == 0)
            {
                var corporation = corporationsRepo.All().First();
                var financialYearModel = new Models.FinancialYearModel();
                var financialYearEditorForm = new Views.SystemForms.FinancialYearEditorForm();
                financialYearEditorForm.FinancialYear = financialYearModel;
                if(financialYearEditorForm.ShowDialog() == DialogResult.OK)
                {
                    var financialYear = new Entities.FinancialYear();
                    financialYear.CorporationId = corporation.Id;
                    financialYear.Title = financialYearModel.Title;
                    financialYear.Description = financialYearModel.Description;
                    financialYear.StartDate = financialYearModel.StartDate.ConvertToDate() ?? DateTime.Now;
                    financialYear.FinishDate = financialYearModel.FinishDate.ConvertToDate() ?? DateTime.Now;
                    financialYearsRepo.Add(financialYear);
                }
                else
                {
                    Application.Exit();
                    return;
                }

            }
            Application.Run(new MainForm());
        }
    }
}