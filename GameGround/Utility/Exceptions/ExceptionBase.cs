using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public interface ILocalizedProvider
    {
        string GetString(string key);
    }

    public abstract class LocalizedExceptionBase : Exception
    {
        public static ILocalizedProvider LocalizedProvider { get; set; }

        public string Format { get; set; }

        public virtual string GetErrorMessage()
        {

            if (LocalizedProvider == null) throw new ArgumentException("LocalizedProvider");
            return LocalizedProvider.GetString(this.Format);
        }

        public override string Message
        {
            get { return this.GetErrorMessage(); }
        }
    }

    public class LocalizedException : LocalizedExceptionBase
    {
        public LocalizedException(string format)
        {
            this.Format = format;
        }
    }

    public class LocalizedFormatException : LocalizedException
    {
        public string Parameter { get; private set; }
        public LocalizedFormatException(string parameter, string formatStr)
            : base(formatStr)
        {
            this.Parameter = parameter;
        }

        public override string GetErrorMessage()
        {
            var format = base.GetErrorMessage();
            var entityName = LocalizedProvider.GetString(this.Parameter);
            return string.Format(format, entityName);
        }
    }
}
