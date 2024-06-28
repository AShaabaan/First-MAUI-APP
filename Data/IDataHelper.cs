using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Data
{
    public interface IDataHelper <Table>
    {
        Task <List<Table>> GetAllAsync ();
        Task <Table> FindAsync (int id);
        Task AddDataAsync (Table table);
        Task UpdateDataAsync (Table table);
        Task DeleteDataAsync (Table table);

    }
}
