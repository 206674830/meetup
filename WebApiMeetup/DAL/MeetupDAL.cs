using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApiMeetup.Models;
using WebApiMeetup.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace meetup.DAL
{
    public class MeetupDAL: IMeetupDAL
    {

        public async Task<List<Meetup>> GetAllMeetups(PagingParams pagingParams)
        {
            try
            {
                using (var db = new meetupContext())
                {
                    return db.Meetup.Include(m => m.MeetupTypeCodeNavigation)
                        .Include(m => m.DistrictCodeNavigation).Include(m => m.Participents).ThenInclude(p => p.IdNavigation)
                                .ToList()
                                .Skip((pagingParams.PageNumber - 1) * pagingParams.PageSize)
                                .Take(pagingParams.PageSize)
                                .ToList();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


       public async Task<bool> inserMeetup(Meetup meetup)
        {
            try
            {
                using (var db = new meetupContext())
                {
                    db.Meetup.Add(meetup);
                    db.SaveChanges();
                    return true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public async Task<bool> updateMeetup(Meetup meetup)
        {
            try
            {
                using (var db = new meetupContext())
                {
                    Meetup item = db.Meetup.Where(x=>x.Code == meetup.Code).FirstOrDefault();
                    if (item != null)
                    {
                        item.Details = meetup.Details;
                        db.SaveChanges();
                    }
                    return true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        public async Task<bool> deleteMeetup(Meetup meetup)
        {
            try
            {
                using (var db = new meetupContext())
                {
                    Meetup item = db.Meetup.Include(f=>f.Participents).Where(x => x.Code == meetup.Code).FirstOrDefault();
                    if (item != null) {
                        item.MeetupTypeCodeNavigation = null;
                        item.DistrictCodeNavigation = null;
                        item.Participents = null;
                        db.Entry(item).State = EntityState.Deleted;
                        db.SaveChanges();
                    }
                    return true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
