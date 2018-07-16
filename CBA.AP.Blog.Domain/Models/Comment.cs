using System;

namespace CBA.AP.Blog.Domain.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Commenter { get; set; }

        public DateTime Created { get; set; }

        public string Content { get; set; }
    }
}