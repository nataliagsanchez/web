using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.MVC.Data;

public class StudentMetadata
{
    public int Id { get; set; }

    [Display(Name = "Nombre")]
    public string FirstName { get; set; } = null!;
    [Display(Name = "Apellido")]
    public string LastName { get; set; } = null!;
    [Display(Name = "Fecha de Nacimiento")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? DateOfBirth { get; set; }
}


[ModelMetadataType(typeof(StudentMetadata))]

public partial class Student {}
