using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolSendMail.Models;

namespace ToolSendMail.Repository
{
    public interface IBaseRepository
    {
        Task<BaseEntity> CreateEntityAsync(BaseEntity baseEntity);
        Task<List<BaseEntity>> GetAllEntityAsync();
        Task<List<BaseEntity>> GetAllEntityByKeyAsync(string key);
        Task<BaseEntity> GetEntityByIdAsync(int id);
        Task<bool> UpdateEntityAsync(int id, BaseEntity baseEntity);
        Task<bool> DeleteEntity(int id);
    }
}
