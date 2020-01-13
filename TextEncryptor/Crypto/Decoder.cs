using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEncryptor.Pdf;
using TextEncryptor.Crypto;

namespace TextEncryptor.Crypto {
    class Decoder {
        readonly private PdfParser PdfParser;

        public Decoder(PdfParser PdfParser) {
            this.PdfParser = PdfParser;
        }

        public string Decode(string encodedText) {
            string decodedString = "";
            List<Place> places = ParseString(encodedText);
            foreach (Place place in places) {
                decodedString += PdfParser.GetChar(place.GetPage(), place.GetPlace());
            }

            return decodedString;
        }

        private List<Place> ParseString(string encodedText) {
            
            List<Place> places = new List<Place>();
            foreach (string pageAndLocalization in encodedText.Split(',')) {
                places.Add(new Place(pageAndLocalization));
            }

            return places;
        }
    }
}
