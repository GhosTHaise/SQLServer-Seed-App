using System;

namespace utils
{
    public class FileDayInterval
    {
        int max;
        int min;

        public FileDayInterval(int _min , int _max)
        {
            this.max = _max;
            this.min = _min;
        }
    


        public Dictionary<int,FileDayInterval> getDaysFileMigrationInterval(){
            Dictionary<int, FileDayInterval> dc = new Dictionary<int, FileDayInterval>
            {
                { 0, new FileDayInterval(271, 1200) },
                { 1, new FileDayInterval(80234,92000)},
                { 2, new FileDayInterval(92234,110120)},
                { 3, new FileDayInterval(79934,84960)},
                { 4, new FileDayInterval(78234,85320)},
                { 5, new FileDayInterval(83234,86780)},
                { 6, new FileDayInterval(5234,7780)},

            };

            return dc;
        }
    }
}