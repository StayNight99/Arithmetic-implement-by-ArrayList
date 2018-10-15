using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

//使用連結指定方法的委派技術來處理「10 + 3 * 2 - 5」加、減、乘法混合運算過程

//[Arithmetic implement by ArrayList, v.1]
//Copyright(C) [2018], [Yu Ting]

namespace Hw4_Q36071164_簡宇廷_3
{
    class Program
    {
        private delegate void MeDelegatePara(ArrayList Number, ArrayList Symbol);
        static void Main(string[] args)
        {
            Console.WriteLine("請輸入四則運算(加法、減法、乘法)");
            String ipt = Console.ReadLine();
           
            //convet String to Arraylist 
            string[] number = ipt.Split(new char[3] { '+','-','*' });
            ArrayList AryNumber = new ArrayList(number);
            ArrayList ArySymbol = new ArrayList();
            for(int i = 0; i< ipt.Length; i++)
            {
                Char nowChar = Convert.ToChar(ipt.Substring(i,1));
                if ((nowChar == '+') || (nowChar == '-') || (nowChar == '*'))
                {
                    ArySymbol.Add(nowChar);
                }               
            }

            // ----------------------------
            //Type1 : delegate implement
            MeDelegatePara D = new MeDelegatePara(Calculation);
            D.Invoke(AryNumber, ArySymbol);
            
            //Type2 : call by function
            //Calculation(AryNumber, ArySymbol);
            // ----------------------------

            //program exit
            Console.WriteLine("按任一鍵結束...");
            Console.ReadLine();
        }

        //calculation recursive function
        public static void Calculation(ArrayList number, ArrayList symbol)
        {

            //multiply priority first
            for (int i =0; i < symbol.Count;i++)
            {
                if(symbol[i].ToString() == "*")
                {
                    number[i] = Convert.ToInt16(number[i]) * Convert.ToInt16(number[i+1]);
                    number.RemoveAt(i+1);
                    symbol.RemoveAt(i);
                    printAnswer(number, symbol);
                    Calculation(number, symbol);
                    break;
                }
            }

            //addition,subtraction priority second
            for (int i = 0; i < symbol.Count; i++)
            {
                if (symbol[i].ToString() == "+")
                {
                    number[i] = Convert.ToInt16(number[i]) + Convert.ToInt16(number[i + 1]);
                    number.RemoveAt(i + 1);
                    symbol.RemoveAt(i);
                    printAnswer(number, symbol);
                    Calculation(number, symbol);
                    break;
                }else if (symbol[i].ToString() == "-")
                {
                    number[i] = Convert.ToInt16(number[i]) - Convert.ToInt16(number[i + 1]);
                    number.RemoveAt(i + 1);
                    symbol.RemoveAt(i);
                    printAnswer(number, symbol);
                    Calculation(number, symbol);
                    break;
                }
            }
        }

        //output answer
        public static void printAnswer(ArrayList number,ArrayList symbol)
        {
            Console.Write("= " + number[0].ToString());
            for (int i = 0; i < symbol.Count; i++)
            {
                Console.Write(symbol[i].ToString() +number[i+1].ToString());
            }
            Console.WriteLine("");
        }
    }    
}


