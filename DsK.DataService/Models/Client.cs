using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsK.DataService.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsAstronaut { get; set; }
        public List<Hobby> Hobbies { get; set; }
    }
}
