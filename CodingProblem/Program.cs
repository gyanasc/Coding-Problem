using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            //Object Initialization for Employee class

            List<Employee> objEmployee = new List<Employee>{
                    new Employee{ Name="Sachin",EmpID="I001",Salary=800},
                    new Employee{ Name="Vijay",EmpID="I002",Salary=400},
                    new Employee{ Name="Ashish",EmpID="I003",Salary=250},
                    new Employee{ Name="Syed",EmpID="I004",Salary=300},
                    new Employee{ Name="Ravish",EmpID="I005",Salary=700},
                };

            /*
                QUESTION 1.Difference between ‘this’ and ‘let’ and when to use what, explain with examples.

                The this keyword refers to the current instance of the class 
                and is also used as a modifier of the first parameter of an extension method.

                The Let keyword allows you to create a range variable and initialized with the result of the query expression 
                and then you are allowed to use that variable with the upcoming clause in the same query. 
                When you initialize a range variable with one value after that 
                you are not allowed to store another value in the range variable.
            */
            var objresult = from emp in objEmployee
                            let totalSalary = objEmployee.Sum(sal => sal.Salary)
                            let avgSalary = totalSalary / 5
                            where avgSalary > emp.Salary
                            select emp;

            /*
                QUESTION 2.Write a function which accepts an array of strings and returns a map of character to count of the character(including spaces and special characters).
                Eg: input: [‘hello world’, ‘hello world’]  output: {h: 2, e: 2, l: 6, ‘ ‘: 1, o: 4 …… }
            */
            var lstStr = new string[] { "hello world", "hello world", "hello world" };
            var CharCount = ProblemSolve.AllCharOccurenceCount(lstStr);
            Console.WriteLine("Occurence of characters in given string array is " + CharCount);

            /*
                QUESTION 3.Write a function to return all the keys present in an object at any level.
                Eg: input: {  a: 5, b: { c: { d: 10 } }}   output: [a, b, c, d]
             */
            var jsonStr = "{a:5,b:{c:{d:10} }}";
            var lstKeys = ProblemSolve.GetKeyFromJsonString(jsonStr);
            Console.WriteLine("The key of the json string " + jsonStr + "is ");
            Console.Write("[");
            foreach (var key in lstKeys)
            {
                Console.Write(key);
                Console.Write(" ");
            }
            Console.Write("]");
            Console.WriteLine();

            /*
               QUESTION 4.Write a function to reverse every word of a string.
                ·         Using split and reverse
                ·         Without using split and reverse and in O(1) space (since strings are immutable, assume that the input is a character array).
             */

            var strWords = "Gyana Ranjan Lenka";
            var revStr = ProblemSolve.ReverseWordUsingSplitRev(strWords);
            var revStr1 = ProblemSolve.ReverseWords(strWords);
            Console.WriteLine("The reverse word of " + strWords + " is " + revStr);

            /*
                QUESTION 5.Write a function to remove duplicate strings from an array of strings.
             */

            var lstDupStr = new string[] { "hello", "world", "Love", "world", "you", "hello" };
            var UniqueLst = ProblemSolve.RemoveDuplicates(lstDupStr);
            Console.WriteLine("The unique word of the string is ");
            Console.Write("[");
            foreach (var key in UniqueLst)
            {
                Console.Write(key);
                Console.Write(" ");
            }
            Console.Write("]");
            Console.WriteLine();

            Console.WriteLine("Press any key to exit!!");
            Console.ReadLine();
        }
    }

    /*
        QUESTION 1.Difference between ‘this’ and ‘let’ and when to use what, explain with examples.

        The this keyword refers to the current instance of the class 
        and is also used as a modifier of the first parameter of an extension method.
    */
    class Employee
    {
        private string _Name;
        public string _EmpID;
        public int _Salary;
        public string Name
        {
            get { return _Name; }
            set { this._Name = value; }
        }
        public string EmpID
        {
            get { return _EmpID; }
            set { this._EmpID = value; }
        }
        public int Salary
        {
            get { return _Salary; }
            set { this._Salary = value; }
        }
    }
}
