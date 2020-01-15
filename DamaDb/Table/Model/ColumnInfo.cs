using DamaDb.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace DamaDb.Table.Model
{
    public class ColumnInfo
    {
        public int ColumnId { get; set; }
        public string Name { get; set; }
        public DataType DataType { get; set; }
        public int Length { get; set; }
        public int Order { get; set; }
    }
}
