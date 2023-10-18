using Microsoft.AspNetCore.Mvc;
using API.Dtos;
using API.Helpers;
using Domain.Interface;
using Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;


namespace API.Controllers;
[ApiVersion("1.0")]
[ApiVersion("1.1")]
public class MascotaController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private IMapper _mapper;
    public MascotaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    [MapToApiVersion("1.1")]
    [Authorize(Roles = "Administrador, Empleado")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<MascotaDto>>> Paginacion([FromQuery] Params productParams)
    {
        var products = await _unitOfWork.Mascotas.paginacion(productParams.PageIndex, productParams.PageSize, productParams.Search);
        var mapeo = _mapper.Map<List<MascotaDto>>(products.registros);
        return new Pager<MascotaDto>(mapeo, products.totalRegistros, productParams.PageIndex, productParams.PageSize, productParams.Search);
    }
    [MapToApiVersion("1.0")]
    [HttpGet]
    [Authorize(Roles = "Administrador, Empleado")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MascotaDto>>> GetAll(){
        var datos = await _unitOfWork.Mascotas.GetAll();
        var mapeo = _mapper.Map<List<MascotaDto>>(datos);
        return mapeo;
    }
    [Authorize(Roles = "Administrador")]
    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PostMascotaDto>> Post(PostMascotaDto dato)
    {
        var med = _mapper.Map<Mascota>(dato);
        if (med == null)
        {
            return BadRequest();
        }
        _unitOfWork.Mascotas.Add(med);
        await _unitOfWork.SaveAsync();
        return dato;
    }
    [Authorize(Roles = "Administrador")]
    [HttpDelete("delete/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var dato = await _unitOfWork.Mascotas.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        _unitOfWork.Mascotas.Remove(dato);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
    [Authorize(Roles = "Administrador, Empleado")]
    [HttpGet("Obtener/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MascotaDto>> GetById(int id)
    {
        var dato = await _unitOfWork.Mascotas.GetById(id);
        if (dato == null)
        {
            return BadRequest();
        }
        return _mapper.Map<MascotaDto>(dato);
    }
    [Authorize(Roles = "Administrador")]
    [HttpPut("update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MascotaDto>> Update(MascotaDto mascota)
    {
        var dato = await _unitOfWork.Mascotas.GetById(mascota.Id);
        if (dato == null)
        {
            return BadRequest();
        }
        var datMap = _mapper.Map<Mascota>(mascota);
        _unitOfWork.Mascotas.Update(datMap);
        await _unitOfWork.SaveAsync();
        return mascota;
    }
    [Authorize(Roles = "Administrador, Empleado")]
    [HttpGet("felino")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public ActionResult<IEnumerable<MascotaDto>> GetFelino()
    {
        var datos =  _unitOfWork.Mascotas.Find(e => e.Especie.Nombre.ToLower() == "felino");
        var mapeo = _mapper.Map<List<MascotaDto>>(datos);
        return mapeo;
    }
    [Authorize(Roles = "Administrador, Empleado")]
    [HttpGet("GoldenR")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<MascotaConPropDto>>> GetGoldenRetriever(){
        var datos = await _unitOfWork.Mascotas.GetGolden();
        var mapeo = _mapper.Map<List<MascotaConPropDto>>(datos);
        return mapeo;
    }
}
