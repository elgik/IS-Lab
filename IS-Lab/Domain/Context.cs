using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace IS_Lab.Domain
{
    /// <summary>
    /// Контекст для работы с базой данных
    /// </summary>
    public class Context : DbContext
    {
        public Context() : base("IS-Lab") { }
        /// <summary>
        /// Пользователи
        /// </summary>
        public DbSet<User> Users { get; set; }    
    }
}
