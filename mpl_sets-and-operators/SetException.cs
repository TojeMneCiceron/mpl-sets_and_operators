using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syap1
{
    class SetExceptionOutOfRange: Exception
    {
        private string message = "Выход за пределы множества.";
        public override string Message
        {
            get { return message; }
        }
    }
    class SetExceptionDelete: Exception
    {
        private string message = "Элемента и так не было.";
        public override string Message
        {
            get { return message; }
        }
    }
}
