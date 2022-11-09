using Appointmentv3.COMMON.Entities;
using Appointmentv3.COMMON.Entities.Preset;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointmentv3.DAL
{
    public class AppointmentDbContext : DbContext
    {
        public AppointmentDbContext() : base("name=AppointmentAPIv3")
        {

        }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<PetIssue> PetIssues { get; set; }
        public DbSet<Symptom> Symptoms { get; set; }
        public DbSet<Test> Tests { get; set; }
    }
}
