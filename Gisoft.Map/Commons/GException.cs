using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Gisoft.Map
{
    public class GException : Exception
    {

        public GException(string message) : base(message)
        {
        }

        public GException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected GException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        public GException(string code,string description):base()
        {
            _errorCode = code;
            _description = description;
        }
        protected string _errorCode = "";
        public string ErrorCode
        {
            get => _errorCode;
        }

        protected string _description = "";
        public string Description
        {
            get => _description;
        }
    }
}
