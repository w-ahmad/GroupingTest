// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace GroupingTest;

public class Contact(string firstName, string lastName, string gender)
{
    public string FirstName { get; private set; } = firstName;
    public string LastName { get; private set; } = lastName;
    public string Gender { get; private set; } = gender;
    public string Name => FirstName + " " + LastName;
}
