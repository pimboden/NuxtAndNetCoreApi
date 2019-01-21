using System;
using System.Collections.Generic;
using _8anu.Api.Common.Enums;

namespace _8anu.Api.Common.Models
{
    public class BasicUserProfile
    {
        public string Slug { get; set; }
        public string Avatar { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public GenderEnum Gender { get; set; }
        public DateTime Birthday { get; set; }
        public int Age { get; set; }
        public int FollowingCount { get; set; }
        public int FollowersCount { get; set; }
        public List<SocialMediaInfo> SocialMediaInfos {  get; set; }
        public GeoCoordinate GeoData { get; set; }
    }
}