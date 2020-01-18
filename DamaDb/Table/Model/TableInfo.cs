using DamaDb.Index.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DamaDb.Table.Model
{
    public class TableInfo
    {
        public string TableId { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Max Id (Primary Key Column)
        /// </summary>
        public long MaxId { get; set; }

        /// <summary>
        /// Deleted Record Ids. We don;t delete actual records, just add deleteed records RowId to this list.
        /// </summary>
        public IEnumerable<long> DeletedRecords { get; set; }

        public long RowCount { get; set; }
        public IEnumerable<ColumnInfo> Columns { get; set; }
        public IEnumerable<IndexInfo> Indexes { get; set; }
    }
}
