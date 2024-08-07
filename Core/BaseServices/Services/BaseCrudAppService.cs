using ApplicationShared.Mapper;
using Core.BaseDtos;
using Core.BaseEntities;
using Core.BaseServices.Interfaces;
using Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.BaseServices.Services
{
    public class BaseCrudAppService<TDbContext, TEntity, TEntityDto, TCreateInput, TUpdateInput> :
        IBaseCrudAppService<TEntity, TEntityDto, TCreateInput, TUpdateInput>
        where TDbContext : DbContext
        where TEntity : BaseEntity
        where TEntityDto : BaseDto
        where TCreateInput : class
        where TUpdateInput : class

    {
        public virtual async Task<int> DeleteAsync(Guid guid) 
            /*
             * REPODAKİ ÜSTTE KALAN DELETE'İ KULLANIYOR ONDAN DOLAYI BİR ÖNCEKİ KATMANDA GET İLE ÇEKTİKTEN SONRA BU METODA ONUN MODELİNİ PARAMETRE VERİYORUZ
             * 
             * bir user dto su olucak userinput dto . bunları da bir base nesneden kalıtıcam bütün inputlar da bu base nesneden türet. sonra mapper da bir profile oluştur bu input nesnesinden base inputa 
             * bu şekilde de
             */
        {
            using (var uow = new UnitOfWork<TDbContext>())
            {

                var isExist = uow.GetRepository<TEntity>().Get(x => x.Guid == guid);
                if (isExist == null)
                    return 0; // Silinmesi istenilen veri yoksa
                //ResponseModel eklendiğinde burada ResponseModel tipinde bir durum mesajı döndürülecek

                uow.GetRepository<TEntity>().Delete(isExist);
                if (uow.SaveChanges() < 0)
                    return -1; // Kullanıcı var ama silme işlemi gerçekleşmedi
                return 1; // Silme işlemi gerçekleşti

            }
        }

        public virtual Task<TEntity> GetAsync(Guid guid)
        {
            using (var uow = new UnitOfWork<TDbContext>())
            {
                var isExist = uow.GetRepository<TEntity>().Get(x => x.Guid == guid);
                if (isExist == null)
                    return Task.FromResult<TEntity>(isExist);
                return Task.FromResult(isExist);
            }
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            using (var uow = new UnitOfWork<TDbContext>())
            {
                return  uow.GetRepository<TEntity>().GetAll();
            }
        }

        public virtual async Task<int> InsertAsync(TEntity tEntity)
        {
            using (var uow = new UnitOfWork<TDbContext>())
            {
                uow.GetRepository<TEntity>().Add(tEntity);
                return uow.SaveChanges();

            }
        }




        public virtual async Task<int> UpdateAsync(TEntity updateInput)
        {
            using (var uow = new UnitOfWork<TDbContext>())
            {
                uow.GetRepository<TEntity>().Update(updateInput);
                return uow.SaveChanges();

            }
        }
    }
}
