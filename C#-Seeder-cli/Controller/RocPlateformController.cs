using C__Seeder_cli.Database;

namespace Controller
{
    public class RocPlateformController
    {
        private readonly WebHelpRocContext context;
        public RocPlateformController(WebHelpRocContext _context)
        {   
            context = _context;
        }
        public enum ERocPlateformControllerPfName
        {
            HER ,
            NIX
        }

        public  void GeneratePlateforms()
        {
            Console.WriteLine("Please enter the number of data to be generated:");
            int userInput = int.Parse(Console.ReadLine() ?? "0");
            if (userInput > 0)
            {
                for (int i = 0; i < userInput; i++)
                {
                    NewPf(context, i);
                }
            }
            else
            {
                Console.WriteLine("Invalid number.");
            }
        }

        private static void NewPf(WebHelpRocContext context, int i)
        {
            RocPf _temp = new RocPf
            {
                RocPfname = $"{Faker.Enum.Random<ERocPlateformControllerPfName>().ToString()}{Faker.RandomNumber.Next(0,27)}_{Faker.RandomNumber.Next(0,3)}",
                RocPfsqlIp = $"11.{Faker.RandomNumber.Next(0,255)}.{Faker.RandomNumber.Next(0,255)}.{Faker.RandomNumber.Next(0,255)}",
                RocPfctiIp = $"11.{Faker.RandomNumber.Next(0,255)}.{Faker.RandomNumber.Next(0,255)}.{Faker.RandomNumber.Next(0,255)}",
                

            };
            _temp.RocCampaignRecordingPf = $"{_temp.RocPfname}#PCBX1FR#REC1";
            _temp.RocCampaignCallPf = $"{_temp.RocPfname}#PCBX1FR#{_temp.RocPfname}";
            _temp.RocCtiDrive = Faker.RandomNumber.Next(0,3) == 1   ? "d" : Faker.RandomNumber.Next(0,4) == 2 ? "f" : "e";
            _temp.RocDirRecords = $"hermes_p\\Files\\{Faker.Address.ZipCode()}{Faker.Address.ZipCode()}\\RECORDS";
            _temp.RocPflabel = _temp.RocPfname;
            _temp.RocPftype = Faker.RandomNumber.Next(-4,4) < 0 ? "HERMES" : "NIXIS";
            _temp.RocPffileSource = Faker.RandomNumber.Next(-2,3) <= 0 ? "CTI" : "SFTP";
            _temp.RocSftpuser = Faker.RandomNumber.Next(-2,50) < 0 ? $"{Faker.Address.ZipCode()}{Faker.Address.ZipCode()}" : null;
            _temp.RocSftphost = (_temp.RocSftpuser != null) ? $"sftp_{Faker.Address.CitySuffix()}_records.vocalcom.com" : "";
            _temp.RocPfactive = Faker.RandomNumber.Next(-4,40) > 0 ? "OUI" : "NON";
            try
            {
                context.RocPfs.Add(_temp);
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