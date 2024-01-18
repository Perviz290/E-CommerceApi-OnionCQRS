using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Common
{
    public class EntityBase : IEntityBase
    {

        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedDate { get; set; }


    }
}
