using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAppAsService1
{
    public class DateService : IDateService
    {
        public string GetCurrentDate() => DateTime.Now.ToLongDateString();
    }
}
