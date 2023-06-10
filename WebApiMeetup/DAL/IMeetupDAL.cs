using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiMeetup.DTO;
using WebApiMeetup.Models;

namespace meetup.DAL
{
    public interface IMeetupDAL
    {

        Task<List<Meetup>> GetAllMeetups(PagingParams pagingParams);
        Task<bool> inserMeetup(Meetup meetup);
        Task<bool> updateMeetup([FromBody] Meetup meetup);
        Task<bool> deleteMeetup(Meetup meetup);

    }
}
