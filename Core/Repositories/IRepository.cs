using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {

        /// <summary>
        /// Tüm veriyi getir.
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Veriyi Where metodu ile getir.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Verilen sorguya göre tablodaki sayıyı gönderir.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        int Count();
        /// <summary>
        /// Verilen sorguya göre tablodaki sayıyı gönderir.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        int Count(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// İstenilen veriyi single olarak getirir.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        TEntity Get(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Getirilen veri üzerinde veri gelmeden kolonları seç.
        /// </summary>
        /// <param name="where">Veri kısıtlamaları</param>
        /// <param name="select">Seçilecek kolonlar</param>
        /// <returns></returns>
        IQueryable<dynamic> SelectList(Expression<Func<TEntity, bool>> @where, Expression<Func<TEntity, dynamic>> @select);

        /// <summary>
        /// Entity ile sql sorgusu göndermek için kullanılır.
        /// </summary>
        /// <param name="sqlQuery">Gönderilecek sql</param>
        /// <returns></returns>
        //List<TEntity> SendSql(string sqlQuery);

        /// <summary>
        /// Verilen entityi ekle.
        /// </summary>
        /// <param name="entity"></param>
        void Add(TEntity entity);

        /// <summary>
        /// Verilen entityi ekle.
        /// </summary>
        /// <param name="entity"></param>
        void AddRange(List<TEntity> entity);

        /// <summary>
        /// Verilen entityi ekle.
        /// </summary>
        /// <param name="entityList"></param>
        void BulkInsert(List<TEntity> entityList);

        /// <summary>
        /// Verilen entity i güncelle.
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);

        /// <summary>
        /// Verilen entityi sil.
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity, bool forceDelete = false);

        /// <summary>
        /// predicate göre veriler silinir.
        /// </summary>
        /// <param name="predicate"></param>
        void Delete(Expression<Func<TEntity, bool>> predicate, bool forceDelete = false);


        /// <summary>
        /// Aynı kayıt eklememek için objeyi kontrol ederek true veya false dönderir.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        bool Any(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// DbContext i verir.
        /// </summary> 
        /// <returns></returns>
        DbContext GetDbContext();
    }

}

