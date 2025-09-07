using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PoolApp.Domain.Entities
{
    [Table("MatchesGroups")]
    public class GamesGroups
    {
        public int id { get; set; }
        public int? GroupID { get; set; }  
        public int HomeTeamID { get; set; }           
        public int AwayTeamID { get; set; }
        public DateTime MatchDateTime { get; set; }
        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }
       
        public virtual UsersGuessGroups? Usersguess { get; set; }
        public virtual Teams? HomeTeam { get; set; }
        public virtual Teams? AwayTeam { get; set; }


    }

    [Table("UsersGuessGroups")]
    public class UsersGuessGroups
    {
        public int id { get; set; }
        public int MatchID { get; set; }
        public int UserID { get; set; }
        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }
       // public virtual Games? Game { get; set; }
    }

    [Table("Users")]
    public class Users
    {
        public int id { get; set; }
        public string? Name { get; set; }
        public int AccessCode { get; set; }
    }

    [Table("Teams")]
    public class Teams
    {
        public int id { get; set; }
        public string? Name { get; set; }
        public int GroupId { get; set; }
        public virtual Groups? Group { get; set; }
    }

    [Table("Groups")]
    public class Groups
    {
        public int id { get; set; }
        public string? Name { get; set; }
    }
}
