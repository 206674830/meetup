using meetup.DAL;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApiMeetup.DAL;
using WebApiMeetup.DTO;
using WebApiMeetup.Models;

namespace meetup.BL
{
    public class MeetupBL : IMeetupBL
    {
        IMeetupDAL meetupDAL;
        IDistrictDAL districtDAL;
        public MeetupBL(IMeetupDAL meetupDAL, IDistrictDAL districtDAL)
        {
            this.meetupDAL = meetupDAL;
            this.districtDAL = districtDAL;
        }

        public async Task<List<MeetupDto>> GetAllMeetups(PagingParams pagingParams)
        {

            List<Meetup> list = await meetupDAL.GetAllMeetups(pagingParams);
            List<MeetupDto> res = list.Select(meetup =>
            new MeetupDto
            {
                code = meetup.Code,
                date = meetup.Date,
                details = meetup.Details,
                district = meetup.DistrictCodeNavigation?.Description,
                meetupType = meetup.MeetupTypeCodeNavigation?.Description,
                participents = getParticipents(meetup.Participents.ToList())
            }).ToList();

            return res;
        }
        private List<ParticipentsDto> getParticipents(List<Participents> participents)
        {
            List<ParticipentsDto> res = participents.Select(p=>
                        new ParticipentsDto
                       {
                           name = p.IdNavigation.Name,
                           email = p.IdNavigation.Email,
                           id = p.IdNavigation.Id,
                           phone = p.IdNavigation.Phone
                       }).ToList();
            return res;
        }

        public async Task<bool> inserMeetup(Meetup meetup)
        {
            return await meetupDAL.inserMeetup(meetup);
        }

        public async Task<bool> updateMeetup(Meetup meetup)
        {
            return await meetupDAL.updateMeetup(meetup);
        }
        public async Task<bool> deleteMeetup(Meetup meetup)
        {
            return await meetupDAL.deleteMeetup(meetup);
        }


    }

}
