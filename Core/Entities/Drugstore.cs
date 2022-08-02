using Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Drugstore: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int ContactNumber { get; set; }
        public Druggist Druggists { get; set; }
        public Drug Drugs { get; set; }
        public Owner Owner { get; set; }
    }
}
