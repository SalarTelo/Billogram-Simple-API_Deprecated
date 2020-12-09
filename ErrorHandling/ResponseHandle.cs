using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Billogram.ResponseHandling
{
    public sealed class ResponseHandle<T> where T : class, Structures.IStructure, IRespondable
    {
        public T Content { get { return m_responseBody; } }

        private ResponseCode m_responseCode;
        private T m_responseBody;
        public ResponseHandle(T handle)
        {
            m_responseBody = handle;
        }

        public static implicit operator ResponseHandle<T>(T handle)
        {
            return handle == null ? null : new ResponseHandle<T>(handle);
        }

        public static implicit operator T(ResponseHandle<T> returnHandle) 
        {
            return returnHandle.m_responseBody;
        }

    }
    public enum ResponseCode
    {
        OK = 200,
        MISSING_AUTH = 401,
        INVALID_AUTH = 403,
        PERMISSION_DENIED = 403,
        NOT_FOUND = 404,
        NOT_AVAILABLE_YET = 404,
        METHOD_NOT_ALLOWED = 405,
        MISSING_QUERY_PARAMETER = 400,
        INVALID_PARAMETER = 400,
        INVALID_PARAMETER_COMBINATION = 400,
        READ_ONLY_PARAMETER = 400,
        UNKNOWN_PARAMETER = 400,
        INVALID_OBJECT_STATE = 400,
        INVALID_CODE = 000
    }
}
