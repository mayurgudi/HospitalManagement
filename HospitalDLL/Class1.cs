using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalDLL
{
    public class PatientDTO 
    {
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public List<ProblemDTO> Problems { get; set; }
    }

    public class ProblemDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<TreatmentDTO> Treatments { get; set; }
    }

    public class TreatmentDTO
    {
        public string Name { get; set; }

        public string Dosage { get; set; }
    }

    public class Patient
    {
        public int id { get; set; }
        
        [Required(ErrorMessage = "Please enter patient's name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter contact number")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Please enter valid contact number")]
        public string Phone { get; set; }

        public string Address { get; set; }

        public List<Problem> Problems { get; set; }
    }

    public class Problem
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Please enter the problem")]
        public string Name { get; set; }

        public string Description { get; set; }

        public List<Treatment> Treatments { get; set; }
    }

    public class Treatment
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Treatment name is necessary")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Treatment should have a dosage")]
        [RegularExpression(@"^[0-9]{1,1}-[0-9]{1,1}-[0-9]{1,1}-[0-9]{1,1}$", ErrorMessage = "Proper format required")]
        public string Dosage { get; set; }
    }
}
