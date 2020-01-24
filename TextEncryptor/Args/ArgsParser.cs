using NDesk.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEncryptor.Args {
    class ArgsParser {
        public enum Mode { Decode, Encode };
        private string BookPath = @".\Resources\Books\book.pdf";
        private string Text;
        private Mode CryptoMode = Mode.Encode;
        private bool HelpOption = false;

        public bool Validate (string[] args) {
            OptionSet p = new OptionSet() {
                { "?|h|help",  "   | Shows this message and exits", v => HelpOption = v != null },
                { "b|book=", "Path to the PDF file (ex. -b \"C:\\Users\\papi\\Downloads\\ppp.pdf\" )", v => BookPath = v },
                { "t|text=", "The text to encode or decode. If this is not set, the text will be taken from the string included to the command.", (string v) => Text = v },
                { "d|decrypt", "Decode mode (ex. -d or --decrypt)", v => { CryptoMode = Mode.Decode; }},
                { "e|encrypt", "Encode mode enabled by default (ex. -e or --encrupt)", v => { CryptoMode = Mode.Encode; }},
            };

            List<string> extra = p.Parse(args);

            if (HelpOption) {
                ShowHelp(p);

                return false;
            }

            if (args.Length == 0) {
                Console.WriteLine("Please enter a string which should be encoded or decoded");

                return false;
            }


            if (extra.Count() > 0) {
                Text = String.Join(" ", extra);
            }


            BookPath = Path.GetFullPath(BookPath);

            if (!File.Exists(BookPath)) {
                Console.WriteLine("File " + BookPath + " does not exist");

                return false;
            }

            Console.WriteLine("Loaded Book File: " + BookPath);
            Console.WriteLine("Text to " + (CryptoMode == Mode.Encode ? "encode" : "decode") + ": " + Text);

            return true;
        }

        public string GetBookPath() {
            return BookPath;
        }

        public string GetText () {
            return Text;
        }

        public Mode GetMode() {
            return CryptoMode;
        }

        private void ShowHelp(OptionSet p) {
            Console.WriteLine("Usage: greet [OPTIONS]+ message");
            Console.WriteLine("Greet a list of individuals with an optional message.");
            Console.WriteLine("If no message is specified, a generic greeting is used.");
            Console.WriteLine();
            Console.WriteLine("Options:");
            p.WriteOptionDescriptions(Console.Out);
        }
    }
}
