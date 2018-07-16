using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CBA.AP.Blog.Requests
{
    public class GetPostsRequest : IValidatableObject
    {
        [Range(1, 10, ErrorMessage = "Count must be from 1 to 10")]
        public int Count { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Page must be positive")]
        public int Page { get; set; }

        /// <summary>
        /// For more complex validation
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
//            var results = new List<ValidationResult>();
//            if (somethingShity)
//            {
//                results.Add(new ValidationResult("This is wrong."));
//            }
//            
//            results.Add(new ValidationResult("Something else is wrong"));
//
//            return results;

//            if (somethingShitty)
//            {
//                yield return new ValidationResult("This is wrong.");
//            }
//            
//            yield return new ValidationResult("Something else is wrong");
              return Enumerable.Empty<ValidationResult>();
        }
    }
}