using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DamaDb.Storage
{
    /// <summary>
    /// Engine for handling read/write
    /// </summary>
    public interface IEngine
    {
        Task Init();
    }
}
