using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;

namespace IISPLParserGenerator
{
   public  class CalcParser : IISPLParserGenerator.LRParser 
    {

/*
Yacc source code for a calculator parser .
file name : CalcParser.yacc
*/

public void Test(string fn)
{
lexan.install(fn);
Parse();
}

     
        protected override void Action(int pn)
        {
            switch(pn)
            {
                case 0 : ; break;
                case 1 : { Console.WriteLine(S[2]); }; break;
                case 2 : { S[0]=S[1]; }; break;
                case 3 : { S[0] = (float)S[1] + (float)S[3]; }; break;
                case 4 : { S[0] = (float)S[1] - (float)S[3]; }; break;
                case 5 : { S[0]=S[1]; }; break;
                case 6 : { S[0] = (float)S[1] * (float)S[3]; }; break;
                case 7 : { S[0] = (float)S[1] / (float)S[3]; }; break;
                case 8 : { S[0]=S[1]; }; break;
                case 9 : { S[0] = S[2]; }; break;
                case 10 : { S[0]=S[1]; }; break;
                default:
                     break;
            }
            


          }
        protected override void install()
        {
            lexan = new CalcScanner();

            A.Add(0,"", 'r' , 2);
            A.Add(0,"(", 'r' , 2);
            A.Add(0,"NUM", 'r' , 2);
            A.Add(1,"", 'a' , 0);
            A.Add(1,"(", 's' , 5);
            A.Add(1,"NUM", 's' , 6);
            A.Add(2,"+", 's' , 8);
            A.Add(2,"-", 's' , 7);
            A.Add(2,"CR", 's' , 9);
            A.Add(3,")", 'r' , 8);
            A.Add(3,"*", 'r' , 8);
            A.Add(3,"+", 'r' , 8);
            A.Add(3,"-", 'r' , 8);
            A.Add(3,"/", 'r' , 8);
            A.Add(3,"CR", 'r' , 8);
            A.Add(4,")", 'r' , 5);
            A.Add(4,"*", 's' , 10);
            A.Add(4,"+", 'r' , 5);
            A.Add(4,"-", 'r' , 5);
            A.Add(4,"/", 's' , 11);
            A.Add(4,"CR", 'r' , 5);
            A.Add(5,"(", 's' , 5);
            A.Add(5,"NUM", 's' , 6);
            A.Add(6,")", 'r' , 10);
            A.Add(6,"*", 'r' , 10);
            A.Add(6,"+", 'r' , 10);
            A.Add(6,"-", 'r' , 10);
            A.Add(6,"/", 'r' , 10);
            A.Add(6,"CR", 'r' , 10);
            A.Add(7,"(", 's' , 5);
            A.Add(7,"NUM", 's' , 6);
            A.Add(8,"(", 's' , 5);
            A.Add(8,"NUM", 's' , 6);
            A.Add(9,"", 'r' , 1);
            A.Add(9,"(", 'r' , 1);
            A.Add(9,"NUM", 'r' , 1);
            A.Add(10,"(", 's' , 5);
            A.Add(10,"NUM", 's' , 6);
            A.Add(11,"(", 's' , 5);
            A.Add(11,"NUM", 's' , 6);
            A.Add(12,")", 's' , 17);
            A.Add(12,"+", 's' , 8);
            A.Add(12,"-", 's' , 7);
            A.Add(13,")", 'r' , 4);
            A.Add(13,"*", 's' , 10);
            A.Add(13,"+", 'r' , 4);
            A.Add(13,"-", 'r' , 4);
            A.Add(13,"/", 's' , 11);
            A.Add(13,"CR", 'r' , 4);
            A.Add(14,")", 'r' , 3);
            A.Add(14,"*", 's' , 10);
            A.Add(14,"+", 'r' , 3);
            A.Add(14,"-", 'r' , 3);
            A.Add(14,"/", 's' , 11);
            A.Add(14,"CR", 'r' , 3);
            A.Add(15,")", 'r' , 6);
            A.Add(15,"*", 'r' , 6);
            A.Add(15,"+", 'r' , 6);
            A.Add(15,"-", 'r' , 6);
            A.Add(15,"/", 'r' , 6);
            A.Add(15,"CR", 'r' , 6);
            A.Add(16,")", 'r' , 7);
            A.Add(16,"*", 'r' , 7);
            A.Add(16,"+", 'r' , 7);
            A.Add(16,"-", 'r' , 7);
            A.Add(16,"/", 'r' , 7);
            A.Add(16,"CR", 'r' , 7);
            A.Add(17,")", 'r' , 9);
            A.Add(17,"*", 'r' , 9);
            A.Add(17,"+", 'r' , 9);
            A.Add(17,"-", 'r' , 9);
            A.Add(17,"/", 'r' , 9);
            A.Add(17,"CR", 'r' , 9);
          O.Add(0,"line",1);
          O.Add(1,"expr",2);
          O.Add(1,"factor",3);
          O.Add(1,"term",4);
          O.Add(5,"expr",12);
          O.Add(5,"factor",3);
          O.Add(5,"term",4);
          O.Add(7,"factor",3);
          O.Add(7,"term",13);
          O.Add(8,"factor",3);
          O.Add(8,"term",14);
          O.Add(10,"factor",15);
          O.Add(11,"factor",16);      


           G.Add(G.N," line' expr factor line term"); 
           G.Add(G.T," - ( ) * / + CR NUM");
            P.Add("line -> line expr CR");
            P.Add("line -> ");
            P.Add("expr -> expr + term");
            P.Add("expr -> expr - term");
            P.Add("expr -> term");
            P.Add("term -> term * factor");
            P.Add("term -> term / factor");
            P.Add("term -> factor");
            P.Add("factor -> ( expr )");
            P.Add("factor -> NUM");
       }
    }
}