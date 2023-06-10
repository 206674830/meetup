using System;
using System.Collections.Generic;

namespace WebApiMeetup.Models
{
    public partial class People
    {
        public People()
        {
            Participents = new HashSet<Participents>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Participents> Participents { get; set; }
    }
}
