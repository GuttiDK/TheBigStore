namespace TheBigStore.Repository.Models
{
    public class Image
    {
        public int ImageId { get; set; } // PK
        public string DefaultText { get; set; } = "Image Not Load";
        public string ImgPath { get; set; }

        public Item Item { get; set; }
    }
}
