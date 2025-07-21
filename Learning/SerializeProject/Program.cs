using Newtonsoft.Json;

namespace SerializeProject
{
    //[Serializable]
    public class Person 
    { 
        public string Name { get; set; }
        public int Age { get; set; }

        [NonSerialized]
        public string CreditCardNumber;

        public override string ToString() => $"{Name} : {Age} : {CreditCardNumber}";
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person() { Name = "Sergey", Age = 40, CreditCardNumber = "1234" };
            Person p2 = new Person() { Name = "Vasiliy", Age = 35, CreditCardNumber = "4567" };

            Person[] people = { p1, p2 };
            
            // Serialization using newtonsoft lib
            string s = JsonConvert.SerializeObject(people);
            Console.WriteLine(s);

            people = null;

            people = JsonConvert.DeserializeObject<Person[]>(s);

            foreach (var p in people)
                Console.WriteLine(p);
        }
    }
}
