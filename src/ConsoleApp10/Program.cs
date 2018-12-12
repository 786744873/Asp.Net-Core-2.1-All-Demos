using System;
using System.Collections.Generic;

namespace ConsoleApp10
{
    class Program
    {
        //c# 7.0语法
        static void Main(string[] args)
        {
            //out
            {
                {//old
                    string val = "10";
                    int result;
                    int.TryParse(val, out result);
                    Console.WriteLine(result);
                }

                {//new
                    string val = "10";
                    int.TryParse(val, out int result);
                    Console.WriteLine(result);
                }
            }

            //Tuple
            {
                var tuple = GetData();
                Console.WriteLine(tuple.Item1 + " " + tuple.Item2);

                var (isSuccess, msg) = GetDataNew();
                Console.WriteLine(isSuccess.ToString(), msg);
            }

            //Deconstruct
            {
                var (Name, Age) = new Person("jack", 18);

                Console.WriteLine(Name + " " + Age);
            }

            //Local
            {
                Console.WriteLine(GetLength("hello world"));

                int GetLength(string str)
                {
                    return str.Length;
                }
            }

            //switch增强
            {
                var list = new List<object>() { 1, "2" };
                foreach (var item in list)
                {
                    switch (item)
                    {
                        //如果当前item是int类型，那么执行
                        case int val:
                            Console.WriteLine(val);
                            break;
                        //如果当前item是string类型，那么转成int
                        case string str when int.TryParse(str, out int ival):
                            Console.WriteLine(ival);
                            break;
                        default:
                            break;
                    }
                }
            }


            Console.Read();
        }

        public static Tuple<bool, string> GetData()
        {
            return Tuple.Create(true, "操作成功");
        }

        public static (bool, string) GetDataNew()
        {
            return (true, "操作成功");
        }
    }

    public class Person
    {
        private string _name;
        private int _age;

        public Person(string name, int age)
        {
            this._name = name;
            this._age = age;
        }

        public void Deconstruct(out string name, out int age)
        {
            name = this._name;
            age = this._age;
        }
    }
}
