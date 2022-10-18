grammar LabCalculator;

/*
* Parser Rules
*/

compileUnit : expression EOF;
expression :
	LPAREN expression RPAREN #ParenthesizedExpr
	|expression EXPONENT expression #ExponentialExpr
	| expression operatorToken=(MULTIPLY | DIVIDE) expression #MultiplicativeExpr
	| expression operatorToken=(ADD | SUBTRACT) expression #AdditiveExpr

	| expression operatorToken=(EQUAL | NOTEQUAL | LESSTHAN | LESSTHANEQUAL | GREATERTHAN | GREATERTHANEQUAL) expression #RelationalExpr
	| expression operatorToken=(AND | OR) expression #LogicalExpr
	
	| operatorToken=(MOD | DIV) LPAREN expression ',' expression RPAREN #ModDivExpr
	| MMAX LPAREN paramlist=arglist RPAREN #MmaxExpr
	| MMIN LPAREN paramlist=arglist RPAREN #MminExpr
	

	| NUMBER #NumberExpr
	| IDENTIFIER #IdentifierExpr
;

arglist: expression (',' expression)+;
paramlist: expression (',' expression)+;


/*
* Lexer Rules
*/

NUMBER : INT('.'INT)?;
IDENTIFIER : [a-zA-Z]+[1-9][0-9]+
	|[a-zA-Z]+[1-9]+;

INT : ('0'..'9')+;

EXPONENT :'^';
MULTIPLY : '*';
DIVIDE : '/';
SUBTRACT : '-';
ADD : '+';
LPAREN : '(';
RPAREN : ')';

EQUAL : '==';
NOTEQUAL : '!=';
LESSTHAN : '<';
LESSTHANEQUAL : '<=';
GREATERTHAN : '>';
GREATERTHANEQUAL : '>=';

AND : '&&';
OR : '||';

MOD: 'mod';
DIV: 'div';
MMAX: 'mmax';
MMIN: 'mmin';

WS : [ \t\r\n] -> channel(HIDDEN);