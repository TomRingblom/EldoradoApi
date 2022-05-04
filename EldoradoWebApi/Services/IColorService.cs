using EldoradoWebApi.Models.Colors;

namespace EldoradoWebApi.Services
{
    public interface IColorService
    {
        Task CreateColor(ColorCreate model);
        Task<IEnumerable<ColorObject>> GetColors();
        Task<ColorObject> GetColorById(int id);
        Task<ColorObject> UpdateColor(int id, ColorUpdate model);
        Task<ColorObject> DeleteColor(int id);

    }
}
