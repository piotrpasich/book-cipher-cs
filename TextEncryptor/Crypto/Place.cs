using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEncryptor.Crypto {
    class Place {
        readonly private int Page;
        readonly private int PlaceOnPage;

        public Place(string PageAndPlace) {
            string[] info = PageAndPlace.Split(':');
            Page = Int32.Parse(info.First());
            PlaceOnPage = Int32.Parse(info.Last());
        }

        public Place (int Page, int Localization) {
            this.Page = Page;
            this.PlaceOnPage = Localization;
        }

        public int GetPage() {
            return Page;
        }

        public int GetPlace() {
            return PlaceOnPage;
        }

        public string ToString() {
            return Page + ":" + PlaceOnPage;
        }
    }
}
