using System.ComponentModel.DataAnnotations.Schema;
namespace CRUD.Blog.Models
{
    [Table("Blog")]
    public class Blog
    {

        public int Id { get; set; }

        public string? Title { get; set; }

        public string? ShoetDes { get; set; }

        public string? Des { get; set; }


    }
}