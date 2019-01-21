using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _8anu.Api.Common.DataEntities;
using _8anu.Api.Common.Enums;
using _8anu.Api.Common.Models;
using _8anu.Api.Data.Contexts;
using _8anu.Api.Data.Repositories.Interfaces;
using _8anu.Data;

namespace _8anu.Api.Data.Repositories
{
    public class UsersRepository:Repository<User>, IUsersRepository
    {
        private DomainModelMySqlContext _context;
        public UsersRepository(DomainModelMySqlContext context) : base(context)
        {
            _context = context;
        }

        public new IEnumerable<User> GetAll(int pageIndex = 0, int pageSize = 50)
        {
            return _context.Set<User>().Skip(pageIndex * pageSize).Take(pageSize).Include(u => u.Country).ToList();
        }

        /// <summary>
        /// TODO: This is a MOCK!!!!
        /// </summary>
        /// <param name="userSlug"></param>
        /// <returns></returns>
        public async Task<BasicUserProfile> GetBasicUserProfileAsync(string userSlug)
        {
            return await Task.Run(async () =>
            {
                await Task.Delay(300);
                var basicUserProfile = new BasicUserProfile();
                basicUserProfile.Slug = userSlug;
                basicUserProfile.Avatar = "https://placehold.it/150x150";
                basicUserProfile.Birthday = new DateTime(1972, 6, 11);
                basicUserProfile.Firstname = "Poco";
                basicUserProfile.Lastname = "Loco";
                basicUserProfile.FollowersCount = 123457;
                basicUserProfile.FollowingCount = 53452;
                basicUserProfile.Gender = GenderEnum.Male;
                basicUserProfile.SocialMediaInfos = new List<SocialMediaInfo>
                {
                    new SocialMediaInfo
                    {
                        SocialMediaService = SocialMediaServiceEnum.Facebook,
                        Link = "https://www.facebook.com/PocoLoco/"
                    },
                    new SocialMediaInfo
                    {
                        SocialMediaService = SocialMediaServiceEnum.Instagram,
                        Link = "https://www.instagram.com/p/Bg1BMjSHpjM/"
                    }
                };
                basicUserProfile.GeoData = new GeoCoordinate
                {
                    Latitude = 46.968554,
                    Longitude = 8.360879,
                    Name = "Stans"
                };
                basicUserProfile.Age = GetAge(basicUserProfile.Birthday);
                return basicUserProfile;
            });

        }

        private int GetAge(DateTime birthday)
        {
            // Save today's date.
            var today = DateTime.Today;
            // Calculate the age.
            var age = today.Year - birthday.Year;
            // Go back to the year the person was born in case of a leap year
            if (birthday > today.AddYears(-age))
                age--;
            return age;
        }
    }
}