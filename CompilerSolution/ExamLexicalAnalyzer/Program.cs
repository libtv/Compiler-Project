using System;
using IISPLParserGenerator;

namespace ExamLexicalAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            new myLexicalAnalyzer().Test("../../../if_c.txt");
        }
    }
}
