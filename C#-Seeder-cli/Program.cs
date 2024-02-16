// See https://aka.ms/new-console-template for more information

Console.WriteLine("[1]:RocAccount");
Console.WriteLine("[2]:RocCampaign");
Console.WriteLine("[3]:RocGuiUser");
Console.WriteLine("[4]:RocPlateforme");
Console.WriteLine("[5]:RocMetadata");
Console.WriteLine("Please enter a number between 1 and 5:");
string? userInput = Console.ReadLine();
int selectedOption;
if (int.TryParse(userInput, out selectedOption))
{
    switch (selectedOption)
    {
        case 1:
            //Option1();
            break;
        case 2:
            //Option2();
            break;
        case 3:
            //Option3();
            break;
        case 4:
            //Option4();
            break;
        case 5:
            //Option5();
            break;
        default:
            Console.WriteLine("Invalid option. Please enter a number between 1 and 5.");
            break;
    }
}
else
{
    Console.WriteLine("Invalid input. Please enter a valid number between 1 and 5.");
}