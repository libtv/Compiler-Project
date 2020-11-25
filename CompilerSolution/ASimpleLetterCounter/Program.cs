using System;
using IISPLParserGenerator;

namespace ASimpleLetterCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            new myLexicalAnalyzer().Test("../../../data.txt");
        }
    }
}
