namespace ConsoleApp82
{
    class Source
    {
        public int Add(int a,int b,int c)
        {
            return a + b + c;
        }
        public double Add(double a,double b,double c)
        {
            return a+b + c; 
        }
        static void Main(string[] args)
        {
            Source source = new Source();
            int res=source.Add(1,2,3);
            Console.WriteLine("Integer result :"+res);
            double res1=source.Add(1.3,2.7,3);
            Console.WriteLine("Double result :"+res1);
        }
    }
}
