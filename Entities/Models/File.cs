using System;


namespace Entities.Models
{
    public class File
    {
        #region  Properties & Indexers
        public DateTime? CreatedOn { get; set; }
        public int? Id { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string Name { get; set; }
        #endregion
    }
}