using DamaDb.Index.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DamaDb.Table.Model
{
    public class TableInfo
    {
        public string Name { get; set; }
        public IEnumerable<ColumnInfo> Columns { get; set; }
        public IEnumerable<IndexInfo> Indexes { get; set; }

    }
}
