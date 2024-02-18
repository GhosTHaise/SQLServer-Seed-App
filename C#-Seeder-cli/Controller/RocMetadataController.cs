using C__Seeder_cli.Database;

namespace Controller
{
    public class RocMetadataController
    {
        private readonly WebHelpRocContext context;
        public RocMetadataController(WebHelpRocContext _context)
        {
            context = _context;
        }

        public void GenerateRocMetadata()
        {
            //Console.WriteLine("Please enter the number of Day to be generated:");
            //int userInput = int.Parse(Console.ReadLine() ?? "0");
            String[] PF = context.RocPfs.Select(cc => cc.RocPfname).ToArray<string>();
            int? maxProcessIdStored = context.RocMetadata.Max(m => m.RocRunProcessId) ?? null;
            if (maxProcessIdStored != null)
            {
                DateTime? lastDataTime = context.RocMetadata.Max(m => m.RocDateRunProcess);
                if (lastDataTime != null)
                {
                    TimeSpan difference = DateTime.Today - (lastDataTime ?? DateTime.Today);
                    int differenceJour = difference.Days;

                    RunProcess((int)maxProcessIdStored,differenceJour);
                }
            }
            else
            {
                RunProcess(4429,35);
            }
        }

        private void RunProcess(int ProcessID, int day_difference)
        {
            DateTime dateCursor = DateTime.Today.AddDays(-day_difference);
            string[] rocServiceName = context.RocAccounts.Select(x => x.RocServiceName).ToArray<string>();
            string[] rocPlateformName = context.RocPfs.Select(x => x.RocPflabel).ToArray<string>();
            string[] plateformTaken = GenererValeursAleatoires(Faker.RandomNumber.Next(15, 30), rocPlateformName);
        
            for (int i = 1; i <= day_difference; i++)
            {
                dateCursor = dateCursor.AddDays(1);
                string[] serviceTaken = GenererValeursAleatoires(Faker.RandomNumber.Next(2, 24), rocServiceName);
                Console.WriteLine($"[{ProcessID + i}] -> {i} : {Faker.RandomNumber.Next(utils.FileDayInterval.getDaysFileMigrationInterval()[(int)dateCursor.DayOfWeek].min, utils.FileDayInterval.getDaysFileMigrationInterval()[(int)dateCursor.DayOfWeek].max)}({(int)dateCursor.DayOfWeek})");
                for (int j = 0; j < Faker.RandomNumber.Next(utils.FileDayInterval.getDaysFileMigrationInterval()[(int)dateCursor.DayOfWeek].min, utils.FileDayInterval.getDaysFileMigrationInterval()[(int)dateCursor.DayOfWeek].max); j++)
                {
                    
                    NewMetadata(context, ProcessID + i, dateCursor, serviceTaken[Faker.RandomNumber.Next(0, serviceTaken.Length - 1)], plateformTaken[Faker.RandomNumber.Next(0, plateformTaken.Length - 1)], j);
                }
                Console.WriteLine($"Saving Data Start [{ProcessID + i}] : {DateTime.Now.Hour}:{DateTime.Now.Minute}::{DateTime.Now.Second}");
                context.SaveChanges(); // Save changes to the database
                Console.WriteLine($"Saving Data End [{ProcessID + i}] : {DateTime.Now.Hour}:{DateTime.Now.Minute}::{DateTime.Now.Second}");
            }
        }

        private static void NewMetadata(WebHelpRocContext context, int processNow, DateTime date_insertion, string _rocServiceName, string plateform, int i)
        {
            RocMetadatum _temp = new RocMetadatum
            {
                RocRunProcessId = processNow,
                RocServiceName = _rocServiceName,
                RocIsfileexist = "OUI",
                RocCopySuccess = 1,
                RocPf = plateform,
                RocDateToExport = date_insertion.ToString("yyyy-MM-dd"),
                RocDateRunProcess = date_insertion,
                RocFlagRetour = (DateTime.Compare(date_insertion, DateTime.Today) == 0) ? null : (Faker.RandomNumber.Next(-5, 200) > 0) ? "OK_TO_DELETE" : "NO_RETOUR"
            };

            try
            {
                context.RocMetadata.Add(_temp);
                
                Console.WriteLine($"[{i}] : Import Export Metadata created.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        #region Utils
        static string[] GenererValeursAleatoires(int n, string[] valeursPossibles)
        {
            // Tableau de chaînes contenant les valeurs possibles

            // Génération d'un tableau de taille n avec des valeurs aléatoires
            Random rand = new Random();
            string[] valeursAleatoires = new string[n];
            for (int i = 0; i < n; i++)
            {
                int indiceAleatoire = rand.Next(0, valeursPossibles.Length);
                valeursAleatoires[i] = valeursPossibles[indiceAleatoire];
            }

            return valeursAleatoires;
        }
        #endregion

    }
}