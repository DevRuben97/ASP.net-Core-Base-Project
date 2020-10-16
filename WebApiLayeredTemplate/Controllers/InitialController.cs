using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Helpers;
using Domain.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;

namespace API.Controllers
{
    [Route(ApiRoutes.CONTROLLER)]
    [ApiController]
    public class InitialController<T, Dto>: ControllerBase where T: class, IAuditableEntity, IEntity
    {
       protected ICommonService<T, Dto> _commonService;

        protected ILogger<T> _logger;

        protected string _ControllerName;
        public InitialController(ICommonService<T, Dto> service, ILogger<T> logger)
        {
            this._commonService = service;
            this._logger = logger;
        }
        [HttpGet]
        public virtual async Task<IActionResult> All()
        {
            try
            {
                var items =await  _commonService.GetAllAsync();
                _logger.LogInformation($"Se ha obtenido una lista de registros de tipo {this._ControllerName}");
                return Ok(new RequestResult(true, items));
            }
            catch(Exception ex)
            {
                _logger.LogWarning(ex.Message, ex.Data);
                return Ok(new RequestResult(false, null));
            }
        }

        [HttpGet]
        [Route(ApiRoutes.FindOne)]
        public virtual async Task<IActionResult> ById(int Id)
        {
            try
            {
                var item = await _commonService.FindByIdAsync(Id);
                _logger.LogInformation($"Se ha obtenido un registro de tipo {this._ControllerName} con el id {Id}");
                return Ok(new RequestResult(true, item));
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, ex.Data);
                return Ok(new RequestResult(false, null));
            }
        }
        [HttpPost]
        public virtual async Task<IActionResult> New(Dto item)
        {
            try
            {
             var result=  await  this._commonService.CreateOneAsync(item);
                _logger.LogInformation($"Se ha creado un  registro de tipo {this._ControllerName}");
                return Ok(new RequestResult(result.OpeationSuccess, null));
            }
            catch(Exception ex)
            {
                _logger.LogWarning(ex.Message, ex.Data);
                return Ok(new RequestResult(false, null));
            }
        }

        [HttpPut]
        public virtual async Task<IActionResult> Update(Dto item)
        {
            try
            {
                var result = await this._commonService.CreateOneAsync(item);
                _logger.LogInformation($"Se ha actualizado un  registro de tipo {this._ControllerName}");
                return Ok(new RequestResult(result.OpeationSuccess, null));
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message, ex.Data);
                return Ok(new RequestResult(false, null));
            }
        }
    }
}
