using cd_plantilla_backend.Interfaces;
using cd_plantilla_backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace cd_plantilla_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateController : ControllerBase
    {
        private readonly ITemplateService _templateService;
        public TemplateController(ITemplateService templateService) 
        {
            _templateService = templateService;
        }

        [HttpGet] 
        public ActionResult<List<Template>> FindAll() 
        {
            var values = _templateService.FindAll();
            return values is null ? NotFound() : values;
        }

        [HttpGet("{id}")]
        public ActionResult<Template> FindById(string id)
        {
            var value = _templateService.FindById(id);
            return value is null ? NotFound() : value;
        }

        [HttpPost]
        public ActionResult<Template> Create([FromBody] Template template)
        {
            _templateService.Create(template);

            return CreatedAtAction(nameof(FindById), new { id = template.Id }, template);
        }

        [HttpPut("{id}")]
        public ActionResult Update(string id, [FromBody] Template template)
        {
            var found = _templateService.FindById(id);

            if (found is null)
            {
                return NotFound();
            }
            
            _templateService.Update(id, template);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var found = _templateService.FindById(id);

            if (found is null)
            {
                return NotFound();
            }

            _templateService.Delete(id);

            return NoContent();
        }
    }
}
