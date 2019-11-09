using System;
namespace Lab2.Models
{
    public class IndexModel
    {
        public string FirstImageType { get; set; } = "Unknown";
        public float FirstImageConfidence { get; set; } = 0.0f;
        public string SecondImageType { get; set; } = "Unknown";
        public float SecondImageConfidence { get; set; } = 0.0f;
        public string ThirdImageType { get; set; } = "Unknown";
        public float ThirdImageConfidence { get; set; } = 0.0f;
        public string FourthImageType { get; set; } = "Unknown";
        public float FourthImageConfidence { get; set; } = 0.0f;
    }
}
