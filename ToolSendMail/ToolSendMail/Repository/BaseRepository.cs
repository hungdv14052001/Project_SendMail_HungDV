using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolSendMail.Data;
using ToolSendMail.Models;

namespace ToolSendMail.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        private readonly EntityContext _ctx;
        private DbSet<T> Model { get; set; }
        /// <summary>
        /// Initialization Base Repository
        /// </summary>
        /// <param name="ctx"></param>
        public BaseRepository(EntityContext ctx)
        {
            this._ctx = ctx;
            Model = ctx.Set<T>();
        }

        /// <summary>
        /// get all entity in DataBase
        /// </summary>
        /// <returns>List<BaseEntity></returns>
        public async Task<List<T>> GetAllEntityAsync()
        {
            List<T> entities = new List<T>();
            foreach (T entity in await Model.ToListAsync())
            {
                entities.Add(entity);
            }
            return entities;
        }

        public async Task<List<T>> GetAllEntityByKeyAsync(string key)
        {
            List<T> entities = new List<T>();
            foreach (T entity in await Model.ToListAsync())
            {
                entities.Add(entity);
            }
            return entities;
        }

        /// <summary>
        /// Get Entity By Id in Data Base
        /// </summary>
        /// <param name="id"></param>
        /// <returns>BaseEntity</returns>
        public async Task<T> GetEntityByIdAsync(int id)
        {
            T entity;
            try
            {
                entity = await Model.FindAsync(id);
            }
            catch
            {
                entity = null;
            }
            if (entity == null)
            {
                return new T();
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
            T entity = baseEntity as T;
            Model.Add(entity);
            SaveChange();
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
        public async Task<bool> DeleteEntityById(int id)
        {
            bool result = false;
            if (EntityExist(id))
            {
                T entity = await GetEntityByIdAsync(id);
                try
                {
                    Model.Remove(entity);
                    SaveChange();
                    result = true;
                }
                catch
                {
                    result = false;
                }
            }
            return result;
        }

        /// <summary>
        /// save action
        /// </summary>
        public void SaveChange()
        {
            _ctx.SaveChanges();
        }

        /// <summary>
        /// Check Blog exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns>bool</returns>
        public bool EntityExist(int id)
        {
            return _ctx.Users.Any(e => e.Id == id);
        }
    }
}
