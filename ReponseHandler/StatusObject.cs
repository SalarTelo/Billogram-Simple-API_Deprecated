using System;
namespace Billogram.Handle
{
    public class StatusObject
    {
        public ResponseCode m_response;

        public static implicit operator StatusObject(string handle)
        {
            return handle == null ? null : new StatusObject(handle);
        }
        public static implicit operator ResponseCode(StatusObject returnHandle) 
        {
            return returnHandle.m_response;
        }
        public static implicit operator bool(StatusObject returnHandle)
        {
            return returnHandle.m_response == ResponseCode.OK;
        }
        public StatusObject(string status)
        {
            if (!Enum.TryParse<ResponseCode>(status, out m_response))
            {
                m_response = ResponseCode.ERROR_INVALID_OR_UNKNOWN_RESPONSE_CODE;
            }
        }
    }
}
