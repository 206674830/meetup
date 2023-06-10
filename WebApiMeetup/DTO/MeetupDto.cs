using System.Collections.Generic;
using System;
using WebApiMeetup.Models;

namespace WebApiMeetup.DTO
{
    public class MeetupDto
    {
        public int code { get; set; }
        public DateTime? date { get; set; }
        public string details { get; set; }
        public string district { get; set; }
        public string meetupType { get; set; }

        public List<ParticipentsDto> participents { get; set; }
    }
}
