using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CBA.AP.Blog.Requests
{
    public class CreatePostRequest
    {
        [Required(ErrorMessage = "Title must not be empty")]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "Content must not be empty")]
        public string Content { get; set; }
    }
}