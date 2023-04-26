using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recobookation.Domain
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }

        public string Genre { get; set; }
        public string Description { get; set; }
    }
}