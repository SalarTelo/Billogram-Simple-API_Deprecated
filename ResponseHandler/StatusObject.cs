using System;
namespace Billogram.Handle
{
    public class StatusObject
    {
        /// <summary>
        /// Enum with specific response code from server.
        /// </summary>
        public readonly ResponseCode Response;

        public static implicit operator StatusObject(string handle)
        {
            return handle == null ? null : new StatusObject(handle);
        }
        public static implicit operator ResponseCode(StatusObject status)
        {
            return status.Response;
        }
        public static implicit operator bool(StatusObject status)
        {
            return status.Response == ResponseCode.OK;
        }

        public StatusObject(string status)
        {
            if (!Enum.TryParse<ResponseCode>(status, out Response))
            {
                Response = ResponseCode.ERROR_INVALID_OR_UNKNOWN_RESPONSE_CODE;
            }
        }
    }
}
