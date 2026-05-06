using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupingTest;

public static class DataFaker
{
    private static readonly Random _random = new();

    // First names
    private static readonly string[] FirstNames =
    [
        "James", "Mary", "Robert", "Patricia", "Michael", "Jennifer", "William", "Linda", "David", "Barbara",
        "Richard", "Elizabeth", "Joseph", "Susan", "Thomas", "Jessica", "Charles", "Sarah", "Christopher", "Karen",
        "Daniel", "Nancy", "Matthew", "Lisa", "Anthony", "Betty", "Mark", "Margaret", "Donald", "Sandra",
        "Steven", "Ashley", "Paul", "Kimberly", "Andrew", "Donna", "Joshua", "Carol", "Kenneth", "Michelle",
        "Kevin", "Emily", "Brian", "Melissa", "George", "Deborah", "Edward", "Stephanie", "Ronald", "Rebecca",
        "Timothy", "Sharon", "Jason", "Brenda", "Jeffrey", "Amber", "Ryan", "Anna", "Jacob", "Pamela",
        "Gary", "Nicole", "Nicholas", "Emma", "Eric", "Helen", "Jonathan", "Samantha", "Stephen", "Katherine"
    ];

    // Last names
    private static readonly string[] LastNames =
    [
        "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez",
        "Hernandez", "Lopez", "Gonzalez", "Wilson", "Anderson", "Thomas", "Taylor", "Moore", "Jackson", "Martin",
        "Lee", "Perez", "Thompson", "White", "Harris", "Sanchez", "Clark", "Ramirez", "Lewis", "Robinson",
        "Walker", "Young", "Allen", "King", "Wright", "Scott", "Torres", "Peterson", "Phillips", "Campbell",
        "Parker", "Evans", "Edwards", "Collins", "Reyes", "Stewart", "Morris", "Morales", "Murphy", "Cook",
        "Rogers", "Morgan", "Peterson", "Cooper", "Reed", "Bell", "Gomez", "Murray", "Freeman", "Wells",
        "Webb", "Simpson", "Stevens", "Tucker", "Porter", "Hunter", "Hicks", "Crawford", "Henry", "Boyd"
    ];

    // Genders
    private static readonly string[] Genders =
    [
        "Male", "Female", "Non-binary", "Genderfluid", "Agender",
        "Bigender", "Genderqueer", "Two-Spirit", "Prefer not to say"
    ];

    public static string FirstName()
    {
        return FirstNames[_random.Next(FirstNames.Length)];
    }

    public static string LastName()
    {
        return LastNames[_random.Next(LastNames.Length)];
    }

    public static string Gender()
    {
        return Genders[_random.Next(Genders.Length)];
    }
}