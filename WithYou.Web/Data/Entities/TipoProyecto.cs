using System.Collections.Generic;

namespace WithYou.Web.Data.Entities
{
    public class TipoProyecto : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection <Investigation> Investigations { get; set; }
    }
}
