using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News_EF.Models
{
    public class News
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; } = DateTime.Now.Date; //по умолчанию задаем текущую дату сетер приватный менять нельзя
        public List<Comments> ComentsList = new List<Comments>(); //список коментариев
    }
}
