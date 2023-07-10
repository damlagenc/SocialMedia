using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SocialMedia.Migrations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SocialMedia.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Required(ErrorMessage = "Text is required.")]
        [MaxLength(250, ErrorMessage = "Text can be max 250 characters.")]
        public string Text { get; set; }

        public DateTime CreatedAt { get; set; }
        public Post()
        {
            CreatedAt = DateTime.Now;
        }

        public class PostViewModel{
            public Post Post{ get; set; }
            public IList<Post>Posts { get; set; }
        }
    }

}