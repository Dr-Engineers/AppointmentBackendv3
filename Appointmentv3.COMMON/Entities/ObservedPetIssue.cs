using Appointmentv3.COMMON.Entities.Preset;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointmentv3.COMMON.Entities
{
    public class ObservedPetIssue
    {
        public int ObservedPetIssueID { get; set; }
        public virtual PetIssue PetIssue { get; set; }
    }
}
