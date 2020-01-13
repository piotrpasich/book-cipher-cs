using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEncryptor.Errors;
using TextEncryptor.Pdf;

namespace TextEncryptor.Crypto {
    class Encoder {
        readonly private PdfParser PdfParser;

        readonly private int NumberOfTries = 100;

        public Encoder (PdfParser PdfParser) {
            this.PdfParser = PdfParser;
        }

        public string Encode (string text) {
            List<Place> places = new List<Place>();
            foreach (char letter in text) {
                Place place;
                int retried = 0;
                do {
                    place = PdfParser.GetPlace(GetRandomPage(), letter);
                    retried++;
                } while (place.GetPlace() == -1 && retried < NumberOfTries);

                if (retried == NumberOfTries) {
                    throw new EncodeException(letter);
                }

                places.Add(place);
            }
            
            return places.Aggregate("", (acc, x) => acc + "," + x.ToString()).Substring(1);
        }

        private int GetRandomPage() {
            Random r = new Random();

            return r.Next(0, PdfParser.GetNumberOfPages());
        }
    }
}
