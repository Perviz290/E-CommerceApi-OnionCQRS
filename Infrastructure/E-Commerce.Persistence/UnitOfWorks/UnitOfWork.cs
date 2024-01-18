using E_Commerce.Application.Interfaces.Repositories;
using E_Commerce.Application.Interfaces.UnitOfWorks;
using E_Commerce.Domain.Entities;
using E_Commerce.Persistence.Context;
using E_Commerce.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext dbContext;
        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async ValueTask DisposeAsync()=>await dbContext.DisposeAsync();
        

        public int Save()=>dbContext.SaveChanges();
       

        public Task<int> SaveAsync()=>dbContext.SaveChangesAsync();


        IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(dbContext);
     

        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>()=> new WriteRepository<T>(dbContext);   
       
    }
}
