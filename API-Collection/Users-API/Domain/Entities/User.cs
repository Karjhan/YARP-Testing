using Commons.Primitives;
using Users_API.Domain.Primitives;

namespace Users_API.Domain.Entities;

public class User(Guid id) : Entity(id)
{
    public Name Name { get; private set; }

    public string Description { get; private set; }

    public int Age { get; private set; }

    public User(
        Guid id,
        Name name,
        string description,
        int age
    ) : this(id)
    {
        Name = name;
        Description = description;
        Age = age;
    }

    public static User Create(
        Guid id,
        Name name,
        string description,
        int age
    )
    {
        User user = new User(
            id, 
            name, 
            description, 
            age
        );

        return user;
    }

    public void Update(Name newName, string newDescription, int newAge)
    {
        Name = newName;
        Description = newDescription;
        Age = newAge;
    }
}