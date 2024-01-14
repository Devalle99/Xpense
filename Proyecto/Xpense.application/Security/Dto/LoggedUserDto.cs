using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xpense.application.Security.Dto
{
    public class LoggedUserDto
    {
        public UserDto User { get; set; }

        public string AccessToken { get; set; }
    }
}
