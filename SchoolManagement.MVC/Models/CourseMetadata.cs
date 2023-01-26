using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.MVC.Data;

    public class CourseMetadata
    {
        public int Id { get; set; }

        [Display(Name = "Nombre de la Asignatura")]
        public string Name { get; set; } = null!;

        [Display(Name = "Código de la Asignatura")]
        public string? Code { get; set; }
    
        [Display(Name = "Créditos de la Asignatura")]
        public int? Credits { get; set; }
    }

    [ModelMetadataType(typeof(CourseMetadata))]

    public partial class Course { }

