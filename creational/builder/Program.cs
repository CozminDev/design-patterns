using System;

namespace builder
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonBuilder builder = new PersonBuilder();
            builder.Configure(person =>
            {
                person.firstName = "john";
                person.lastName = "lennon";
            });

            Person person = builder.Build();

            Console.WriteLine(person.firstName);
            Console.WriteLine(person.lastName);
        }
    }

    public class Person
    {
        public  string salutation;
        public  string firstName;
        public  string middleName;
        public  string lastName;
        public  string suffix;
        public  string address;
        public  bool isFemale;
        public  bool isEmployed;
        public  bool isHomewOwner;
    }

    public class PersonBuilder
    {
        private Person person;
        public PersonBuilder()
        {
            person = new Person();
        }

        public void Configure(Action<Person> configurePerson)
        {
            configurePerson(person);
        }

        public Person Build()
        {
            return person;
        }
    }
}
