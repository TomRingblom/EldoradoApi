using EldoradoWebApi.Models.Tags;

namespace EldoradoWebApi.Services;

public interface ITagService
{
    Task<TagObject> CreateTag(TagCreate model);
    Task<IEnumerable<TagObject>> GetTags();
    Task<TagObject> GetTagById(int id);
    Task<TagObject> UpdateTag(int id, TagUpdate model);
    Task<TagObject> DeleteTag(int id);
}