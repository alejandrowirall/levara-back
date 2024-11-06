using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Levara.Domain.Models
{
    public abstract class Entity
    {
        public int Id { get; set; }

        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastEditedDate { get; set; }

        public int? CreatorId { get; set; }
        public int? LastEditorId { get; set; }
    }
}
