using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolSendMail.Data;
using ToolSendMail.Models;

namespace ToolSendMail.Repository
{
    public abstract class BaseRepository
    {
        private readonly EntityContext _ctx;

        /// <summary>
        /// Initialization Base Repository
        /// </summary>
        /// <param name="ctx"></param>
        public BaseRepository(EntityContext ctx)
        {
            this._ctx = ctx;
        }

        /// <summary>
        /// get all entity in DataBase
        /// </summary>
        /// <returns>List<BaseEntity></returns>
        public async Task<List<BaseEntity>> GetAllEntityAsync()
        {
            string type = this.GetType().Name;
            List<BaseEntity> baseEntities = new List<BaseEntity>();
            if (type.Equals("UserRepository"))
            {
                foreach (var blog in await _ctx.Users.ToListAsync())
                {
                    baseEntities.Add(blog);
                }
            }
            return baseEntities;
        }

        public async Task<List<BaseEntity>> GetAllEntityByKeyAsync(string key)
        {
            string type = this.GetType().Name;
            List<BaseEntity> baseEntities = new List<BaseEntity>();
            if (type.Equals("UserRepository"))
            {
                foreach (var blog in await _ctx.Users.ToListAsync())
                {
                    baseEntities.Add(blog);
                }
            }
            return baseEntities;
        }

        /// <summary>
        /// Get Entity By Id in Data Base
        /// </summary>
        /// <param name="id"></param>
        /// <returns>BaseEntity</returns>
        public async Task<BaseEntity> GetEntityByIdAsync(int id)
        {
            BaseEntity entity;
            string type = this.GetType().Name;
            if (type.Equals("UserRepository"))
            {
                entity = await _ctx.Users.FindAsync(id);
            }
            else
            {
                entity = null;
            }
            if (entity == null)
            {
                return new User();
            }
            else
            {
                return entity;
            }
        }

        /// <summary>
        /// Create Entity
        /// </summary>
        /// <param name="baseEntity"></param>
        /// <returns>BaseEntity</returns>
        public async Task<BaseEntity> CreateEntityAsync(BaseEntity baseEntity)
        {
            string type = baseEntity.GetType().Name;
            if (type.Equals("User"))
            {
                _ctx.Users.Add(baseEntity as User);
                await _ctx.SaveChangesAsync();
                User user = _ctx.Users.OrderByDescending(u => u.Id).FirstOrDefault();
                await UpdateEntityAsync(user.Id, user);
            }
            else
            {
                
            }

            return baseEntity;
        }

        /// <summary>
        /// Update Entity in DataBase
        /// </summary>
        /// <param name="id"></param>
        /// <param name="baseEntity"></param>
        /// <returns>bool</returns>
        public async Task<bool> UpdateEntityAsync(int id, BaseEntity baseEntity)
        {
            string type = baseEntity.GetType().Name;
            try
            {
                baseEntity.Id = id;
                _ctx.Entry(baseEntity).State = EntityState.Modified;
                await _ctx.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Delete Entity in DataBase
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public async Task<bool> DeleteEntity(int id)
        {
            bool result = false;
            string type = this.GetType().Name;
            if (type.Equals("UserRepository"))
            {
                if (UserExists(id))
                {
                    User user = await GetEntityByIdAsync(id) as User;
                    try
                    {
                        _ctx.Users.Remove(user);
                        await _ctx.SaveChangesAsync();
                        result = true;
                    }
                    catch
                    {
                        result = false;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Check Blog exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public bool UserExists(int id)
        {
            return _ctx.Users.Any(e => e.Id == id);
        }
    }
}
