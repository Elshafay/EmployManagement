using Demo.DAL.Entities;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Demo.PL.Models
{
    [Index(nameof(Name))]
    public class WorkersViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(10)]
        public string Address { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public DateTime HireDate { get; set; }
        public IFormFile Images { get; set; }
        public string? ImagesUrl { get; set; }
        public int DepartmentId { get; set; }


    }
    
      
        
    }

