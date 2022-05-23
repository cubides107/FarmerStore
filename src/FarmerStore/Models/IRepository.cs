using System.Linq.Expressions;

namespace FarmerStore.Models
{
    public interface IRepository
    {
        /// <summary>
        /// Guarda un entidad
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Task Save<T>(T obj) where T : Entity;

        /// <summary>
        /// Actualiza un entidad
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        public void Update<T>(T obj) where T : Entity;

        /// <summary>
        /// Verificar si existe
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public bool Exists<T>(Expression<Func<T, bool>> expression) where T : Entity;

        /// <summary>
        /// Guarda los datos en la db
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public Task Commit();

        /// <summary>
        /// Obtiene una entidad mediante una condicion
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public Task<T> Get<T>(Expression<Func<T, bool>> expression) where T : Entity;
    }
}
