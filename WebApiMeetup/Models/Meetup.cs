using System;
using System.Collections.Generic;

namespace WebApiMeetup.Models
{
    public partial class Meetup
    {
        public Meetup()
        {
            Participents = new HashSet<Participents>();
        }

        public int Code { get; set; }
        public DateTime? Date { get; set; }
        public string Details { get; set; }
        public int DistrictCode { get; set; }
        public int MeetupTypeCode { get; set; }


        public  Districts DistrictCodeNavigation { get; set; }
        public  MeetupType MeetupTypeCodeNavigation { get; set; }
        public  ICollection<Participents> Participents { get; set; }
    }
}
