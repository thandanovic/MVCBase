using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBase.Common
{
    public class ClientException : Exception
    {
        public ClientException( string message, int errorCode = 0) : base(message)
        {
            ErrorCode = errorCode;
        }

        public int ErrorCode { get; set; }
    }
}
