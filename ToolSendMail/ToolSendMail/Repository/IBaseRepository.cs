using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolSendMail.Models;

namespace ToolSendMail.Repository
{
    public interface IBaseRepository<T>
    {
        Task<BaseEntity> CreateEntityAsync(BaseEntity baseEntity);
        Task<List<T>> GetAllEntityAsync();
        Task<List<T>> GetAllEntityByKeyAsync(string key);
        Task<T> GetEntityByIdAsync(int id);
        Task<bool> UpdateEntityAsync(int id, BaseEntity baseEntity);
        Task<bool> DeleteEntityById(int id);
    }
}
