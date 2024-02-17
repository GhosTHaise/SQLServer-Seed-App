using C__Seeder_cli.Database;

namespace Controller
{
    public class RocCampaignController
    {
        private readonly WebHelpRocContext context;
        public RocCampaignController(WebHelpRocContext _context)
        {   
            context = _context;
        }

        public static String[] BaseName = {"DE","FR","EN","IT","SP","CAMP"};
        public static String[] Name = {"LINKY","NIXIS","TDE_WINBACK","TEST","SPARK","EMAILING"};
        
        public  void GenerateRocCampaign()
        {
            Console.WriteLine("Please enter the number of data to be generated:");
            int userInput = int.Parse(Console.ReadLine() ?? "0");
            String[] PF = context.RocPfs.Select( cc => cc.RocPfname ).ToArray<string>();
            
            if (userInput > 0)
            {
                for (int i = 0; i < userInput; i++)
                {
                    NewRocCampaign(context, i,PF);
                }
            }
            else
            {
                Console.WriteLine("Invalid number.");
            }
        }

        private static void NewRocCampaign(WebHelpRocContext context, int i,string[] PfName)
        {
            RocCampaign _temp = new RocCampaign
            {
                RocBaseName = BaseName[Faker.RandomNumber.Next(0,BaseName.Length - 1)],
                RocCampaignPf = PfName[Faker.RandomNumber.Next(0,PfName.Length - 1)].Split("_")[0],
            };
            _temp.RocCampaignName = $"{_temp.RocBaseName}_{Name[Faker.RandomNumber.Next(0,Name.Length - 1)]}_{Faker.RandomNumber.Next(1,100)}";
            _temp.RocAccId = Faker.RandomNumber.Next(1,10);
            _temp.RocCallType = Faker.RandomNumber.Next(1,2);
            _temp.RocCampagneSortante = _temp.RocCampaignName;
            _temp.RocCampaignActive = Faker.RandomNumber.Next(-4,40) > 0 ? "OUI" : "NON";
            _temp.Naegelen = _temp.RocCampaignActive;
            try
            {
                context.RocCampaigns.Add(_temp);
                context.SaveChanges(); // Save changes to the database
                Console.WriteLine($"[{i}] : Campaign created.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}