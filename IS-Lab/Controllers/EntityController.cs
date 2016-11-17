using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using IS_Lab.Domain;

namespace IS_Lab.Controllers
{
    public static class EntityController
    {
        /// <summary>
        /// Загрузка по логину. Логин в системе уникален
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public static User LoadByLogin(string login)
        {
            Context db = new Context();
            return db.Users.SingleOrDefault(u => u.Login == login);
        }
        /// <summary>
        /// Загрузка по ключу (Id)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static User Load(int id)
        {
            Context db = new Context();
            return db.Users.Find(id);
        }
        /// <summary>
        /// Добавление пользователя в бд
        /// </summary>
        /// <param name="entity"></param>
        public static void Add(User entity)
        {
            Context db = new Context();            
            db.Users.Add(entity);
            db.Entry(entity).State = EntityState.Added;
            db.SaveChanges();            
        }
        /// <summary>
        /// Обновление пользователя
        /// </summary>
        /// <param name="entity"></param>
        public static void UpdateUser(User entity)
        {
            Context db = new Context();
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();            
        }
        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="entity"></param>
        public static void Delete(User entity)
        {
            Context db = new Context();                        
            db.Users.Remove(entity);
            db.Entry(entity).State = EntityState.Deleted;
            db.SaveChanges();                        
        }
        /// <summary>
        /// Получение списка всех пользователей
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<User> GetAllUsers()
        {
            Context db = new Context();            
            return db.Users.ToList();
        }
    }
}
