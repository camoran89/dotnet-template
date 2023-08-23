using cd_plantilla_backend.Models;

namespace cd_plantilla_backend.Interfaces
{
    public interface ITemplateService
    {
        List<Template> FindAll();
        Template FindById(string templateId);
        Template Create(Template template);
        void Update(string templateId, Template template);
        void Delete(string templateId);
    }
}
