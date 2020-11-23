using KVANT_Scada_2.DB.Entity;
using KVANT_Scada_2.UDT.Valve;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KVANT_Scada_2.DB
{
    public class MyDBContext:DbContext
    {
        public DbSet<Valves> Valve { get; set; }
        public DbSet<CrioPump> CrioPump { get; set; }
        public DbSet<FVP> FVP { get; set; }
        public DbSet<Ion> Ion { get; set; }
        public DbSet<CamPreapreTable> CamPrepTable { get; set; }
        public DbSet<CrioPumpStartTable> CrioPumpStart { get; set; } 
        public DbSet<OpenCamTable> OpenCam { get; set; }
        public DbSet<StopCrioTable> StopCrio { get; set; }
        public DbSet<StopFVPTable> StopFVP { get; set; }
        public DbSet<AnalogaValueTable>AnalogValue { get; set; }
        public DbSet<DigitalValueTable> DigitalValue { get; set; }
        public DbSet<IntValueTable> IntValue { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<AnalogLog>AnalogLog { get; set; }
        public DbSet<DigitalLog> DigitalLog { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server = localhost; user  = root; password = 5dae40eb*; database = OPCUA");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Valves>(entity =>
               { 
                    entity.HasKey(e => e.Id);
                    entity.Property(e => e.Name).IsRequired(); 
                });


            modelBuilder.Entity<CrioPump>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<FVP>(entity=>
            {
                entity.HasKey(e => e.Id);
            });
            modelBuilder.Entity<Ion>(entity=> {
                entity.HasKey(e => e.Id);
            });
            modelBuilder.Entity<CamPreapreTable>(entity=>
            {
                entity.HasKey(e => e.Id);
            });
            modelBuilder.Entity<CrioPumpStartTable>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
            modelBuilder.Entity<OpenCamTable>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
            modelBuilder.Entity<StopCrioTable>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
            modelBuilder.Entity<StopFVPTable>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
            modelBuilder.Entity<AnalogaValueTable>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
            modelBuilder.Entity<DigitalValueTable>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<IntValueTable>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
            modelBuilder.Entity<AnalogLog>();
            modelBuilder.Entity<DigitalLog>();
        
     
        }
    }
}
