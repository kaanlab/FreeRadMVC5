using Microsoft.Practices.Unity;
using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Web;

namespace FreeRadMVC5.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MySqlContext : DbContext
    {
        [InjectionConstructor]
        public MySqlContext()
            : base("MySqlContext")
        {
            
        }

        public MySqlContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserAttribute> UserAttributes { get; set; }

        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupAttribute> GroupAttributes { get; set; }

        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<Nas> Nases { get; set; }
        public DbSet<AccessLog> AccessLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().MapToStoredProcedures();
            modelBuilder.Entity<UserAttribute>().MapToStoredProcedures();

            modelBuilder.Entity<Group>().MapToStoredProcedures();
            modelBuilder.Entity<GroupAttribute>().MapToStoredProcedures();

            modelBuilder.Entity<UserGroup>().MapToStoredProcedures();
            modelBuilder.Entity<Nas>().MapToStoredProcedures();
            modelBuilder.Entity<AccessLog>().MapToStoredProcedures();

            // User data annotations
            modelBuilder.Entity<User>().ToTable("radcheck");
            modelBuilder.Entity<User>().Property(u => u.UserName).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("username")));

            modelBuilder.Entity<User>().Property(u => u.UserName).IsRequired().HasMaxLength(64).IsUnicode(false);
            modelBuilder.Entity<User>().Property(u => u.Attribute).IsRequired().HasMaxLength(64).IsUnicode(false);
            modelBuilder.Entity<User>().Property(u => u.Op).IsRequired().HasMaxLength(2).IsUnicode(false);
            modelBuilder.Entity<User>().Property(u => u.Value).IsRequired().HasMaxLength(253).IsUnicode(false);

            // UserAttribute data annotations
            modelBuilder.Entity<UserAttribute>().ToTable("radreply");
            modelBuilder.Entity<UserAttribute>().Property(u => u.UserName).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("username")));

            modelBuilder.Entity<UserAttribute>().Property(u => u.UserName).IsRequired().HasMaxLength(64).IsUnicode(false);
            modelBuilder.Entity<UserAttribute>().Property(u => u.Attribute).IsRequired().HasMaxLength(64).IsUnicode(false);
            modelBuilder.Entity<UserAttribute>().Property(u => u.Op).IsRequired().HasMaxLength(2).IsUnicode(false);
            modelBuilder.Entity<UserAttribute>().Property(u => u.Value).IsRequired().HasMaxLength(253).IsUnicode(false);

            // Group data annotations
            modelBuilder.Entity<Group>().ToTable("radgroupcheck");
            modelBuilder.Entity<Group>().Property(g => g.GroupName).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("groupname")));

            modelBuilder.Entity<Group>().Property(g => g.GroupName).IsRequired().HasMaxLength(64).IsUnicode(false);
            modelBuilder.Entity<Group>().Property(g => g.Attribute).IsRequired().HasMaxLength(64).IsUnicode(false);
            modelBuilder.Entity<Group>().Property(g => g.Op).IsRequired().HasMaxLength(2).IsUnicode(false);
            modelBuilder.Entity<Group>().Property(g => g.Value).IsRequired().HasMaxLength(253).IsUnicode(false);

            // GroupAttribute data annotations
            modelBuilder.Entity<GroupAttribute>().ToTable("radgroupreply");
            modelBuilder.Entity<GroupAttribute>().Property(g => g.GroupName).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("groupname")));

            modelBuilder.Entity<GroupAttribute>().Property(g => g.GroupName).IsRequired().HasMaxLength(64).IsUnicode(false);
            modelBuilder.Entity<GroupAttribute>().Property(g => g.Attribute).IsRequired().HasMaxLength(64).IsUnicode(false);
            modelBuilder.Entity<GroupAttribute>().Property(g => g.Op).IsRequired().HasMaxLength(2).IsUnicode(false);
            modelBuilder.Entity<GroupAttribute>().Property(g => g.Value).IsRequired().HasMaxLength(253).IsUnicode(false);

            // UserGroup data annotations
            modelBuilder.Entity<UserGroup>().ToTable("radusergroup");
            modelBuilder.Entity<UserGroup>().Property(ug => ug.UserName).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("username")));

            modelBuilder.Entity<UserGroup>().Property(ug => ug.UserName).IsRequired().HasMaxLength(64).IsUnicode(false);
            modelBuilder.Entity<UserGroup>().Property(ug => ug.GroupName).IsRequired().HasMaxLength(64).IsUnicode(false);
            modelBuilder.Entity<UserGroup>().Property(ug => ug.Priority).IsRequired();

            // Nas data anntations
            modelBuilder.Entity<Nas>().ToTable("nas");
            modelBuilder.Entity<Nas>().Property(n => n.NasName).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("NasName")));

            modelBuilder.Entity<Nas>().Property(n => n.NasName).IsRequired().HasMaxLength(128).IsUnicode(false);
            modelBuilder.Entity<Nas>().Property(n => n.ShortName).HasMaxLength(32).IsUnicode(false);
            modelBuilder.Entity<Nas>().Property(n => n.Type).HasMaxLength(30).IsUnicode(false);
            modelBuilder.Entity<Nas>().Property(n => n.Secret).IsRequired().HasMaxLength(60).IsUnicode(false);
            modelBuilder.Entity<Nas>().Property(n => n.Community).HasMaxLength(50).IsUnicode(false);
            modelBuilder.Entity<Nas>().Property(n => n.Description).HasMaxLength(200).IsUnicode(false);

            // AccessLog data anntations
            modelBuilder.Entity<AccessLog>().ToTable("radacct");
            modelBuilder.Entity<AccessLog>().HasKey(l => l.RadAcctId);
            modelBuilder.Entity<AccessLog>().Property(l => l.AcctSessionId).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("acctsessionid")));
            modelBuilder.Entity<AccessLog>().Property(l => l.AcctUniqueId).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("acctuniqueid") { IsUnique = true }));
            modelBuilder.Entity<AccessLog>().Property(l => l.UserName).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("username")));
            modelBuilder.Entity<AccessLog>().Property(l => l.NasIpAddress).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("nasipaddress")));
            modelBuilder.Entity<AccessLog>().Property(l => l.AcctInterval).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("acctinterval")));
            modelBuilder.Entity<AccessLog>().Property(l => l.AcctStartTime).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("acctstarttime")));
            modelBuilder.Entity<AccessLog>().Property(l => l.AcctStopTime).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("acctstoptime")));
            modelBuilder.Entity<AccessLog>().Property(l => l.FramedIpAddress).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("framedipaddress")));

            modelBuilder.Entity<AccessLog>().Property(l => l.RadAcctId).HasColumnType("BIGINT");
            modelBuilder.Entity<AccessLog>().Property(l => l.AcctSessionId).IsRequired().HasMaxLength(32).IsUnicode(false);
            modelBuilder.Entity<AccessLog>().Property(l => l.AcctUniqueId).IsRequired().HasMaxLength(32).IsUnicode(false);
            modelBuilder.Entity<AccessLog>().Property(l => l.UserName).IsRequired().HasMaxLength(64).IsUnicode(false);
            modelBuilder.Entity<AccessLog>().Property(l => l.GroupName).IsRequired().HasMaxLength(64).IsUnicode(false);
            modelBuilder.Entity<AccessLog>().Property(l => l.Realm).HasMaxLength(64).IsUnicode(false);
            modelBuilder.Entity<AccessLog>().Property(l => l.NasIpAddress).IsRequired().HasMaxLength(15).IsUnicode(false);
            modelBuilder.Entity<AccessLog>().Property(l => l.NasPortId).HasMaxLength(15).IsUnicode(false);
            modelBuilder.Entity<AccessLog>().Property(l => l.NasPortType).HasMaxLength(32).IsUnicode(false);
            modelBuilder.Entity<AccessLog>().Property(l => l.AcctAuthentic).HasMaxLength(32).IsUnicode(false);
            modelBuilder.Entity<AccessLog>().Property(l => l.ConnectInfo_start).HasMaxLength(50).IsUnicode(false);
            modelBuilder.Entity<AccessLog>().Property(l => l.ConnectInfo_stop).HasMaxLength(50).IsUnicode(false);
            modelBuilder.Entity<AccessLog>().Property(l => l.AcctInputOctets).HasColumnType("BIGINT");
            modelBuilder.Entity<AccessLog>().Property(l => l.AcctOutputOctets).HasColumnType("BIGINT");
            modelBuilder.Entity<AccessLog>().Property(l => l.CalledStationId).IsRequired().HasMaxLength(50).IsUnicode(false);
            modelBuilder.Entity<AccessLog>().Property(l => l.CallingStationId).IsRequired().HasMaxLength(50).IsUnicode(false);
            modelBuilder.Entity<AccessLog>().Property(l => l.AcctTerminateCause).IsRequired().HasMaxLength(32).IsUnicode(false);
            modelBuilder.Entity<AccessLog>().Property(l => l.ServiceType).HasMaxLength(32).IsUnicode(false);
            modelBuilder.Entity<AccessLog>().Property(l => l.FramedProtocol).HasMaxLength(32).IsUnicode(false);
            modelBuilder.Entity<AccessLog>().Property(l => l.FramedIpAddress).IsRequired().HasMaxLength(15).IsUnicode(false);
        }
    }
}