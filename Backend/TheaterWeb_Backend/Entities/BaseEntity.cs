using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheaterWeb.Entities {
    public class BaseEntity {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //dòng trên có nghĩa là id sẽ được tạo ra tự động bởi csdl
        public int Id { get; set; }
    }
}
