using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexical_Analyzer
{
    class TokenAnalyzer
    {
        string _token;
        char[] _dataArray;
        string[] _operators = { "+", "-", "*", "/", "%", "&","(",")","[","]",
            "|", "^", "!", "~", "&&", "||",",",
            "++", "--", "<<", ">>", "==", "!=", "<", ">", "<=",
            ">=", "=", "+=", "-=", "*=", "/=", "%=", "&=", "|=",
            "^=", "<<=", ">>=", ".", "[]", "()", "?:", "=>", "??" };
        string _specialChar = @"\|!#$%&/()=?»«*@£§€{}.-;'<>,";
        string[] _keywords = { "abstract", "as", "base", "bool", "break", "by",
            "byte", "case", "catch", "char", "checked", "class", "const",
            "continue", "decimal", "default", "delegate", "do", "double",
            "descending", "explicit", "event", "extern", "else", "enum",
            "false", "finally", "fixed", "float", "for", "foreach", "from",
            "goto", "group", "if", "implicit", "in", "int", "interface",
            "internal", "into", "is", "lock", "long", "new", "null", "namespace",
            "object", "operator", "out", "override", "orderby",  "params",
            "private", "protected", "public", "readonly", "ref", "return",
            "switch", "struct", "sbyte", "sealed", "short", "sizeof",
            "stackalloc", "static", "string", "select",  "this",
            "throw", "true", "try", "typeof", "uint", "ulong", "unchecked",
            "unsafe", "ushort", "using", "var", "virtual", "volatile",
            "void", "while", "where", "yield" };
        string _qmark = "\"'";

        public void input_check(string data)
        {
            int number;          
            
                if (data.All(char.IsDigit) == false)
                {
                    word_check(data);
                }
                else
                {
                    number = Convert.ToInt32(data);
                    numerical_check(number);
                }           
        }

        public void word_check(string data)
        {
            _dataArray = data.ToCharArray();

            if (_keywords.Contains(data) == true)
            {
                _token = "Keyword";
            }
            else if((Array.IndexOf(_operators, data) > -1) == true)
            {               
                _token = "Symbol";
            }
            else if(_qmark.Contains(_dataArray[0]) == true  && _qmark.Contains(_dataArray[data.Length-1]) == true)
            {
                _token = "String/Character Literal";
            }            
            else
            {
                variable(data);
            }

            answer(data, _token);

        }   
      
        public void numerical_check(int number)
        {
            _token = "Number";

            answer(number.ToString(), _token);
        }        

        public void variable(string data)
        {
            StringBuilder newVariable = new StringBuilder();

            _dataArray = data.ToCharArray();


            if (char.IsDigit(_dataArray[0]) == false || _dataArray[0] == '_')
            {
                for(int i=0; i<data.Length; i++)
                {
                
                    if (_specialChar.Contains(_dataArray[i]) == false)
                    {
                        newVariable.Append(_dataArray[i]);
                    }
                    else
                    {
                        _token = "Invalid Input!";
                    }
                }
                
                if(_token!= "Invalid Input")
                {
                    _token = "Variable";
                }                
            }
            else
            {
                _token = "Invalid Input!";
            }          
        }

        public void answer(string data, string _token)
        {
            Console.WriteLine(data + " = " + _token);
        }
    }
}
