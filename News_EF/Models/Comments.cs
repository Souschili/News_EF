﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News_EF.Models
{
    public class Comments
    {
        public int Id { get; set; } 
        public string Author { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        
    }
}
