using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_Lab.Domain
{
    /// <summary>
    /// Описание модели пользователя
    /// </summary>
    public partial class User
    {
        /// <summary>
        /// Id пользователя
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Логин пользователя
        /// </summary>
        [Required]
        public string Login { get; set; }
        /// <summary>
        /// Хеш-пароль пользователя
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Признак блокировки
        /// </summary>
        [NotMapped]
        private bool isBlocked;
        public bool IsBlocked
        {
            get { return isBlocked || TryCount == 3; }
            set { isBlocked = value; }
        }
        /// <summary>
        /// Необходимость использования символов в пароле
        /// </summary>
        public bool IsSymbols { get; set; }
        /// <summary>
        ///  Необходимость использования цифр в пароле
        /// </summary>
        public bool IsDigits { get; set; }
        /// <summary>
        /// Необходимость использования заглавных букв в пароле
        /// </summary>
        public bool IsUpperCase { get; set; }
        /// <summary>
        /// Необходимость использования прописных букв в пароле
        /// </summary>
        public bool IsLowerCase { get; set; }
        /// <summary>
        /// Ограничение на длину
        /// </summary>
        public bool IsLength { get; set; }
        /// <summary>
        /// Признак наличия ограничений на пароль
        /// </summary>                
        [NotMapped]
        public bool IsRestricted => (IsUpperCase || IsLowerCase || IsDigits || IsSymbols);
        /// <summary>
        /// Признак "Администратора" жёстко привязан к логину (в системе всего один админ)
        /// </summary>
        [NotMapped]
        public bool IsAdmin => Login == "Admin";
        /// <summary>
        /// Необходима смена пароля
        /// </summary>        
        public bool IsNeedChangePassword { get; set; }
        /// <summary>
        /// Количество попыток ввода пароля
        /// </summary>
        public int TryCount { get; set; }
    }
}
