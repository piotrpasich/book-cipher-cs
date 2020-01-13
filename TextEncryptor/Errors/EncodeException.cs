using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEncryptor.Errors {
    class EncodeException: Exception {
        private string _Message;
        public EncodeException(char letter) {
            _Message = "Cannot find match for " + letter + " sign";
        }

        public override string Message {
            get { return _Message; }
        }
    }
}
