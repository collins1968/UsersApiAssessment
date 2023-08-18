using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersAssessment.Models
{
    public class CommentsDTO
    {
        public int id { get; set; } 
        public int postId { get; set; } = 0;
        public string name { get; set; } = string.Empty;

        public string email { get; set; } = string.Empty;
        public string body { get; set; } = string.Empty;
    }
}
