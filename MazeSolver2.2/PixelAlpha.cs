using System;
using System.Drawing;

namespace MazeSolver2._2
{
    public class PixelAlpha
    {

        public bool[] GetPixelCharacter(char character)
        {
            switch (character)
            {
                case 'A':
                    return upperA;
                case 'B':
                    return upperB;
                case 'C':
                    return upperC;
                case 'D':
                    return upperD;
                case 'E':
                    return upperE;
                case 'F':
                    return upperF;
                case 'G':
                    return upperG;
                case 'H':
                    return upperH;
                case 'I':
                    return upperI;
                case 'J':
                    return upperJ;
                case 'K':
                    return upperK;
                case 'L':
                    return upperL;
                case 'M':
                    return upperM;
                case 'N':
                    return upperN;
                case 'O':
                    return upperO;
                case 'P':
                    return upperP;
                case 'Q':
                    return upperQ;
                case 'R':
                    return upperR;
                case 'S':
                    return upperS;
                case 'T':
                    return upperT;
                case 'U':
                    return upperU;
                case 'V':
                    return upperV;
                case 'W':
                    return upperW;
                case 'X':
                    return upperX;
                case 'Y':
                    return upperY;
                case 'Z':
                    return upperZ;
                
                //Lower Case
                
                case 'a':
                    return a;
                case 'b':
                    return b;
                case 'c':
                    return c;
                case 'd':
                    return d;
                case 'e':
                    return e;
                case 'f':
                    return f;
                case 'g':
                    return g;
                case 'h':
                    return h;
                case 'i':
                    return i;
                case 'j':
                    return j;
                case 'k':
                    return k;
                case 'l':
                    return l;
                case 'm':
                    return m;
                case 'n':
                    return n;
                case 'o':
                    return o;
                case 'p':
                    return p;
                case 'q':
                    return q;
                case 'r':
                    return r;
                case 's':
                    return s;
                case 't':
                    return t;
                case 'u':
                    return u;
                case 'v':
                    return v;
                case 'w':
                    return w;
                case 'x':
                    return x;
                case 'y':
                    return y;
                case 'z':
                    return z;
                
                //Numbers
                case '1':
                    return one;
                case '2':
                    return two;
                case '3':
                    return three;
                case '4':
                    return four;
                case '5':
                    return five;
                case '6':
                    return six;
                case '7':
                    return seven;
                case '8':
                    return eight;
                case '9':
                    return nine;
                case '0':
                    return zero;
                
                //Symbols
                
                case '.':
                    return fullstop;
                case ',':
                    return comma;
                case '"':
                    return quotationMarks;
                case '\'':
                    return singleQuotations;
                case '?':
                    return questionMark;
                case '!':
                    return explimationMark;
                case '@':
                    return ampersand;
                case '_':
                    return underscore;
                case '*':
                    return asterisk;
                case '#':
                    return hashtag;
                case '$':
                    return dollarSign;
                case '%':
                    return percentSymbol;
                case '&':
                    return andSymbol;
                case '(':
                    return openingBracket;
                case ')':
                    return closingBracket;
                case '+':
                    return plus;
                case '-':
                    return minus;
                case '/':
                    return forwardSlash;
                case ':':
                    return colon;
                case ';':
                    return semiColon;
                case '<':
                    return lessThan;
                case '=':
                    return equals;
                case '>':
                    return greaterThan;
                case '[':
                    return openingSquareBracket;
                case '\\':
                    return backSlash;
                case ']':
                    return closingSquareBracket;
                case '^':
                    return caret;
                case '`':
                    return acute;
                case '{':
                    return openingSquiggleBracket;
                case '|':
                    return straightLine;
                case '}':
                    return closingBracket;
                case '~':
                    return tilde;
                case ' ':
                    return space;
            }

            return null;
        }
        
