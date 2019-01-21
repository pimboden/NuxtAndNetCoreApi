using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Nest;
using _8anu.Api.Common.Enums;

namespace _8anu.Api.Common.Models
{
    public class AscentWithUserInfo
    {
        [Number(Name = "db_id")]
        public int DatabaseId { get; set; } // would not need to change Id to DatabaseId but to stay consistent with other classes we do this here as well
        public int UserId { get; set; }
        public string UserSlug { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserImageUrl { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Type { get; set; }
        public int? Rating { get; set; }
        public bool? Project { get; set; }
        public int? Tries { get; set; }
        public bool? Repeat { get; set; }
        public string Difficulty { get; set; }
        public int? Steepness { get; set; }
        public int? Protection { get; set; }
        public string Style { get; set; }
        public string Comment { get; set; }
        public int? ZlaggableId { get; set; }
        public string ZlaggableType { get; set; }
        public int? Height { get; set; }
        public string ZlaggableKey { get; set; }
        public int? Score { get; set; }
        public int? Sits { get; set; }
        public bool? ExcludeFromRanking { get; set; }
        public bool? Chipped { get; set; }
        public int? Note { get; set; }
        public bool Recommended { get; set; }
        public int? LegacyId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        
        public int GradeIndex { get; set; }
        public ZlaggableCategoryEnum Category { get; set; }

        public CragNavigationInfo NavigationInfo { get; set; }

    }
}