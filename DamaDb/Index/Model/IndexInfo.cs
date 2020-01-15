using DamaDb.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace DamaDb.Index.Model
{
    public class IndexInfo
    {
        public int IndexId { get; set; }
        public int ColumnId { get; set; }
        public IndexType IndexType { get; set; }
        public bool Unique { get; set; }
        public bool Cluster { get; set; }
    }
}
