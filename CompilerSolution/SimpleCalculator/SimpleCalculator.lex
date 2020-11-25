%{
/*
Lex source code for a simple calculator
File ame : CalcScanner1.lex
Tokens : + - * / CR ( ) NUM
*/
%}
delim [\t\r]
ws {delim}+
digit [0-9]
num {digit}+(\.{digit}+)?(E[+\-]?{digit}+)?
CR [\n]
op [+\-*/()]
%%
{ws} { return "WS";}
{num} { yyoval=float.Parse(lexbuf); return "NUM";}
{CR} { return "CR"; }
{op} { return lexbuf; }
. { return "WS"; }

%%
public void Test(string fn)
{
    install(fn);
    do {
        string token=(string)lexan();
        Console.WriteLine(token+"\t"+(token=="NUM"?yyoval:""));
    }
    while(!IsDone());
}