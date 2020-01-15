using DamaDb.Table.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DamaDb.Header.Model
{
    public class HeaderInfo
    {
        public long MaxId { get; set; }
        public long DataStartIndex { get; set; }
        public IEnumerable<long> DeletedRecords { get; set; }
        public long Count { get; set; }
        public IEnumerable<TableInfo> Tables { get; set; }
    }
}
