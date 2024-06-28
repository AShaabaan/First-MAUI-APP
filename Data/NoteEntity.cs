using MauiApp1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Data
{
    public class NoteEntity : IDataHelper<Note>
    {
        private MyContext context;

        public NoteEntity()
        {
            context = new MyContext();
        }

        public async Task<List<Note>> GetAllAsync()
        {
            return await context.Notes.ToListAsync();
        }

        public async Task AddDataAsync(Note table)
        {
                await context.Notes.AddAsync(table);
                await context.SaveChangesAsync();
        }

        public async Task DeleteDataAsync(Note table)
        {
            //await Task.Run(()=> context.Remove(table));
            //await context.SaveChangesAsync();

            var Note = await FindAsync(table.Id);
            context.Notes.Remove(Note);
            await context.SaveChangesAsync();

        }

        public async Task<Note> FindAsync(int id)
        {
            return await context.Notes.FindAsync(id);
            
        }

        public async Task UpdateDataAsync(Note table)
        {
            //await Task.Run(() => context.Update(table));
            //await context.SaveChangesAsync();
             
            context = new MyContext();
            context.Notes.Update(table);
            await context.SaveChangesAsync();

        }
    }
}
