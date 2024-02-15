using System.ComponentModel.DataAnnotations;

namespace Self.DTO
{
    public class trainDTO
    {
        [Key]
        public int trainNo { get; set; }

        public string trainName { get; set; }

        public string trainType { get; set; }

        public int trainSize { get; set; }
    }
}
