using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prueba.Aplication.Dto.DTOs;
using Prueba.Application.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productService;

        public ProductController (IProductServices productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        [HttpGet()]
        public ActionResult<List<ProductDTO>> GetProducts()
        {
            try
            {
                var result = _productService.GetProducts();

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDTO> GetProductById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            try
            {
                var result = _productService.GetProductById(id);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("name/{name}")]
        public ActionResult<ProductDTO> GetProductByName(string name)
        {
            if (name == null)
            {
                return BadRequest();
            }

            try
            {
                var result = _productService.GetProductByName(name);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            } 
        }

        [HttpPost]
        public ActionResult<ProductDTO> Post([FromBody] ProductDTO dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            try
            {
                var result = _productService.AddProduct(dto);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }   
        }

        [HttpDelete("{id}")]
        public ActionResult<ProductDTO> Delete (int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            try
            {
                var result = _productService.DeleteProductById(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
