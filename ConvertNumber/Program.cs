using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConvertNumber
{
    class Program
    {

        //public void convertNumber (int numInput, out string words)
        //{
        
        //}
        static void Main(string[] args)
        {
            string[] numberName = { "","ONE", "TWO","THREE","FOUR","FIVE","SIX","SEVEN","EIGHT","NINE", "TEN", "ELEVEN", "TWELVE", "THIRTEEN", "FOURTEEN", "FIFTEEN", "SIXTEEN", "SEVENTEEN", "EIGHTEEN", "NINETEEN" };
            string[] digit2 = { "TWENTY", "THIRTY", "FORTY", "FIFTY", "SIXTY", "SEVENTY", "EIGHTY", "NINETY" };
            string[] groupOfThree = { "THOUSAND", "MILLION" };
            string pattern = @"^(\d+)\.(\d{2})$";
            string[][] threeDigit;
            var regex = new Regex(pattern);
            string number;
            string dollar="";
            string cents="";
            //byte dot = 0;
            //int dotPosition=0;
            //if(!float.TryParse(Console.ReadLine(),out number))
            //{
            //    Console.WriteLine("not a float number")
            //}
            number = Console.ReadLine();
            //MatchCollection result = Regex.Matches(number, pattern);
            Match result = regex.Match(number);
            GroupCollection data = result.Groups;
            dollar = data[1]. Value;
            cents = data[2].Value;


            //for (int i = 0; i < number.Length; ++i)
            //{
            //    if (number[i] == '.')
            //    {
            //        dot++;
            //        dotPosition = i;
            //    }
            //}
            ////if there is one dot or no dot
            //if (dot == 1 || dot == 0)
            //{
            //    if (dot==1)
            //    {
            //        for (int i = 0; i < dotPosition; ++i)
            //        {
            //            dollar += number[i];
            //        }
            //        for (int i = dotPosition+1; i < number.Length; ++i)
            //        {
            //            cents += number[i];
            //        }
            //    }
            //    if (dot==0)
            //    {
            //        dollar = number;
            //    }
            //}

            
            if (dollar.Length > 0)
            {


                int j = Convert.ToInt16(dollar[0].ToString());
                Console.WriteLine("{0}", j);
                Console.Write(numberName[j]);
                if (j > 0)
                {
                    Console.Write(" HUNDRED ");
                }

                string twoDigit = dollar[1].ToString() + dollar[2].ToString();
                

                int k = Convert.ToInt16(twoDigit);
                if (j > 0 && k>0 )
                {
                    Console.Write("AND ");
                }
                if (k < 20 && k>0)
                {
                    Console.Write(numberName[k]);
                }
                else if (k>=20)
                {
                    int m = Convert.ToInt16(dollar[1].ToString());
                    int n = Convert.ToInt16(dollar[2].ToString());
                    Console.Write("AND {0}", digit2[m-2]);
                    if (n > 0)
                    {
                        Console.Write("-{0}", numberName[n]);
                    }
                }
                Console.Write(" DOLLARS ");
            }

            if (cents.Length > 0)
            {
                string twoDigit = cents[0].ToString() + cents[1].ToString();

                int k = Convert.ToInt16(twoDigit);
                if (k < 20 && k > 0)
                {
                    Console.Write("{0}", numberName[k]);
                }
                else if (k >= 20)
                {
                    int m = Convert.ToInt16(cents[0].ToString());
                    int n = Convert.ToInt16(cents[1].ToString());
                    Console.Write("{0}", digit2[m - 2]);
                    if (n > 0)
                    {
                        Console.Write("-{0}", numberName[n]);
                    }
                }
            }
           

            
            Console.WriteLine("dollar is {0} \n",dollar);
            Console.WriteLine("cents is {0} \n", cents);
            Console.WriteLine("Match at index [{0}, {1})",
        result.Index,
        result.Index + result.Length);
            
            Console.WriteLine("Match: {0}", result.Value);
            Console.WriteLine("{0} groups captured in {1}", data.Count, result.Value);
            Console.WriteLine("dollar is {0} , cents is {1}",data[1],data[2] );
            Console.WriteLine("capture counts {0}", result.Groups[1].Captures.Count);
            foreach(Capture s in result.Groups[1].Captures)
            {
                Console.WriteLine("capture {0}", s.Value);
            }
            
        }
    }
}
