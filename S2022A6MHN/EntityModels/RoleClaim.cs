using System.ComponentModel.DataAnnotations;

namespace S2022A6MHN.EntityModels
{
    public class RoleClaim
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }
    }
}