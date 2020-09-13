
using Microsoft.EntityFrameworkCore;
using Prueba.Domain.DbHelper;
using Prueba.Domain.Entities;
using Prueba.Domain.Generic;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Prueba.Data
{
    public class PruebaDbContext : DbContext
    {
        public PruebaDbContext(DbContextOptions<PruebaDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Añadimos los filtros personalizados para el borrado lógico
            AddMyFilters(ref modelBuilder);
        }

        public virtual DbSet<Product> Products { get; set; }

        public override int SaveChanges()
        {
            MakeAudit();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken)
        {
            MakeAudit();
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            MakeAudit();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void MakeAudit()
        {
            var modifiedEntries = ChangeTracker.Entries().Where(
                
                 x => x.Entity is AuditEntity && ( x.State == EntityState.Added || x.State == EntityState.Modified )
            );

            foreach (var entry in modifiedEntries)
            {
                var entity = entry.Entity as AuditEntity;

                if (entity != null)
                {
                    var date = DateTime.UtcNow;
                    // TODO : Pendiente implementar el usuario para la auditoria.
                    string userId = null;

                    if (entry.State == EntityState.Added)
                    {
                        entity.CreateAt = date;
                        entity.CreateBy = userId;
                    }
                    else if (entity is ISoftDelete && ((ISoftDelete)entity).Delete)
                    {
                        entity.DeleteAt = date;
                        entity.DeleteBy = userId;
                    }

                    Entry(entity).Property(x => x.CreateAt).IsModified = false;
                    Entry(entity).Property(x => x.CreateBy).IsModified = false;

                    entity.UpdateAt = date;
                    entity.UpdateBy = userId;
                }
            }
        }

        private void AddMyFilters(ref ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasQueryFilter(x => !x.Delete);
        }
    }
}
