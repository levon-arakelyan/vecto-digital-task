namespace VectoDigital.Core.Models.Images
{
    public class ImageManipulationRequest
    {
        public int? RotationAngle { get; set; }
        public Tuple<int, int>? ResizeMetrics { get; set; }
        public int? BlurSize { get; set; }
    }
}
