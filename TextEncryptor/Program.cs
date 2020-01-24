using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TextEncryptor.Args;
using TextEncryptor.Pdf;
using TextEncryptor.Crypto;
using TextEncryptor.Errors;

namespace TextEncryptor {
    class Program {

        static int Main(string[] args) {
            ArgsParser ArgsParser = new ArgsParser();
            if (!ArgsParser.Validate(args)) {
                return 0;
            }

            PdfReader PdfReader = new PdfReader(ArgsParser.GetBookPath());
            PdfParser PdfParser = new PdfParser(PdfReader);

            string result = "No action has been executed";

            if (ArgsParser.GetMode() == ArgsParser.Mode.Encode) {
                try {
                    Encoder Encoder = new Encoder(PdfParser);
                    result = string.Format("Encoded text: {0}", Encoder.Encode(ArgsParser.GetText()));
                } catch (EncodeException e) {
                    result = e.Message;
                } catch (Exception e) {
                    result = "Couldn't encode this string. ";
                }
            }
            if (ArgsParser.GetMode() == ArgsParser.Mode.Decode) {
                try {
                    Decoder Decoder = new Decoder(PdfParser);
                    result = string.Format("Decoded text: {0}", Decoder.Decode(ArgsParser.GetText()));
                } catch (Exception e) {
                    result = "Couldn't decode this string.";
                }
            }

            Console.WriteLine(result);

            return 1;
        }
    }
}
