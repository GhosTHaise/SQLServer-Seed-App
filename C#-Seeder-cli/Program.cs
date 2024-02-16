// See https://aka.ms/new-console-template for more information

using C__Seeder_cli.Database;
using Controller;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Console.WriteLine("[1]:RocAccount");
Console.WriteLine("[2]:RocCampaign");
Console.WriteLine("[3]:RocGuiUser");
Console.WriteLine("[4]:RocPlateforme");
Console.WriteLine("[5]:RocMetadata");
Console.WriteLine("Please enter a number between 1 and 5:");
string? userInput = Console.ReadLine();
HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddDbContext<WebHelpRocContext>(options =>
        {

        });
builder.Services.AddScoped<WebHelpRocContext>(provider => provider.GetService<WebHelpRocContext>());
var serviceProvider = new ServiceCollection()
            .AddDbContext<WebHelpRocContext>()
            .BuildServiceProvider();

int selectedOption;
var ctlRocGuiUser = new RocGuiUserController(serviceProvider.GetService<WebHelpRocContext>());
var ctlRocPfs = new RocPlateformController(serviceProvider.GetService<WebHelpRocContext>());
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
                ctlRocGuiUser.GenerateGuiUser();
                break;
            case 4:
                ctlRocPfs.GeneratePlateforms();
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