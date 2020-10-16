using AutoMapper;
using Domain.Common;
using Microsoft.Extensions.Logging;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Base
{
    public class CommonService<T, Dto> : ICommonService<T, Dto> where T : class, IAuditableEntity, IEntity
    {
        protected IMapper _mapper;

        private IGenericRepository<T> _genericRepository;

        protected IUnitOfWork _unitOfWork;
        public CommonService(IMapper mapper,IGenericRepository<T> genericRepository, IUnitOfWork unitOfWork )
        {
            this._mapper = mapper;
            this._genericRepository = genericRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<List<T>> GetAllAsync()
        {
            var items= await this._genericRepository.All();

            return items.ToList();
        }

        public async Task<OperationResult> ChangeStateAsync(int id, string state)
        {
            var results = await this._genericRepository.Find(s => s.Id == id);

            var item = results.FirstOrDefault();

            if (item!= null)
            {
                return new OperationResult()
                {
                    OpeationSuccess = false,
                    Message = "El identificador suministrado no corresponde con ningun registro"
                };
            }
            else
            {
                item.Status= state;
                await  this._genericRepository.Update(item);

                return await _unitOfWork.CommitChanges();
            }
        }

        public async Task<OperationResult> CreateOneAsync(Dto Item)
        {
            var entity = _mapper.Map<T>(Item);

             await this._genericRepository.Update(entity);

            return await _unitOfWork.CommitChanges();
        }

        public async Task<Dto> FindByIdAsync(int Id)
        {
            var results = await this._genericRepository.Find(s => s.Id == Id);

            var item = results.FirstOrDefault();


            return _mapper.Map<Dto>(item);
        }

        public async Task<OperationResult> UpdateAsync(Dto item)
        {
            var entity = _mapper.Map<T>(item);

             await this._genericRepository.Update(entity);

            return await _unitOfWork.CommitChanges();
        }
    }
}
