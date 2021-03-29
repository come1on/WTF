using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTF_WIKI_TRANS_FUN
{
    class NoLanguageException : Exception
    {
        public NoLanguageException(string message) : base(message)
        {

        }
    }
}
