using System.ComponentModel.DataAnnotations;

namespace UnderstandingMVC.Models
{
    public class AddStudentViewModel
    {
        [Required(ErrorMessage ="Please enter name")]
         public string Name { get; set; }

        [Required(ErrorMessage ="Please enter phone")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter branch")]
        public string Branch { get; set; }

        [Required(ErrorMessage = "Please enter semester")]
        public int Semester { get; set; }

        [Required(ErrorMessage = "Please enter result")]
        public double Result { get; set; }

        [Required(ErrorMessage = "Please enter address")]
        public string Address { get; set; }
    }
}
