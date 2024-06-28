using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
    public class Note
    {
        public string Title { get; set; }
        public string Description { get; set; }
        [Key]
        public int Id { get;  set; }
    }
}
