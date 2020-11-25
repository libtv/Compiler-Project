%{
/*
Yacc source code for a calculator parser .
file name : CalcParser.yacc
*/
%}
%token + - * / ( ) NUM CR
%%
line : line expr CR { Console.WriteLine($2); }
|
;
expr : expr + term { $$ = (float)$1 + (float)$3; }
| expr - term { $$ = (float)$1 - (float)$3; }
| term
;
term : term * factor { $$ = (float)$1 * (float)$3; }
| term / factor { $$ = (float)$1 / (float)$3; }
| factor
;
factor : ( expr ) { $$ = $2; }
| NUM
;
%%
%{
public void Test(string fn)
{
lexan.install(fn);
Parse();
}
%}