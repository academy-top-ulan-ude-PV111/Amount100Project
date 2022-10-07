namespace Amount100Project
{
    enum Code
    {
        Gluing,
        Minus,
        Plus
    }
    internal class Program
    {

        static int CalculateExpresion(string str)
        {
            int operandLeft = 0;
            int operandRight = 0;
            char sign = '+';

            //for(int i = 0; i < str.Length; i++)
            int i = 0;
            do
            {
                if (!(i == str.Length || str[i] == '+' || str[i] == '-'))
                    operandRight = operandRight * 10 + Int32.Parse(str[i].ToString());
                else
                {
                    switch (sign)
                    {
                        case '+':
                            operandLeft += operandRight; break;
                        case '-':
                            operandLeft -= operandRight; break;
                        default:
                            break;
                    }
                    if (i == str.Length) break;
                    sign = str[i];
                    operandRight = 0;
                }
                i++;
            }
            while (i <= str.Length);

            //switch (sign)
            //{
            //    case '+':
            //        operandLeft += operandRight; break;
            //    case '-':
            //        operandLeft -= operandRight; break;
            //    default:
            //        break;
            //}

            return operandLeft;
        }

        static string CreateExpresion(int number)
        {
            
            char digit = '1';
            string strResult = "";
            strResult += digit++;

            while(number != 0)
            {
                switch ((Code)(number % 3))
                {
                    case Code.Plus:
                        strResult += '+'; break;
                    case Code.Minus:
                        strResult += '-'; break;
                    default:
                        break;
                }
                strResult += digit++;
                number /= 3;
            }

            while(digit <= '9')
                strResult += digit++;

            return strResult;
        }
        static void Main(string[] args)
        {
            for (int num = 0; num < Math.Pow(3, 8); num++)
            {
                string str = CreateExpresion(num);
                int result = CalculateExpresion(str);
                if (result == 100)
                    Console.WriteLine(str + " = " + result.ToString());
            }

            //Console.WriteLine(CalculateExpresion("123+45-67+8-9"));

        }
    }
}