using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CRUD.Blog.Models
{
    [Table("Blog")]
    public class Blog
    {
        [Column("Id")]
        [Display(Name="ایدی خبر")]
        public int Id { get; set; }

        [Column("Title")]
        [Display(Name="موضوع خبر")]
        public string? Title { get; set; }

        [Column("ShoetDes")]
        [Display(Name="توضیح کوتاه خبر")]
        public string? ShoetDes { get; set; }

        [Column("Des")]
        [Display(Name="توضیح  خبر")]
        public string? Des { get; set; }


    }
}