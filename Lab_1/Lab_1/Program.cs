namespace Lab_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
    }
}   class Person
{
    int personId;
    string firstName;
    string lastName;
    string favouriteColor;
    int age;
    bool isWorking;

    public int PersonId { get => personId;set => personId = value; }
    public string FirstName { get => firstName; set => firstName = value; }
    public string LastName { get => lastName; set => lastName = value; }
    public string FavouriteColor { get => favouriteColor;set => favouriteColor = value; }
    public int Age { get => age; set => age = value; }
    public bool IsWorking { get => isWorking; set => isWorking = value; }

    public Person(int personId, string firstName, string lastName, string favouriteColor, int age, bool isWorking)
    {
        this.personId = personId;
        this.firstName = firstName;
        this.lastName = lastName;
        this.favouriteColor = favouriteColor;
        this.age = age;
        this.isWorking = isWorking;
    }
    public void DisplayPersonalInfo(Person person)
    {
        Console.WriteLine(person.personId + ": " + person.firstName + " " + person.lastName + "'s favourite color is: " + person.favouriteColor);
    }
    public void ChangeFavouriteColor(string color)
    {
        favouriteColor = color;
    }
    public void AgeInTenYears(Person person)
    {
        Console.WriteLine(person.personId + ": Will be " + person.age + 10 + "in 10 years ");
    }
    public override string ToString()
    {
        return "Person Id: " + personId + "\nFirst Name: " + firstName + "\nLast Name:" + lastName
            + "\nAge" + age + "\nIs Working:" + isWorking;
    }
}
class Relation
{
    char relationshipType;
    public char RelationShipType { get => relationshipType; set => relationshipType = value; }
    public Relation(char relation)
    {
        RelationShipType = relation;
    }

    enum Relationship
    {
        Sister,
        Brother,
        Mother,
        Father
    }

    public void ShowRelationShip(Person person1, Person person2)
    {
        switch (relationshipType)
        {
            case 'S':
                Console.WriteLine("Relationship between " + person1 + "and " + person2 + "is " + Relationship.Sister);
                break;
            case 'B':
                Console.WriteLine("Relationship between " + person1 + "and " + person2 + "is " + Relationship.Brother);
                break;
            case 'M':
                Console.WriteLine("Relationship between " + person1 + "and " + person2 + "is " + Relationship.Mother);
                break;
            case 'F':
                Console.WriteLine("Relationship between " + person1 + "and " + person2 + "is " + Relationship.Father);
                break;
        }
    }
}
class Main
{
    Person ian = new Person(1, "Ian", "Brooks", "Red", 30, true);
    Person gina = new Person(2, "Gina", "James", "Green", 18, false);
    Person mike = new Person(3, "Mike", "Ben", "Blue", 45, true);
    Person mary = new Person(4, "Mary", "Beals", "Yellow", 28, true);
}