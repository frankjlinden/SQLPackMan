using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static SqlPackMan.Models.Enums;

namespace SqlPackMan.Models
{
    public class DbObject 
    {
        public int Id { get; set; }
        [StringLength(150)]
        public string ObjectName { get; set; }

        [StringLength(1024)]
        public string TagString { get; set; }

        public int PackageId { get; set; }

        //incremented when status is changed from Development to Admin Review
        //item is synced to scripts folder
        public int Version { get; set; }

        private int _statusId { get; set; }
        private int _dbObjectTypeId;

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DisplayName("Status Date")]
        public DateTime StatusDate { get; set; }

      

        [NotMapped]
        public HashSet<string> Tags {
            get => new HashSet<string>(TagString.Split(','));
            set => TagString = string.Join(",",value.ToArray()); }
        
        //nav props
        public Status Status {
            get => (Status)_statusId;
            set => _statusId = (int)value;
        }

        public Package Package { get; set; }

        public DbObjectType DbObjectType
        {
            get => (DbObjectType)_dbObjectTypeId;
            set => _dbObjectTypeId = (int)value;
        }

    }
}
