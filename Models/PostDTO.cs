using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersAssessment.Models
{
    public class PostDTO
    {
       public int userId { get; set; } = 0;

       public int id { get; set; } = 0;

      public string title { get; set; } = string.Empty;
      public string body { get; set; } = string.Empty;
    }
}
