using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chinook_client.Models
{
    public class CustomerGenre
    {
        /// <summary>
        /// Property(Genres): List that contains a customers favorite genre(s).
        /// </summary>
        public List<string> Genres { get; set; }

        public CustomerGenre()
        {
            this.Genres = new List<string>();
        }

    }
}
