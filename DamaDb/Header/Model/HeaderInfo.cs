using DamaDb.Table.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DamaDb.Header.Model
{
    [Serializable]
    public class HeaderInfo
    {
        public const int HeaderLengthSize = 4;

        public int ActualHeaderLength { get; set; }
        public long DataPosition { get; set; } = (1024 * 1024) + 1;
        public int TabeCount { get; set; }
        public IEnumerable<TableInfo> Tables { get; set; }
    }
}
