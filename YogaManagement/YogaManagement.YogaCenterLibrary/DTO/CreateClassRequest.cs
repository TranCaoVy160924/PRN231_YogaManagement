using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogaCenterLibrary.Models;

namespace YogaCenterLibrary.DTO
{
    public class CreateClassRequest
    {
        public Class ClassDTO { get; set; }
        public List<Slot> SlotDTOs { get; set; }
    }
}
