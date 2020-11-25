using System;
using IISPLParserGenerator;

namespace CompilerSolution_exam3
{
    class Program
    {
        static void Main(string[] args)
        {
            new myLexicalAnalyzer().Test("../../../data.txt");
        }
    }
}
