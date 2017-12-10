using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackwardChainingMVVM.Model
{
    public class UserTemperament
    {
        public bool IsApathetic { get; set; } // melancholic

        public bool IsPessimistic { get; set; }

        public bool IsUnsociable { get; set; }


        public bool IsAgressive { get; set; } // spitfire

        public bool IsUnstable { get; set; }

        public bool IsIrritable { get; set; }


        public bool IsSociable { get; set; } // sanguine

        public bool IsSensitive { get; set; }

        public bool IsLeadership { get; set; }


        public bool IsPassive { get; set; } // phlegmatic

        public bool IsConsiderable { get; set; }

        public bool IsCareful { get; set; }
    }
}
