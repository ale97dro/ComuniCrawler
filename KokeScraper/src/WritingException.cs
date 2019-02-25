using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KokeScraper.src
{
    class WritingException : Exception
    {
        public WritingException(string message)
            :base(message)
        {

        }
    }
}
