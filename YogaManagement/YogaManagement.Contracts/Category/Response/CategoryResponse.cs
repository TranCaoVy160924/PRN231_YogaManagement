using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaManagement.Contracts.Category.Response;
public class CategoryResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }

}
