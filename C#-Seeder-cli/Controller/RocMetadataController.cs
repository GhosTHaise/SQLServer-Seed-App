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

        public static String[] BaseName = {"DE","FR","EN","IT","SP","CAMP"};
        public static String[] Name = {"LINKY","NIXIS","TDE_WINBACK","TEST","SPARK","EMAILING"};
        
        public  void GenerateRocCampaign()
        {
            Console.WriteLine("Please enter the number of Day to be generated:");
            //int userInput = int.Parse(Console.ReadLine() ?? "0");
            String[] PF = context.RocPfs.Select( cc => cc.RocPfname ).ToArray<string>();
            int? maxProcessIdStored = context.RocMetadata.Max(m => m.RocRunProcessId) ?? null;
            if(maxProcessIdStored != null){
                DateTime? lastDataTime = context.RocMetadata.Max(m => m.RocDateRunProcess);
                if(lastDataTime != null){
                    TimeSpan difference = DateTime.Today - (lastDataTime ?? DateTime.Today);
                    int differenceJour = difference.Days;
                }
            }else{

            }

            /* if (1 > 0 || true)
            {

                for (int i = 0; i < userInput; i++)
                {
                    NewRocCampaign(context, i,PF);
                }
            }
            else
            {
                Console.WriteLine("Invalid number.");
            } */
        }

         private static void RunProcess(int ProcessID,int day_difference){
            
            for(int i=1;i <= day_difference;i++){

            }
         }

        private static void NewRocCampaign(WebHelpRocContext context, int i,string[] PfName)
        {
            RocMetadatum _temp = new RocMetadatum
            {
               
            };

            try
            {
                context.RocMetadata.Add(_temp);
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