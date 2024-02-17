using C__Seeder_cli.Database;

namespace Controller
{
    public class RocAccountController
    {
        private readonly WebHelpRocContext context;
        public RocAccountController(WebHelpRocContext _context)
        {   
            context = _context;
        }

        public static String[] BaseName = {"COMUTITRES","TDE","EXODUS","SPIN","ACCL","RECETTE","TOTALENERGY"};
        public static String[] Name = {"_PREPROD","","","","_PRENIUM","_TEST","_SPA","_EMAILING"};
        public static String[] Acctype = {"HERMES","NIXIS","WINBACK","NICE","ARK","LYDIA","TOTALENERGY"};
        
        public static String[] service = {"ServiceClient","commutitres","prenium_bleu","prenium","","internal","","","","","","","","",""};
        public static String[] serviceType = {"PREPROD_IN","IN","PREPROD_OUT","OUT","LINKY"};
        public static int[] rententionDelay = {30,60,90};
       public  void GenerateRocAccount()
        {
            Console.WriteLine("Please enter the number of data to be generated:");
            int userInput = int.Parse(Console.ReadLine() ?? "0");
            String[] PF = context.RocPfs.Select( cc => cc.RocPfname ).ToArray<string>();
            
            if (userInput > 0)
            {
                for (int i = 0; i < userInput; i++)
                {
                    NewRocAccount(context, i,PF);
                }
            }
            else
            {
                Console.WriteLine("Invalid number.");
            }
        }

        private static void NewRocAccount(WebHelpRocContext context, int i,string[] PfName)
        {
            RocAccount _temp = new RocAccount
            {
                RocAccName = $"{BaseName[Faker.RandomNumber.Next(0,BaseName.Length - 1)]}_{Acctype[Faker.RandomNumber.Next(0,Acctype.Length - 1)]}_{Name[Faker.RandomNumber.Next(0,Name.Length - 1)]}"
            };
            _temp.RocServiceName = $"roc-svc-{_temp.RocAccName.ToLower()}-{service[Faker.RandomNumber.Next(0,service.Length - 1)]}";
            _temp.RocPath = $"\\\\WFRPANKAN0{Faker.RandomNumber.Next(0,4)}_NAS0{Faker.RandomNumber.Next(0,4)}\\\\WFRKANROC_share\\ROC_STORAGE\\{serviceType[Faker.RandomNumber.Next(0,serviceType.Length - 1)]}";
            _temp.RocUser = $"svc-app0{Faker.RandomNumber.Next(0,100)}-{Acctype[Faker.RandomNumber.Next(0,Acctype.Length - 1)].ToLower()}";
            _temp.RocPassword = $"{Faker.Identification.UkNationalInsuranceNumber()}";
            _temp.RocAccType = Acctype[Faker.RandomNumber.Next(0,Acctype.Length - 1)];
            _temp.RocRep = Faker.RandomNumber.Next(-14,BaseName.Length - 1) > 0 ? BaseName[Faker.RandomNumber.Next(0,BaseName.Length - 1)].ToLower() : null;
            _temp.RocSousRep = Faker.RandomNumber.Next(-14,service.Length - 1) > 0 ? service[Faker.RandomNumber.Next(0,service.Length - 1)].ToLower() : null;
            _temp.RocRetentionDelay = rententionDelay[Faker.RandomNumber.Next(0,rententionDelay.Length - 1)];
            _temp.RocAccActive = Faker.RandomNumber.Next(-4,40) > 0 ? "OUI" : "NON";
            try
            {
                context.RocAccounts.Add(_temp);
                context.SaveChanges(); // Save changes to the database
                Console.WriteLine($"[{i}] : Roc Account created.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}