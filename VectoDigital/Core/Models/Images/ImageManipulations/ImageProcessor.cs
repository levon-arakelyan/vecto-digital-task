using VectoDigital.Core.Interfaces;

namespace VectoDigital.Core.Models.Images.ImageManipulations
{
    public class ImageProcessor
    {
        private readonly List<IImageManipulation> _manipulations = [];

        public void AddManipulation(IImageManipulation manipulation)
        {
            _manipulations.Add(manipulation);
        }

        public byte[] Process(byte[] input)
        {
            byte[] result = input;
            foreach (var manipulation in _manipulations)
            {
                result = manipulation.Apply(result);
            }
            return result;
        }
    }
}
