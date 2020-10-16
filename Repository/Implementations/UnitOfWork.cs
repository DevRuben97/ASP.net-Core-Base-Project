using Domain.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Persistence;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public  class  UnitOfWork : IUnitOfWork
    {
        private  AppDbContext dbContext { get; set; }

        private ILogger<UnitOfWork> logger { get; set; }

        public UnitOfWork(AppDbContext dbContext, ILogger<UnitOfWork> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }

        public async Task<OperationResult> CommitChanges()
        {
            try
            {
                var result = await dbContext.SaveChangesAsync();

                return new OperationResult()
                {
                    OpeationSuccess = true,
                    Message = "Cambios guardados correctamente",
                    Data = new
                    {
                        totalRecords = result
                    }
                };
            }
            catch(Exception ex)
            {
                this.logger.LogWarning(ex.Message, ex.Data);
                return new OperationResult()
                {
                    Message = "Los cambios no pudieron ser guaedados",
                    OpeationSuccess = false,
                    Data = ex.Data
                };
            }
        }

        public void Dispose()
        {
            this.dbContext.Dispose();
        }
    }
}
