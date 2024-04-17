namespace TheBigStore.Service.DataTransferObjects
{
    public class ImageDto
    {
        public int ImageId { get; set; } // PK
        public string DefaultText { get; set; } = "Image Not Load";
        public string ImgPath { get; set; }

        public ItemDto Item { get; set; }
    }
}
