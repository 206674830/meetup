using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiMeetup.Models;

namespace WebApiMeetup.DAL
{
    public interface IDistrictDAL
    {
        Task<List<Districts>> GetAllDistricts();
        Task<List<MeetupType>> GetAllMeetupType();

    }
}
