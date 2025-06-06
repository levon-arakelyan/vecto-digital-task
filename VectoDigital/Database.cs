using VectoDigital.Core.Entities;
using VectoDigital.Core.Enums;

namespace VectoDigital
{
    public static class Database
    {
        public static List<Image> Images { get; } = [];
        public static List<ImagePlugin> Plugins { get; } = [];
    }
}
