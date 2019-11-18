using System;

namespace WebApplication1
{
    internal class DataClassesDataContext
    {
        public object Låtar { get; internal set; }

        internal void SubmitChanges()
        {
            throw new NotImplementedException();
        }
    }
}