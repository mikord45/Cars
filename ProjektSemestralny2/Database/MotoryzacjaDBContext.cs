using System;
using System.Collections.Generic;
using System.Data.Entity;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSemestralny.Database
{
    public class MotoryzacjaDBContext: DbContext
    {
        public MotoryzacjaDBContext():base ("name=MotoryzacjaDBContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cars>()
                .HasRequired(x => x.Engines)
                .WithMany(x => x.Cars)
                .HasForeignKey(x => x.Engine);

            modelBuilder.Entity<Cars>()
                .HasRequired(x => x.Colors)
                .WithMany(x => x.Cars)
                .HasForeignKey(x => x.Color);

            modelBuilder.Entity<Cars>()
                .HasRequired(x => x.States)
                .WithMany(x => x.Cars)
                .HasForeignKey(x => x.State);
        }

        public virtual DbSet<Cars> Cars { get; set; }
        public virtual DbSet<Colors> Colors { get; set; }
        public virtual DbSet<Engines> Engines { get; set; }
        public virtual DbSet<States> States { get; set; }
    }
}
