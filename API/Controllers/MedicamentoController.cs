using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using API.Helpers;

using Domain.Interface;
using Domain.Entities;

namespace API.Controllers;
public class MedicamentoController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    public MedicamentoController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<Medicamento>>> Get11([FromQuery] Params productParams)
    {
        var products = await _unitOfWork.Medicamentos.paginacion(productParams.PageIndex, productParams.PageSize, productParams.Search);
        return new Pager<Medicamento>(products.registros.ToList(), products.totalRegistros, productParams.PageIndex, productParams.PageSize, productParams.Search);
    }
}
