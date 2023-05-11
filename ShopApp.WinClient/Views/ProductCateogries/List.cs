using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShopApp.Framework;

namespace ShopApp.WinClient.Views.ProductCateogries
{
    public partial class List : Framework.ViewBase
    {
        RepositoryAbstracts.IProductCategoriesRepository catRepo;
        TreeControl<Entities.ProductCategory> treeControl;

        public List(RepositoryAbstracts.IProductCategoriesRepository catRepo)
        {
            InitializeComponent();
            this.catRepo = catRepo;

            AddAction("جدید ریشه", btn =>
            {
                var view = ViewEngine.ViewInForm<Editor>(editor =>
                {
                }, true);
                if(view.DialogResult == DialogResult.OK)
                {
                    catRepo.Add(view.Entity);
                    treeControl.InitRoots();
                }
            });
            AddAction("جدید", btn =>
            {
                var view = ViewEngine.ViewInForm<Editor>(editor =>
                {
                    editor.ParentCategory = treeControl.SelectedObject;
                }, true);
                if (view.DialogResult == DialogResult.OK)
                {
                    catRepo.Add(view.Entity);
                    treeControl.InitRoots();
                }
            });
            AddAction("ویرایش", btn =>
            {
                var view = ViewEngine.ViewInForm<Editor>(editor =>
                {
                    editor.Entity = treeControl.SelectedObject;
                }, true);
                if (view.DialogResult == DialogResult.OK)
                {
                    catRepo.Update(view.Entity);
                    treeControl.InitRoots();
                }
            });
            AddAction("حذف", btn =>
            {
                treeControl.SelectedObject.Deleted = true;
                treeControl.SelectedObject.DeleteDate = DateTime.Now;
                catRepo.Update(treeControl.SelectedObject);
                treeControl.InitRoots();
            });

            AddAction("پارامترها", btn =>
            {
                if (treeControl.SelectedObject == null)
                    return;
                ViewEngine.ViewInForm<Parameters>(view =>
                {
                    view.ProductCategoryId = treeControl.SelectedObject.Id;
                }, true);
            });
        }

        protected override void OnLoad(EventArgs e)
        {
            treeControl = new Framework.TreeControl<Entities.ProductCategory>(this);
            treeControl.OnGetNodes += TreeControl_OnGetNodes;
            treeControl.InitRoots();
            base.OnLoad(e);
        }

        private IEnumerable<Framework.TreeControlNode<Entities.ProductCategory>> TreeControl_OnGetNodes(TreeNode parent, Entities.ProductCategory obj)
        {
            List<TreeControlNode<Entities.ProductCategory>> nodes = new List<TreeControlNode<Entities.ProductCategory>>();
            if(parent == null)
            {
                var rootCategories = catRepo.GetByParentCategoryId(null);
                return rootCategories.Where(cat=>!cat.Deleted).Select(cat => new TreeControlNode<Entities.ProductCategory>()
                {
                    Text = cat.Title,
                    Object = cat
                });
            }
            else
            {
                var parentCategory = obj;
                var rootCategories = catRepo.GetByParentCategoryId(parentCategory.Id);
                return rootCategories.Where(cat => !cat.Deleted).Select(cat => new TreeControlNode<Entities.ProductCategory>()
                {
                    Text = cat.Title,
                    Object = cat
                });
            }
        }

        public override string ViewTitle => "مدیریت دسته بندی محصولات";
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte Age { get; set; }
    }
}