using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iSharpPdf = iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace TextEncryptor.Pdf {
    class PdfReader {
        readonly private string BookPath;

        private iSharpPdf.PdfReader Reader;

        public PdfReader(string BookPath) {
            this.BookPath = BookPath;
            this.LoadFile();
        }

        public int GetNumberOfPages() {
            return Reader.NumberOfPages;
        }

        public string GetTextFromPage(int page) {
            return PdfTextExtractor.GetTextFromPage(Reader, page);
        }

        private void LoadFile() {
            Reader = new iSharpPdf.PdfReader(BookPath);
        }
    }
}
