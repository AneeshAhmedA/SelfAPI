using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Self.Entity
{
    public class Conference
    {
        [Key]
        public int conferenceID {  get; set; }

        public string title {get; set; }

        public string description { get; set; }

        public DateTime Date { get; set; }

        public string location { get; set; }

        public int userId { get; set; }

        [ForeignKey(nameof(userId))]
        public User User { get; set; }

    }
}
