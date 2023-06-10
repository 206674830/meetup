using meetup.BL;
using meetup.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiMeetup.DTO;
using WebApiMeetup.Models;

namespace WebApiMeetup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetupController : ControllerBase
    {
        IMeetupBL meetupBL;
        public MeetupController(IMeetupBL meetupBL)
        {
            this.meetupBL = meetupBL;
        }

        [HttpPost("GetAllMeetups")]
        public async Task<ActionResult<List<MeetupDto>>> GetAllMeetups([FromBody] PagingParams pagingParams)
        {
            var res = await this.meetupBL.GetAllMeetups(pagingParams);
            return res;
        }

        [HttpPost("inserMeetup")]
        public async Task<ActionResult<bool>> inserMeetup([FromBody] Meetup meetup)
        {
            var res = await this.meetupBL.inserMeetup(meetup);
            return res;
        }

        [HttpPut("updateMeetup")]
        public async Task<ActionResult<bool>> updateMeetup([FromBody] Meetup meetup)
        {
            var res = await this.meetupBL.updateMeetup(meetup);
            return res;
        }

        [HttpDelete("deleteMeetup")]
        public async Task<ActionResult<bool>> deleteMeetup([FromBody] Meetup meetup)
        {
            var res = await this.meetupBL.deleteMeetup(meetup);
            return res;
        }
    }
}

