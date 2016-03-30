using System.Data.Entity;
using Entities.Maps;
using Entities.Models;


namespace Entities.Contexts
{
    public class EntityContext: DbContext
    {
        #region  Constructors & Destructor
        public EntityContext(): base("name=EntityContext") { }
        #endregion


        #region  Properties & Indexers
        public DbSet<File> Files { get; set; }
        #endregion


        #region Override
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new FileMap());
        }
        #endregion
    }
}