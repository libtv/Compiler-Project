%{
    /* A Lex Program for A Simple Letter Counter
    file name : Test.lex
    tokens : word, CR,
    2020. 04. 12
    Jun Ho Kim
    */
    int EmailNo=0, WordNo=0, CharacterNo=0, LnNo=0, FloatNo=0, IntNo=0, RealNo=0, IdentNo=0, DateNo=0, InfoNo;
%}

alpha    [a-z]
integer   [0-9]|[0-9]+
digit      [0-9]
date      [1-9]{digit}{digit}{digit}.{digit}{digit}.{digit}{digit}
info       [1-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]
word     ({alpha}|{digit})+
email    {word}@{word}\.{word}
CR       [\n]
email2    {word}@{word}\.{word}\.{word}
float      [0-9]+\.[0-9]+
ereal     [0-9]+[A-Z]+{digit}+
identify  {alpha}({alpha}|[A-Z]|{digit})+


%%
{email}  { EmailNo++;   return("EMAIL");}
{date}    { DateNo++; return("DATE");}
{info}     { InfoNo++; return("INFO");}
{CR}     { LnNo++;    CharacterNo++;                    return("CR"); }
{ereal}    {RealNo++; return("RealNo");}
{identify}  {IdentNo++; return("IdentNo");}
{integer} { IntNo++; return("INTEGER"); }
.|\r       { CharacterNo++;   return(lexbuf); }
{float} { FloatNo++; return("FLOAT"); }
{word}  { WordNo++; CharacterNo+=lexbuf.Length; return("WORD");}
{email2}   { EmailNo++;   return("EMAIL");}
%%

public void Test(string fn) {
    install(fn);
    do {
        string t = (string) lexan();
        Console.WriteLine("["+t+"]"+lexbuf);
    } while(!IsDone());
    Console.Write("Intger No: " + IntNo + " float No: " + FloatNo + " realNo : " + RealNo  + "idnetiNo = " + IdentNo + " emailNo: " + EmailNo + " dateNo " + DateNo + " InfoNo" + InfoNo);
}