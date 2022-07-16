using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolSendMail.Data;

namespace ToolSendMail.Repository
{
    public class UserRepository : BaseRepository, IBaseRepository
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
