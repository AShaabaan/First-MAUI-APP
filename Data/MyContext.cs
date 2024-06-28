using MauiApp1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Data
{
    public class MyContext :DbContext
    {
        //Add Tables
        public DbSet <Note> Notes { get; set; }
        //Connect to DB
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //to resolve Protection on andriod 
            //string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //var fileName = Path.Combine(path, "DBNote.db");
            //optionsBuilder.UseSqlite("Filename="+fileName);
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "DBNote.db");
            optionsBuilder.UseSqlite($"Filename={dbPath}");

        }

    }
}
