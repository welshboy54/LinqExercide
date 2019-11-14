using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqExercide
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = new List<string>()
            {
                "Neil Turner",
                "Howard Turner",
                "Simon Turner",
                "Lee Dee"
            };

            var shortNames = from name in names where name.Length <= 12
                             orderby name.Length select name;

            foreach (var name in shortNames)
                Console.WriteLine(name);


            //The next lines of code show that Linq uses deferred execution.

            //Get the names which are less then 12 chars.
            var shortishNames = names.Where(name => name.Length <= 12);

            //Order by length
            shortishNames = shortishNames.OrderBy(name => name.Length);

            //To show that the Linq lines have not been executed we will add a name to the list
            names.Add("Zoe Ball");

            //Now this is where the Linq code is executed.
            foreach (var nameloc in shortishNames)
                Console.WriteLine(nameloc);

            Console.WriteLine();

            //Now we will look at the Where() method
            List<int> numbers = new List<int>()
            {
                1, 2, 4, 8, 16, 32
            };


            var smallNumbers = numbers.Where(n => n < 10);

            foreach (var n in smallNumbers)
                Console.WriteLine(n);


            Console.WriteLine();

            var newsmallNumbers = numbers.Where(ns => ns > 1 && ns != 4 && ns < 10);

            foreach (var ns in newsmallNumbers)
                Console.WriteLine(ns);

            Console.WriteLine();

            // Lets see how we can use the method Contains()
            List<int> housenumbers = new List<int>()
            {
                1, 2, 4, 7, 8, 16, 29, 32, 64, 128
            };

            List<int> excludeNumbers = new List<int>()
            {
                7, 29
            };

            Console.WriteLine();

            var validNumbers = numbers.Where(n => !excludeNumbers.Contains(n));
            foreach (var n in validNumbers)
                Console.WriteLine(n);

            //Lets try it with strings
            List<User> listOfUsers = new List<User>()
            {
                new User() { Name = "John Doe", Age = 42 },
                new User() { Name = "Jane Doe", Age = 34 },
                new User() { Name = "Joe Doe", Age = 8},
                new User() { Name = "Bill Doe", Age = 15}
            };

            var filteredUsers = listOfUsers.Where(user => user.Name.StartsWith("J") && user.Age < 40); //This is the query

            foreach (User user in filteredUsers)
                Console.WriteLine(user.Name + ": " + user.Age);


            Console.ReadKey();
        }

        class User
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

    }
}
