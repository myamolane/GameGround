using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class MaxLengthException : LocalizedException
    {
        private readonly int _length;
        private readonly string _fieldName;

        public MaxLengthException(string fieldName, int length = 50)
            : base("MaxLength")
        {
            this._fieldName = fieldName;
            this._length = length;
        }

        public override string GetErrorMessage()
        {
            var format = base.GetErrorMessage();
            var fieldName = LocalizedProvider.GetString(this._fieldName);
            return string.Format(format, fieldName, this._length);
        }
    }

    public class DuplicateDataException : LocalizedFormatException
    {
        public DuplicateDataException(string itemName)
            : base(itemName, "DuplicateData")
        {

        }
    }

    public class InvalidFileException : LocalizedFormatException
    {
        public InvalidFileException(string extensionName)
            : base(extensionName, "InvalidFile")
        {

        }
    }

    public class DataNotFoundException : LocalizedFormatException
    {
        public DataNotFoundException(string entityName)
            : base(entityName, "DataNotFound")
        {

        }
    }

    public class DataRemovedException : LocalizedFormatException
    {
        public DataRemovedException(string entityName)
            : base(entityName, "DataRemoved")
        {

        }
    }

    public class FailedToInsertException : LocalizedFormatException
    {
        public FailedToInsertException(string entityName)
            : base(entityName, "FailedToInsert")
        {

        }

    }

    public class FailedToUpdateException : LocalizedFormatException
    {
        public FailedToUpdateException(string entityName)
            : base(entityName, "FailedToUpdate")
        {

        }
    }

    public class FailedToDeleteException : LocalizedFormatException
    {
        public FailedToDeleteException(string entityName)
            : base(entityName, "FailedToDelete")
        {

        }
    }
}
