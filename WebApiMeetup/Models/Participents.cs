using System;
using System.Collections.Generic;

namespace WebApiMeetup.Models
{
    public partial class Participents
    {
        public int Code { get; set; }
        public int Id { get; set; }
        public int MeetupCode { get; set; }

        public People IdNavigation { get; set; }
        public Meetup MeetupCodeNavigation { get; set; }
    }
}
