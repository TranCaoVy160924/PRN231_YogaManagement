﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaManagement.Contracts.Enrollment;
public class EnrollmentDTO
{
    public DateTime EnrollDate { get; set; }
    public double Discount { get; set; }
    public int MemberId { get; set; }
    public int YogaClassId { get; set; }

    // Display 
    public string? MemberName { get; set; }
    public string? YogaClassName { get; set; }
}