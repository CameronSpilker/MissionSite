using BlowOut.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlowOut.DAL
{
    public class MissionaryContext : DbContext
    {
        public MissionaryContext() : base("MissionaryContext")
        {

        }
    

        public DbSet<MissionQuestions> MissionQuestions { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Missions> Missions { get; set; }
    }
}

