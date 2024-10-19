namespace ConsoleApp81
{
    class Person
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
    }
    class PersonImplementation
    {
        public string GetName(IList<Person> person)
        {
            string res = "";
            foreach (Person p in person)
            {
                
                res += p.Name + " ";
                res += p.Address + " ";
            }
            return res;

        }
        public double Average(IList<Person> person)
        {
            double avg = 0;
            avg = person.Average(x => x.Age);
            return avg;
        }
        public int Max(IList<Person> person)
        {
            return person.Max(x => x.Age);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IList<Person> p = new List<Person>();
            p.Add(new Person { Name = "Aarya", Address = "A2101", Age = 69 });
            p.Add(new Person { Name = "Daniel", Address = "D104", Age = 40 });
            p.Add(new Person { Name = "Ira", Address = "H801", Age = 25 });
            p.Add(new Person { Name = "Jennifer", Address = "I1704", Age = 33 });
           PersonImplementation person = new PersonImplementation();
            Console.WriteLine(person.GetName(p));
            Console.WriteLine (person.Average(p));
            Console.WriteLine(person.Max(p));
        }
    }
}

