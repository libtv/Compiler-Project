using System;
using IISPLParserGenerator;

namespace SimpleLexcialAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            new myLexicalAnalyzer().Test("../../../if_c.txt");
        }
    }
}
