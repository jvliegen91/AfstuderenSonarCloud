using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Afstuderen2020.Data.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}
