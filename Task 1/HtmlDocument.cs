using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class HtmlDocument : TextDocument
    {
        public override string Extension
        {
            get
            {
                return ".html";
            }
        }
    }
}
