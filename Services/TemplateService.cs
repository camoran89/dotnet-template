using cd_plantilla_backend.Interfaces;
using cd_plantilla_backend.Models;
using MongoDB.Driver;

namespace cd_plantilla_backend.Services
{
    public class TemplateService : ITemplateService
    {
        private readonly IMongoCollection<Template> _collection;

        public TemplateService(IConnectionStrings connection,
            IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(connection.Database);
            _collection = database.GetCollection<Template>(connection.Collection);
        }

        List<Template> ITemplateService.FindAll()
        {
            return _collection.Find(x => true).ToList();
        }

        Template ITemplateService.FindById(string templateId)
        {
            return _collection.Find(x => x.Id == templateId).FirstOrDefault();
        }

        Template ITemplateService.Create(Template template)
        {
            _collection.InsertOne(template);
            return template;
        }

        void ITemplateService.Update(string templateId, Template template)
        {
            _collection.ReplaceOne(x => x.Id == templateId, template);
        }

        void ITemplateService.Delete(string templateId)
        {
            _collection.DeleteOne(x => x.Id == templateId);
        }
    }
}
