using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muwan
{
    class SettingsModel
    {
        public int TallyWatcherInterval { get; set; }
        public int DraftWatcherInterval { get; set; }

        public string BaseDomain { get; set; }
        public string PersisterURL { get; set; }
        public string FetcherURL { get; set; }


        public string TallyTableName { get; set; }


    }
}
