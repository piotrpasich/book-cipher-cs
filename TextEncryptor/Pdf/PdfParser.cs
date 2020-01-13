using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEncryptor.Crypto;
//using iTextSharp.text.pdf;
//using iTextSharp.text.pdf.parser;

namespace TextEncryptor.Pdf {
    class PdfParser {
        readonly private PdfReader PdfReader;

        public PdfParser(PdfReader PdfReader) {
            this.PdfReader = PdfReader;
        }

        public int GetNumberOfPages() {
            return PdfReader.GetNumberOfPages();
        }

        public Place GetPlace(int page, char letter) {
            string textOnPage = PdfReader.GetTextFromPage(page);

            return new Place(page, textOnPage.IndexOf(letter));
        }

        public char GetChar(int page, int place) {
            string textOnPage = PdfReader.GetTextFromPage(page);

            return textOnPage[place];
        }
    }
}
