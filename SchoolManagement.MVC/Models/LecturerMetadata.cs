using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.MVC.Data;

public class LecturerMetadata
{
    public int Id { get; set; }


    [Display(Name = "Nombre")]
    public string FirstName { get; set; } = null!;

    [Display(Name = "Apellido")]
    public string LastName { get; set; } = null!;
}

[ModelMetadataType(typeof(LecturerMetadata))]
public partial class Lecturer { }
