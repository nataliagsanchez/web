using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.MVC.Data;

public class EnrollmentMetadata
{
    public int Id { get; set; }

    [Display(Name = "Id del alumno")]
    public int? StudentId { get; set; }

    [Display(Name = "Id de la Clase")]
    public int? ClassId { get; set; }

    [Display(Name = "Nota")]
    public string? Grade { get; set; }

    [Display(Name = "Id de la clase")]
    public virtual Class? Class { get; set; }

    [Display(Name = "Id del alumno")]
    public virtual Student? Student { get; set; }
}

[ModelMetadataType(typeof(EnrollmentMetadata))]

public partial class Enrollment { }
