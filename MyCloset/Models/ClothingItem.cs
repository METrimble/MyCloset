namespace MyCloset.Models
{
    public enum ClothingType
    {
        Socks = 0,
        Shoes = 1,
        Bottoms = 2,
        Top = 3,
        Dress = 4,
        Outerwear = 5,
        Bag = 6,
        Accessories = 7
    }

    public class ClothingItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameDecode { get; set; }
        public ClothingType Type { get; set; }
        public int StackType { get; set; }
        public bool IsBase { get; set; }
        public string ImageName { get; set; }
        public string CroppedImageName { get; set; }

		// Is Base Top
		public bool IsBaseTop()
		{
			if (this.Type == ClothingType.Top && this.IsBase)
				return true;

			return false;
		}

		// Is Base Bottom
		public bool IsBaseBottom()
		{
			if (this.Type == ClothingType.Bottoms && this.IsBase)
				return true;

			return false;
		}
	}
}
