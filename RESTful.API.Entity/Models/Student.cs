using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RESTful.API.Entity.Models;

[Table("Student")]
public partial class Student
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(60)]
    public string Name { get; set; } = null!;

    [StringLength(60)]
    public string Surname { get; set; } = null!;
}
