using System.Collections.Generic;
using System.Linq;
using System.Text;
using Billogram.Structures;
namespace Billogram.Handle
{
    /// <summary>
    /// A substitute to any structure to handle any errors or response. 
    /// </summary>
    /// <typeparam name="T">Any structure that derives from IStructure interface</typeparam>
    public class SafetyHandle<T> where T : class, IStructure
    {
        /// <summary>
        /// The content of the structure retrieved from server.
        /// </summary>
        public T Content { get { return m_responseBody; } }

        /// <summary>
        /// The response object that handles the response-code from the request.
        /// </summary>
        public StatusObject Status { get { return statusHandle; } }

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
