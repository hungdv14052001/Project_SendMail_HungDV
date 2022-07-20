using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolSendMail.Data;
using ToolSendMail.Models;

namespace ToolSendMail.Repository
{
    public class UserRepository : BaseRepository<User>
    {
        /// <summary>
        /// Initialization User Repository
        /// </summary>
        /// <param name="ctx"></param>
        public UserRepository(EntityContext ctx) : base(ctx)
        {
        }
    }
}
