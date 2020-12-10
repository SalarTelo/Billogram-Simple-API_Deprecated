using System.Collections.Generic;
using System.Linq;
using System.Text;
using Billogram.Structures;
namespace Billogram.Handle
{
    public class SafetyHandle<T> where T : class, IStructure
    {
        public T Content { get { return m_responseBody; } }
        public string ResponseMessage 
        { 
            get 
            { 
                return "test"; 
            } 
        }

        protected T m_responseBody;
        protected StatusObject statusHandle;
        
        public SafetyHandle(T handle)
        {
            m_responseBody = handle;
            statusHandle = handle.status;
        }

        public static implicit operator SafetyHandle<T>(T handle)
        {
            return handle == null ? null : new SafetyHandle<T>(handle);
        }

        public static implicit operator T(SafetyHandle<T> returnHandle) 
        {
            return returnHandle.m_responseBody;
        }

    }

    
}
