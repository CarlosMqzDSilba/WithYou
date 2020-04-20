using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WithYou.Web.Data.Entities
{
    public class RepublicState : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public ICollection<Investigation> Investigations { get; set; }
    }
    
}
