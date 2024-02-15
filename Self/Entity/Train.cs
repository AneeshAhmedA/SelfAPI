using System.ComponentModel.DataAnnotations;

namespace Self.Entity
{
    public class Train
    {
        [Key]
        public int trainNo {  get; set; }

        public string trainName { get; set; }

        public string trainType { get; set; }

        public int trainSize { get; set; }
    }
}
