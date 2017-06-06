using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class AccessDeniedException : LocalizedException
    {
        public AccessDeniedException()
            : base("AccessDenied")
        {

        }
    }

    public class InvalidRequestException : LocalizedException
    {
        public InvalidRequestException()
            : base("InvalidRequest")
        {

        }
    }

    public class SensitiveWordsException : LocalizedException
    {
        private readonly string _words;
        public SensitiveWordsException(string words)
            : base("IncludeSensitiveWords")
        {
            this._words = words;
        }

        public override string GetErrorMessage()
        {
            var format = base.GetErrorMessage();
            return string.Format(format, _words);
        }
    }
}