        bool[] upperA = { true, true, true, false, true, false, true, false, true, true, true, false, true, false, true, false, true, false, true, false};
        bool[] upperB = { true, true, false, false, true, false, true, false, true, true, false, false, true, false, true, false, true, true, false, false};
        bool[] upperC = { false, true, true, false, true, false, false, false, true, false, false, false, true, false, false, false, false, true, true, false};
        bool[] upperD = { true, true, false, false, true, false, true, false, true, false, true, false, true, false, true, false, true, true, false, false};
        bool[] upperE = { true, true, true, false, true, false, false, false, true, true, true, false, true, false, false, false, true, true, true, false};
        bool[] upperF = { true, true, true, false, true, false, false, false, true, true, false, false, true, false, false, false, true, false, false, false};
        bool[] upperG = { false, true, true, false, true, false, false, false, true, false, true, false, true, false, true, false, false, true, true, false};
        bool[] upperH = { true, false, true, false, true, false, true, false, true, true, true, false, true, false, true, false, true, false, true, false};
        bool[] upperI = { true, true, true, false, false, true, false, false, false, true, false, false, false, true, false, false, true, true, true, false};
        bool[] upperJ = { true, true, true, false, false, false, true, false, false, false, true, false, true, false, true, false, true, true, true, false};
        bool[] upperK = { true, false, true, false, true, false, true, false, true, true, false, false, true, false, true, false, true, false, true, false};
        bool[] upperL = { true, false, false, false, true, false, false, false, true, false, false, false, true, false, false, false, true, true, true, false};
        bool[] upperM = { true, false, true, false, true, true, true, false, true, false, true, false, true, false, true, false, true, false, true, false};
        bool[] upperN = { true, true, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false};
        bool[] upperO = { true, true, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, true, true, false};
        bool[] upperP = { true, true, true, false, true, false, true, false, true, true, true, false, true, false, false, false, true, false, false, false};
        bool[] upperQ = { true, true, false, false, true, true, false, false, true, true, false, false, true, true, false, false, true, true, true, false};
        bool[] upperR = { true, true, false, false, true, false, true, false, true, true, false, false, true, false, true, false, true, false, true, false};
        bool[] upperS = { false, true, true, false, true, false, false, false, false, true, false, false, false, false, true, false, true, true, false, false};
        bool[] upperT = { true, true, true, false, false, true, false, false, false, true, false, false, false, true, false, false, false, true, false, false};
        bool[] upperU = { true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, true, true, false};
        bool[] upperV = { true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, true, false, false};
        bool[] upperW = { true, false, true, false, true, false, true, false, true, false, true, false, true, true, true, false, true, false, true, false};
        bool[] upperX = { true, false, true, false, true, false, true, false, false, true, false, false, true, false, true, false, true, false, true, false};
        bool[] upperY = { true, false, true, false, true, false, true, false, true, true, true, false, false, true, false, false, false, true, false, false};
        bool[] upperZ = { true, true, true, false, false, false, true, false, false, true, false, false, true, false, false, false, true, true, true, false};
        bool[] a = { true, true, true, false, false, false, true, false, true, true, true, false, true, false, true, false, true, true, true, false};
        bool[] b = { true, false, false, false, true, false, false, false, true, true, true, false, true, false, true, false, true, true, true, false};
        bool[] c = { false, false, false, false, false, false, false, false, true, true, true, false, true, false, false, false, true, true, true, false};
        bool[] d = { false, false, true, false, false, false, true, false, true, true, true, false, true, false, true, false, true, true, true, false};
        bool[] e = { true, true, true, false, true, false, true, false, true, true, true, false, true, false, false, false, true, true, true, false};
        bool[] f = { false, true, true, false, false, true, false, false, true, true, true, false, false, true, false, false, false, true, false, false};
        bool[] g = { false, false, true, false, true, true, true, false, true, true, true, false, false, false, true, false, true, true, true, false};
        bool[] h = { true, false, false, false, true, false, false, false, true, true, true, false, true, false, true, false, true, false, true, false};
        bool[] i = { false, false, true, false, false, false, false, false, false, false, true, false, false, false, true, false, false, false, true, false};
        bool[] j = { false, false, true, false, false, false, false, false, false, false, true, false, false, false, true, false, true, true, true, false};
        bool[] k = { true, false, false, false, true, false, false, false, true, false, true, false, true, true, false, false, true, false, true, false};
        bool[] l = { true, true, false, false, false, true, false, false, false, true, false, false, false, true, false, false, false, true, true, false};
        bool[] m = { false, false, false, false, false, false, false, false, true, true, true, false, true, true, true, false, true, false, true, false};
        bool[] n = { false, false, false, false, false, false, false, false, true, true, true, false, true, false, true, false, true, false, true, false};
        bool[] o = { false, false, false, false, false, false, false, false, true, true, true, false, true, false, true, false, true, true, true, false};
        bool[] p = { false, false, false, false, true, true, true, false, true, false, true, false, true, true, true, false, true, false, false, false};
        bool[] q = { false, false, false, false, true, true, true, false, true, false, true, false, true, true, true, false, false, false, true, false};
        bool[] r = { false, false, false, false, false, false, false, false, true, true, true, false, true, false, false, false, true, false, false, false};
        bool[] s = { false, false, false, false, true, true, true, false, true, true, false, false, false, true, true, false, true, true, true, false};
        bool[] t = { false, true, false, false, true, true, true, false, false, true, false, false, false, true, false, false, false, true, false, false};
        bool[] u = { false, false, false, false, false, false, false, false, true, false, true, false, true, false, true, false, true, true, true, false};
        bool[] v = { false, false, false, false, false, false, false, false, true, false, true, false, true, false, true, false, true, true, false, false};
        bool[] w = { false, false, false, false, false, false, false, false, true, false, true, false, true, true, true, false, true, true, true, false};
        bool[] x = { false, false, false, false, false, false, false, false, true, false, true, false, false, true, false, false, true, false, true, false};
        bool[] y = { true, false, true, false, true, false, true, false, true, true, true, false, false, false, true, false, true, true, true, false};
        bool[] z = { false, false, false, false, true, true, true, false, false, true, true, false, true, true, false, false, true, true, true, false};
        bool[] zero = { false, true, false, false, true, false, true, false, true, false, true, false, true, false, true, false, false, true, false, false};
        bool[] one = { false, true, false, false, true, true, false, false, false, true, false, false, false, true, false, false, true, true, true, false};
        bool[] two = { true, true, false, false, false, false, true, false, false, true, false, false, true, false, false, false, true, true, true, false};
        bool[] three = { true, true, true, false, false, false, true, false, false, true, true, false, false, false, true, false, true, true, true, false};
        bool[] four = { true, false, true, false, true, false, true, false, true, true, true, false, false, false, true, false, false, false, true, false};
        bool[] five = { true, true, true, false, true, false, false, false, true, true, true, false, false, false, true, false, true, true, false, false};
        bool[] six = { false, true, true, false, true, false, false, false, true, true, true, false, true, false, true, false, true, true, true, false};
        bool[] seven = { true, true, true, false, false, false, true, false, false, true, false, false, true, false, false, false, true, false, false, false};
        bool[] eight = { true, true, true, false, true, false, true, false, true, true, true, false, true, false, true, false, true, true, true, false};
        bool[] nine = { true, true, true, false, true, false, true, false, true, true, true, false, false, false, true, false, true, true, false, false};
        bool[] fullstop = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false};
        bool[] space = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false};
        bool[] comma = { false, false, false, false, false, false, false, false, false, false, false, false, false, true, true, false, false, false, true, false};
        bool[] quotationMarks = { true, false, true, false, true, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false};
        bool[] singleQuotations = { false, false, true, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false};
        bool[] questionMark = { true, true, true, false, false, false, true, false, false, true, true, false, false, false, false, false, false, true, false, false};
        bool[] explimationMark = { false, false, true, false, false, false, true, false, false, false, true, false, false, false, false, false, false, false, true, false};
        bool[] andSymbol = { true, true, true, false, true, false, true, false, true, false, true, false, true, false, false, false, true, true, true, false};
        bool[] underscore = { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true, true, false};
        bool[] asterisk = { true, false, true, false, false, true, false, false, true, false, true, false, false, false, false, false, false, false, false, false};
        bool[] hashtag = { true, false, true, false, true, true, true, false, true, false, true, false, true, true, true, false, true, false, true, false};
        bool[] dollarSign = { true, true, true, false, true, true, false, false, true, true, true, false, false, true, true, false, true, true, true, false};
        bool[] percentSymbol = { true, false, true, false, false, false, true, false, false, true, false, false, true, false, false, false, true, false, true, false};
        bool[] ampersand = { true, true, false, false, true, false, false, false, true, true, true, false, true, false, false, false, true, true, true, false};
        bool[] openingBracket = { false, false, true, false, false, true, false, false, false, true, false, false, false, true, false, false, false, false, true, false};
        bool[] closingBracket = { true, false, false, false, false, true, false, false, false, true, false, false, false, true, false, false, true, false, false, false};
        bool[] plus = { false, false, false, false, false, true, false, false, true, true, true, false, false, true, false, false, false, false, false, false};
        bool[] minus = { false, false, false, false, false, false, false, false, true, true, true, false, false, false, false, false, false, false, false, false};
        bool[] forwardSlash = { false, false, true, false, false, false, true, false, false, true, false, false, true, false, false, false, true, false, false, false};
        bool[] colon = { false, false, false, false, false, false, true, false, false, false, false, false, false, false, true, false, false, false, false, false};
        bool[] semiColon = { false, false, false, false, false, false, true, false, false, false, false, false, false, true, true, false, false, false, true, false};
        bool[] lessThan = { false, false, true, false, false, true, false, false, true, false, false, false, false, true, false, false, false, false, true, false};
        bool[] equals = { false, false, false, false, true, true, true, false, false, false, false, false, true, true, true, false, false, false, false, false};
        bool[] greaterThan = { true, false, false, false, false, true, false, false, false, false, true, false, false, true, false, false, true, false, false, false};
        bool[] openingSquareBracket = { false, true, true, false, false, true, false, false, false, true, false, false, false, true, false, false, false, true, true, false};
        bool[] backSlash = { true, false, false, false, true, false, false, false, false, true, false, false, false, false, true, false, false, false, true, false};
        bool[] closingSquareBracket = { true, true, false, false, false, true, false, false, false, true, false, false, false, true, false, false, true, true, false, false};
        bool[] caret = { false, true, false, false, true, false, true, false, true, false, true, false, false, false, false, false, false, false, false, false};
        bool[] acute = { false, true, false, false, false, false, true, false, false, false, false, false, false, false, false, false, false, false, false, false};
        bool[] openingSquiggleBracket = { false, true, true, false, false, true, false, false, true, false, false, false, false, true, false, false, false, true, true, false};
        bool[] straightLine = { false, false, true, false, false, false, true, false, false, false, true, false, false, false, true, false, false, false, true, false};
        bool[] closingSquiggleBracket = { true, true, false, false, false, true, false, false, false, false, true, false, false, true, false, false, true, true, false, false};
        bool[] tilde = { false, true, true, false, true, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false};


        public void Boi()
        {
            
            string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789.,\"'?!@_*#$%&()+-/:;<=>[\\]^`{|}~";
            var imageMap = new Bitmap(Image.FromFile("alphabet.png"));


            String largeOut = "";
            for (var j = 0; j < 8; j++)
            {
                for (var i = 0; i < 12; i++)
                {
                    string output = "bool[] ";
                    bool[] pixels = new bool[20];
                    for (var yOff = 0; yOff < 5; yOff++)
                    {
                        for (var xOff = 0; xOff < 4; xOff++)
                        {
                            int x = i * 4 + xOff;
                            int y = j * 6 + yOff;
                            
                            pixels[yOff * 4 + xOff] = imageMap.GetPixel(x, y) == Color.FromArgb(255, 255, 255, 255);

                        }   
                    }

                    if (j * 12 + i < 94)
                    {
                        char outp = alpha[j * 12 + i];
                        if (char.IsLetter(outp))
                        {
                            if (char.IsUpper(outp))
                            {
                                output = output + "upper" + outp;
                            }
                            else
                            {
                                output = output + outp;
                            }
                        }
                        else if (char.IsNumber(outp))
                        {
                            output = output + getNumber(outp);
                        }
                        else
                        {
                            output = output + getSpecialCharacterName(outp);
                        }

                        output = output + " = { ";

                        for (int ij = 0; ij < pixels.Length; ij++)
                        {
                            output = output + pixels[ij].ToString().ToLower();
                            
                            if (ij != pixels.Length - 1)
                            {
                                output = output + ", ";
                            }
                        }

                        largeOut = largeOut + output + "};\n";
                    }
                }
            }
            Console.WriteLine(largeOut);
        }

        private string getNumber(char c)
        {

            switch (c)
            {
                case '0' :
                    return "zero";
                case '1' :
                    return "one";
                case '2' :
                    return "two";
                case '3' :
                    return "three";
                case '4' :
                    return "four";
                case '5' :
                    return "five";
                case '6' :
                    return "six";
                case '7' :
                    return "seven";
                case '8' :
                    return "eight";
                case '9' :
                    return "nine";
            }

            return "error";
        }

        public string getSpecialCharacterName(char c)
        {
            switch (c)
            {
                    case '.' :
                        return "fullstop";
                case ',' :
                    return "comma";
                case '<' :
                    return "lessThan";
                case '>' :
                    return "greaterThan";
                case '/' :
                    return "forwardSlash";
                case '?' :
                    return "questionMark";
                case ';' :
                    return "semiColon";
                case ':' :
                    return "colon";
                case '\"' :
                    return "quotationMarks";
                case '\'' :
                    return "singleQuotations";
                case '[' :
                    return "openingSquareBracket";
                case '{' :
                    return "openingSquiggleBracket";
                case ']' :
                    return "closingSquareBracket";
                case '}' :
                    return "closingSquiggleBracket";
                case '\\' :
                    return "backSlash";
                case '|' :
                    return "straightLine";
                case '`' :
                    return "acute";
                case '~' :
                    return "tilde";
                case '!' :
                    return "explimationMark";
                case '@' :
                    return "andSymbol";
                case '#' :
                    return "hashtag";
                case '$' :
                    return "dollarSign";
                case '%' :
                    return "percentSymbol";
                case '^' :
                    return "caret";
                case '&' :
                    return "ampersand";
                case '*' :
                    return "asterisk";
                case '(' :
                    return "openingBracket";
                case ')' :
                    return "closingBracket";
                case '-' :
                    return "minus";
                case '_' :
                    return "underscore";
                case '+' :
                    return "plus";
                case '=' :
                    return "equals";
            }

            return "";
        }
        
    }
}