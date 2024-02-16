using C__Seeder_cli.Database;

namespace Controller
{
    public class RocGuiUserController
    {
        private readonly WebHelpRocContext context;
        public RocGuiUserController(WebHelpRocContext _context)
        {   
            context = _context;
        }


        public  void GenerateGuiUser()
        {
            Console.WriteLine("Please enter the number of data to be generated:");
            int userInput = int.Parse(Console.ReadLine() ?? "0");
            if (userInput > 0)
            {
                for (int i = 0; i < userInput; i++)
                {
                    NewGuiUser(context, i);
                }
            }
            else
            {
                Console.WriteLine("Invalid number.");
            }
        }

        private static void NewGuiUser(WebHelpRocContext context, int i)
        {
            RocGuiuser _temp = new RocGuiuser
            {
                RocUserName = Faker.Name.FullName(),
                RocUserActive = true,
                RocUserNiveau = 4
            };
            _temp.RocUserMail = $"{_temp.RocUserName.Replace(" ", ".")}@webhelp.fr";
            _temp.RocUserRole = "visiteur";
            try
            {
                context.RocGuiusers.Add(_temp);
                context.SaveChanges(); // Save changes to the database
                Console.WriteLine($"[{i}] : User created.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
