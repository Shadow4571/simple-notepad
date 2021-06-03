using Notepad.Source.Commands;
using Notepad.Source.Main;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace notepad.Source.Commands.Command {
    class PrintDocumentCommand : ICommand {
        private NotepadForm _form;
        private Font _font;

        public PrintDocumentCommand(NotepadForm form) {
            _form = form;
            _font = new Font(FontFamily.GenericSansSerif, 12.0f);
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e) {
            int charactersOnPage = 0;
            int linesPerPage = 0;
            string text = _form.GetText();

            e.Graphics.MeasureString(text, _font,
                e.MarginBounds.Size, StringFormat.GenericTypographic,
                out charactersOnPage, out linesPerPage);

            e.Graphics.DrawString(text, _font, Brushes.Black,
                e.MarginBounds, StringFormat.GenericTypographic);

            text = text.Substring(charactersOnPage);

            e.HasMorePages = (text.Length > 0);
        }

        public void Execute() {
            PrintDialog printDialog = new PrintDialog();
            PrintDocument printer = new PrintDocument();

            printDialog.Document = printer;

            if(printDialog.ShowDialog() != DialogResult.OK) {
                return;
            }

            printer.PrinterSettings = printDialog.PrinterSettings;
            printer.PrintPage += printDocument_PrintPage;

            try {
                printer.Print();
            } catch (Exception exp) {
                MessageBox.Show($"Print Error!\n{exp.Message}", "Notepad print error.");
            }
        }
    }
}
