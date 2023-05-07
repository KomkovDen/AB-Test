using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace WebAPI.Models
{   
    //Класс для идентификации, хранения информации о значении(результата) и 
    // типе эксперимента.
    [DataContract]
    public class Experiment
    {
        #region Properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DeviceToken { get; set; }
        [DataMember]
        public string Value { get; set; }   
        [DataMember]
        public string ColorGroup { get; set; }
        #endregion
    }
}
