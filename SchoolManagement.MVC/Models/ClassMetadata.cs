using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.MVC.Data;

public class ClassMetadata
{
    public int Id { get; set; }

    [Display(Name = "Profesor")]
    public int? LecturerId { get; set; }
    [Display(Name = "Asignatura")]
    public int? CourseId { get; set; }
    [Display(Name = "Hora")]
    public TimeSpan? Time { get; set; }
    [Display(Name = "Asignatura")]
    public virtual Course? Course { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; } = new List<Enrollment>();
    [Display(Name = "Profesor")]
    public virtual Lecturer? Lecturer { get; set; }
}

[ModelMetadataType(typeof(ClassMetadata))]

public partial class Class { }
