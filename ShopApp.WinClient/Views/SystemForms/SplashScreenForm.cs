using ShopApp.RepositoryAbstracts;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopApp.WinClient.Views.SystemForms
{
    public partial class SplashScreenForm : Form
    {
        IDbTools dbTools;

        public SplashScreenForm(IDbTools dbTools)
        {
            this.dbTools = dbTools;
            InitializeComponent();
        }

        private async void SplashScreenForm_Load(object sender, EventArgs e)
        {
            if (!await CheckDbConnection())
                DialogResult = DialogResult.Cancel;
            dbTools.RefreshConnectionString();
            if (await CheckDatabase())
            {
                DialogResult = DialogResult.OK;
                return;
            }
            DialogResult = DialogResult.Cancel;
        }

        private async Task<bool> CheckDatabase()
        {
            StatusLabel.Text = "در حال بررسی بانک اطلاعاتی...";
            if (!await dbTools.CheckDatabaseExists())
            {
                StatusLabel.Text = "در حال ایجاد بانک اطلاعاتی...";
                if (!await dbTools.CreateDatabase(Properties.Resources.shopdbscript))
                    return false;
            }
            return true;
        }

        private async Task<bool> CheckDbConnection()
        {
            StatusLabel.Text = "در حال بررسی ارتباط با سرور...";
            if (!await dbTools.CheckDbConnection())
            {
                var container = new StructureMap.Container(new IoC.TypesRegistry());
                var connectionSettingsForm = container.GetInstance<DbConnectionSettingsForm>();
                var result = connectionSettingsForm.ShowDialog();
                if (result != DialogResult.OK)
                    return false;
            }
            return true;
        }
    }
}
