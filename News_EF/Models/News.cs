using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace News_EF.Models
{
    public class News
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        
        public DateTime NewsDate { get; set; }
        public List<Comments> Coments { get; set; } //список коментариев

        public News()
        {
            //выделяем память под новый список
            Coments = new List<Comments>();
            NewsDate = DateTime.Now;
        }
    }
}
