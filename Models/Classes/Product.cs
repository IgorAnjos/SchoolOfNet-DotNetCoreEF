using System;

namespace SchoolOfNetStudy_DoeNetCoreEF.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime Validity { get; set; }
        public string Descripton { get; set; }
    }
}