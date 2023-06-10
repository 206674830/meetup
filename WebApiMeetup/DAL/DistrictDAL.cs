using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiMeetup.DTO;
using WebApiMeetup.Models;

namespace WebApiMeetup.DAL
{
    public class DistrictDAL : IDistrictDAL
    {
        public async Task<List<Districts>> GetAllDistricts()
        {
            try
            {
                using (var db = new meetupContext())
                {
                    return db.Districts.ToList();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<MeetupType>> GetAllMeetupType()
        {
            try
            {
                using (var db = new meetupContext())
                {
                    return db.MeetupType.ToList();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}
