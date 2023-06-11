﻿using System.ComponentModel.DataAnnotations;

namespace YogaManagement.Contracts.Course.Request;
public class CourseCreateRequest
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public double Price { get; set; }
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public DateTime EnddDate { get; set; }
    [Required]
    public bool IsActive { get; set; }
    [Required]
    public int CategoryId { get; set; }
}
