using System;
using System.Drawing;
using System.Windows.Forms;

namespace Notepad.Source.Renderers.ColorTables {
    class MenuButtonColorTable : ProfessionalColorTable {
        public override Color MenuBorder => Color.FromArgb(0, 0, 0, 0);

        public override Color MenuItemSelected => Color.FromArgb(100, 235, 235, 235);

        public override Color MenuItemSelectedGradientBegin => Color.FromArgb(100, 235, 235, 235);

        public override Color MenuItemSelectedGradientEnd => Color.FromArgb(100, 235, 235, 235);

        public override Color MenuItemPressedGradientBegin => Color.FromArgb(120, 150, 150, 150);

        public override Color MenuItemPressedGradientEnd => Color.FromArgb(120, 150, 150, 150);

        public override Color ButtonSelectedBorder => Color.FromArgb(0, 0, 0, 0);

        public override Color MenuItemBorder => Color.FromArgb(0, 0, 0, 0);

        public override Color ButtonSelectedGradientBegin => Color.FromArgb(0, 0, 0, 0);
    }
}
