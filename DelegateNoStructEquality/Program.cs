using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DelegateNoStructEquality
{
    //in，逆变，object->string
    //out,协变，string->object
    class Program
    {
        public delegate bool Compare(int a, int b);
        static void Main(string[] args)
        {
            Compare v= Big;
            //委托类型不具备结构相等性，无法直接赋值
            //Func<int, int, bool> c = v;
            Func<int, int, bool> c = v.Invoke;
            Action<object> a = (temp)=> { return; };
            Action<string> b = a;

            Func<object, string> aa1 = (temp) => { return "dd"; };
            Func<string, object> fff = aa1;

            //lambda表达式包含“语句lambda”和“表达式lambda”
            //语句lambda无法转换成表达式树
            //Expression<Func<int, int, bool>> expr = (atemp, btemp) => { return atemp > btemp; };
            //表达式lambda可以转换成表达式树
            Expression<Func<int, int, bool>> expr = (atemp, btemp) => atemp > btemp; 

        }


        public static bool Big(int a, int b)
        {
            return a > b;
        }

     
    }

   

    }
 
