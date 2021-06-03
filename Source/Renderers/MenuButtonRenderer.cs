using Notepad.Source.Renderers.ColorTables;
using System.Windows.Forms;

namespace Notepad.Source.Renderers {
    class MenuButtonRenderer : ToolStripProfessionalRenderer {
        public MenuButtonRenderer() : base(new MenuButtonColorTable()) {}
    }
}
