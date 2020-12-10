using System.Collections.Generic;
using System.Linq;
using System.Text;
using Billogram.Structures;
namespace Billogram.Handles
{
    public class ResponseHandle<T> where T : class, IStructure
    {
        public T Content { get { return m_responseBody; } }
        protected T m_responseBody;
        protected StatusObject statusHandle;

        public ResponseHandle(T handle)
        {
            m_responseBody = handle;
            statusHandle = handle.status;
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

    
}
