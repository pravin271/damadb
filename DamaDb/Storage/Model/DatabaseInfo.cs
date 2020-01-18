using System;
using System.Collections.Generic;
using System.Text;
using DamaDb.Header.Model;

namespace DamaDb.Storage.Model
{
    public class DatabaseInfo
    {
        public string Engine { get; set; }
        public HeaderInfo Header { get; set; }
        public long HeaderPosition { get; set; }
        public long HeaderLength { get; set; }
    }
}
