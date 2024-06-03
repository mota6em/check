using System;
namespace ConsoleApp1
{
    public class Program 
    {
        private string name_;
        public string name 
        {
            get { return name_; }
            set { name_ = "hello"; }
        }
        public int Age { get { return 34; } private set { } } 
        public Program(string name)
        {
            this.name = name;
        }
        public static void Main(string[] args)
        {
            Program pr = new Program("samy");
            string res = pr.name_;
            Console.WriteLine(res);
            pr.Age = 10;
            int age = pr.Age;
            Console.WriteLine(age);
        }
    }
}