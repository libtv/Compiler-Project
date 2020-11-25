%{
    CSymbolTable st=new CSymbolTable();
%}

ws 	[\,\ \t\n\r]*
digit 	[0-9]
letter 	[a-zA-Z]
id 	{letter}({letter}|{digit})*
optsign 	(\-|\+)?
indices    {optsign}{digit}+\.{digit}+{letter}({letter}|{digit})*
num 	{optsign}{digit}+
dnum      {optsign}{digit}+\.{digit}+
op 	[+\-*/=;{}()[\]]
rel_op 	<|<=|<>|>|>=


%%
{ws} 	{return("T_ws");}
{id} 	{yyoval=install_id(lexbuf); return(st[(int)yyoval].token);}
{num} 	{yyoval=int.Parse(lexbuf); return("T_num");}
{indices} {yyoval=lexbuf; return("T_indices");}
{dnum}   {yyoval=double.Parse(lexbuf); return("T_dnum");}

{op} 	{return(lexbuf);}
{rel_op} 	{yyoval=lexbuf; return("T_relop");}
%%

public void Test(string path)
{
	install(path); 
	install_reserved_words();
	do {
		yyoval="";
		string tok = (string)lexan();
		if (tok == "T_ws") { }
		else if (tok == "T_id"){ 
			Item item = st[(int)yyoval];
			Console.WriteLine(string.Format("{0}\t{1}\t{2}SybolTable[{3}]",
			tok.PadLeft(12), item.lexeme, item.attribute, yyoval));
		}

		else if (tok == "T_num" || tok == "T_relop" || tok == "T_dnum" || tok == "T_indices")
			Console.WriteLine(string.Format("{0}\t{1}", tok.PadLeft(12), yyoval));

		else Console.WriteLine(string.Format("{0:10}", tok.PadLeft(12)));
		} while(!IsDone());
	Console.WriteLine(st.ToString()); 
	Console.ReadKey(); 
}

public void install_reserved_words() {
	st.Add("T_if", "if");
	st.Add("T_int", "int");
	st.Add("T_double", "double");
	st.Add("T_indices", "indices");
              st.Add("T_foreach", "foreach");
              st.Add("T_in", "in");
}

public int install_id(string lexeme) {
	int idx=st.Look_Up(lexeme);
	if(idx != -1 ) return idx;
	st.Add("T_id", lexeme);
	return st.Count-1;
}