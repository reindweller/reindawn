using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using Reindawn.Domain.Models;

namespace Reindawn.Repository.Context
{
    public class CustomUserStore : UserStore<User, Role, Guid,
    CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public CustomUserStore(ReindawnContext context)
            : base(context)
        {
        }
    }

    public class CustomRoleStore : RoleStore<Role, Guid, CustomUserRole>
    {
        public CustomRoleStore(ReindawnContext context)
            : base(context)
        {
        }
    }


    //The main class that coordinates Entity Framework functionality for a given data model is the database context class
    public class ReindawnContext : IdentityDbContext<User, Role, Guid, CustomUserLogin, CustomUserRole, CustomUserClaim>, IContext
    {
        public ReindawnContext() : base("Reindawn")
        {
        }

        public static ReindawnContext Create()
        {
            return new ReindawnContext();
        }

        public IDbSet<T> EntitySet<T>() where T : class
        {
            return Set<T>();
        }

        public void SetAddState<T>(T entity) where T : class
        {
            Entry(entity).State = EntityState.Added;
        }

        public void SetModifiedState<T>(T entity) where T : class
        {
            try
            {
                Entry(entity).State = EntityState.Modified;
            }
            catch (InvalidOperationException)
            {
                var entry = Entry(entity);
                var key = GetPrimaryKey(entry);

                if (entry.State != EntityState.Detached) return;
                var currentEntry = EntitySet<T>().Find(key);

                if (currentEntry != null)
                {
                    var attachedEntry = Entry(currentEntry);
                    attachedEntry.CurrentValues.SetValues(entity);
                }
                else
                {
                    EntitySet<T>().Attach(entity);
                    entry.State = EntityState.Modified;
                }
            }
        }

        public void SetDeletedModified<T>(T entity) where T : class
        {
            Entry(entity).State = EntityState.Deleted;
            ChangeTracker.DetectChanges();
        }

        

        
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<News> News { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);
            //this method prevents table names from being pluralized
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }

        private Guid GetPrimaryKey(System.Data.Entity.Infrastructure.DbEntityEntry entry)
        {
            var myObject = entry.Entity;
            var property = myObject.GetType().GetProperties()
                .FirstOrDefault(prop => Attribute.IsDefined(prop, typeof(System.ComponentModel.DataAnnotations.KeyAttribute)));
            return (Guid)property.GetValue(myObject, null);
        }
    }
}
