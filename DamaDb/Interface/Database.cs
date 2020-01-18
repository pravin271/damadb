using DamaDb.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DamaDb.Interface
{
    public interface IDatabase
    {
        Task CreateTableAsync();
        Task UpdateTableAsync();
        Task DeleteTableAsync();
        Task CreateIndexAsync();
        Task UpdateIndexAsync();
        Task DeleteIndexAsync();
        Task InsertAsync();
        Task InsertOrReplaceAsync();
        Task DeleteAsync();
        Task GetAsync();
    }

    public class Database : IDatabase
    {
        private readonly string _databasePath;

        private bool _init = false;
        private IEngine _engine = null;

        public Database(string databsePath)
        {
            _databasePath = databsePath;
        }

        private async Task Init()
        {
            _engine = new Engine(_databasePath);
            await _engine.Init();
            _init = true;
        }

        public async Task CreateTableAsync()
        {
            if (!_init) await this.Init();
        }

        public Task CreateIndexAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteIndexAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteTableAsync()
        {
            throw new NotImplementedException();
        }

        public Task GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync()
        {
            throw new NotImplementedException();
        }

        public Task InsertOrReplaceAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateIndexAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateTableAsync()
        {
            throw new NotImplementedException();
        }
    }
}
