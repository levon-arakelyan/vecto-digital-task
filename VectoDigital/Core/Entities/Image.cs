using VectoDigital.Core.Enums;

namespace VectoDigital.Core.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public byte[] ImageBytes { get; set; } = [];
        public List<ImagePlugin> Plugins { get; set; } = [];
    }
}
