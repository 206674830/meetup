using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiMeetup.DTO;
using WebApiMeetup.Models;

namespace meetup.BL
{
    public interface IMeetupBL
    {
       Task<List<MeetupDto>> GetAllMeetups(PagingParams pagingParams);
        Task<bool> inserMeetup(Meetup meetup);
        Task<bool> updateMeetup( Meetup meetup);
        Task<bool> deleteMeetup(Meetup meetup);
    }
}
