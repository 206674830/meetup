using System;
using System.Collections.Generic;

namespace WebApiMeetup.Models
{
    public partial class MeetupType
    {
        public MeetupType()
        {
            Meetup = new HashSet<Meetup>();
        }

        public int Code { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Meetup> Meetup { get; set; }
    }
}
