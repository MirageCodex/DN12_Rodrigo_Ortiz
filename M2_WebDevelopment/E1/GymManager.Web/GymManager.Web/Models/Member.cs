namespace GymManager.Web.Models
{
    public class Member
    {
        public string name { get; set; }

        public string lastName { get; set; }

        public DateTime birth { get; set; }

        public int cityId { get; set; }

        public string email { get; set; }

        public bool allowNewsLetter { get; set; }
    }
}
