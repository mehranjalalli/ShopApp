using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopApp.Framework
{
    public class MenuHandler
    {
        private ToolStripItemCollection items;

        public MenuHandler(ToolStripItemCollection items)
        {
            this.items = items;
        }


        public MenuHandler AddMenu(string title)
        {
            var menu = items.Add(title, null, null);
            return new MenuHandler(((ToolStripMenuItem)menu).DropDownItems);
        }

        public void AddSeparator()
        {
            items.Add("-");
        }

        public MenuHandler AddMenu(string title, Image img)
        {
            var menu = (ToolStripMenuItem)items.Add(title, img, null);
            return new MenuHandler(menu.DropDownItems);
        }

        public MenuHandler AddMenu(string title, Image img, EventHandler eventHandler)
        {
            var menu = (ToolStripMenuItem)items.Add(title, img, eventHandler);
            return new MenuHandler(menu.DropDownItems);
        }
    }
}
