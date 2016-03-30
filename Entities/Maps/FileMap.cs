using System.Data.Entity.ModelConfiguration;
using Entities.Models;


namespace Entities.Maps
{
    public class FileMap: EntityTypeConfiguration<File>
    {
        #region  Constructors & Destructor
        public FileMap()
        {
            MapToStoredProcedures(s => s.Insert(i => i.HasName("InsertFile").Parameter(f => f.Name, "Name")));
        }
        #endregion
    }
}