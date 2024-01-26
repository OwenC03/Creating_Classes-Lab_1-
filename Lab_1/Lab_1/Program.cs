using System.Diagnostics.CodeAnalysis;

namespace Lab_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Creates a new person under the Person class and gives them their identifying markers such as id#, name, favourite color, age and if they work or not.
            Person ian = new Person(1, "Ian", "Brooks", "Red", 30, true);
            Person gina = new Person(2, "Gina", "James", "Green", 18, false);
            Person mike = new Person(3, "Mike", "Ben", "Blue", 45, true);
            Person mary = new Person(4, "Mary", "Beals", "Yellow", 28, true);

            //Calls Gina's info and display's it according to the rules layed out in the DisplayPersonInfo 
            gina.DisplayPersonalInfo(gina);

            // Writes Mikes name in a list like format as thats how it is how each name is set from creation in the ToString function below.
            Console.WriteLine(mike);

            // Runs Ians name through the Change favourite color function to specifically target that section of his saved personal file in the
            // Person class and change the color associated with him, then displays his info to verify the change  
            ian.ChangeFavouriteColor("White");
            ian.DisplayPersonalInfo(ian);

            // runs Mary's age through a calculation that determines her age in 10 years and displays it.
            mary.AgeInTenYears(mary);

            //sets the name relation1 to the Letter 'S' so that any association with it will mean those people are sisters for the code to understand
            //sets the name relation2 to the letter 'B' so that any association with it will mean those people are brothers for the code to understand
            Relation relation1 = new Relation('S');
            Relation relation2 = new Relation('B');

            // uses the last piece of code to create a relationship between the 4 people, showing 2 people as sisters, and 2 people as brothers.
            relation1.ShowRelationShip(gina, mary);
            relation2.ShowRelationShip(ian, mike);

            //creates a new person list named "people", then addeds everyone and there info to it. 
            List<Person> people = new List<Person>();
            people.Add(ian);
            people.Add(gina);
            people.Add(mike);
            people.Add(mary);

            //writes the line and displays the average age of the group 
            Console.WriteLine("The average age between everyone is: " + calculatedAverage(people));
           
            // sets the youngest age by finding the minimum number from the people list and its name
            double lowest_age = people.Min(p => p.Age);
            var youngest_p = people.Find(people => people.Age == lowest_age).FirstName;
            Console.WriteLine("The youngest person in the group is: " + youngest_p);
            
            // sets the oldest age in the same way, finding the highest number in the people lists and
            // attaching its name to the oldest_p tag
            double highest_age = people.Max(p => p.Age);
            var oldest_p = people.Find(people => people.Age == highest_age).FirstName;
            Console.WriteLine("The oldest person in the group is: " +  oldest_p);

            //these two tags they filter through the people list and find specific's before displaying them,
            // one looks for the people first person whos name starts with M and the other looks for the person that likes Blue
            displayNamesthatstartWithM(people);
            displayNamesthatLikeBlue(people);
            Console.ReadLine();
            
            
            // calculates the average of all the ages for the people and returns it cant use int as it gives error,
            // double is best choice. 
            static double calculatedAverage(List<Person> people)
            {
                double avg = 0;
                foreach (Person person in people)
                {
                    avg += person.Age;
                }
                return avg / people.Count;
            }

            //when called it sorts through the people's list and looks for the first person whos name starts with M and returns their info to be displayed
            static void displayNamesthatstartWithM(List<Person> people)
            {
                foreach (Person person in people)
                {
                    if (person.FirstName.ToCharArray().ElementAt(0) == 'M')
                        Console.WriteLine(person);
                }
            }

            //when called it sorts through the people's list and finds the person who likes blue and returns their info to be displayed
            static void displayNamesthatLikeBlue(List<Person> people)
            {
                foreach (Person person in people)
                {
                    if (person.FavouriteColor == "Blue")
                        Console.WriteLine(person);
                }
            }
        }
    }
    // Creates the Personn class and anything to do with the person formatting or info
    class Person
    {
        // sets the Variables of the Person's info to what they would be, either int's, strings, or Bools
        int personId;
        string firstName;
        string lastName;
        string favouriteColor;
        int age;
        bool isWorking;

        // creates the getters and setters for the the infor so when a person is created it is set
        public int PersonId { get => personId; set => personId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string FavouriteColor { get => favouriteColor; set => favouriteColor = value; }
        public int Age { get => age; set => age = value; }
        public bool IsWorking { get => isWorking; set => isWorking = value; }

        // sets up how the info will be collected for all future use so everyone knows the layout and the system can tell what to expect 
        // and what variable to put the info to when its given using the 'New Person' tag
        public Person(int personId, string firstName, string lastName, string favouriteColor, int age, bool isWorking)
        {
            this.personId = personId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.favouriteColor = favouriteColor;
            this.age = age;
            this.isWorking = isWorking;
        }
        // when called it uses the info provided to write the persons personal info then the code continues to the next area 
        public void DisplayPersonalInfo(Person person)
        {
            Console.WriteLine(person.personId + ": " + person.firstName + " " + person.lastName + "'s favourite color is: " + person.favouriteColor);
        }

        // when called it changes the mentioned persons favourite color to whatever is given.
        public void ChangeFavouriteColor(string color)
        {
            favouriteColor = color;
        }
        
        // when called it does the calculations to add 10 years to the persons age to see how old they will be and display it.
        public void AgeInTenYears(Person person)
        {
            Console.WriteLine(FirstName +" " + LastName + ": Will be " + (person.age + 10) + " in 10 years ");
        }

        // Creates the base list form for all the normal prints, when information is called and told to print it will print like this unless told otherwise. 
        public override string ToString()
        {
            return "Person Id: " + personId + "\nFirst Name: " + firstName + "\nLast Name: " + lastName
                +"\nFavourite Color: " + favouriteColor + "\nAge " + age + "\nIs Working: " + isWorking;
        }
    }
    // Creates the Relation class which is incharge of the relation tags used when asking the system whos brother, sister, mother, or father. 
    class Relation
    {
        char relationshipType;
        public char RelationShipType { get => relationshipType; set => relationshipType = value; }
        public Relation(char relation)
        {
            RelationShipType = relation;
        }

        // Sets what relations are what, using the enum uses less memory while setting multiple values
        enum Relationship
        {
            Sister,
            Brother,
            Mother,
            Father
        }
        // Sets ShowRelationShip to be called whenever the tag is used and which scenario to use 
        public void ShowRelationShip(Person person1, Person person2)
        {
            switch (relationshipType)
            {
                case 'S':
                    Console.WriteLine("Relationship between " + person1.FirstName + " and " + person2.FirstName + " is " + Relationship.Sister);
                    break;
                case 'B':
                    Console.WriteLine("Relationship between " + person1.FirstName + " and " + person2.FirstName + " is " + Relationship.Brother);
                    break;
                case 'M':
                    Console.WriteLine("Relationship between " + person1.FirstName + " and " + person2.FirstName + " is " + Relationship.Mother);
                    break;
                case 'F':
                    Console.WriteLine("Relationship between " + person1.FirstName + " and " + person2.FirstName + " is " + Relationship.Father);
                    break;
                default:
                    break;
            }
        }
    }
}