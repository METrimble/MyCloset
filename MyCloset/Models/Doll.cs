namespace MyCloset.Models
{
	// There is only one instance of the doll object
	public class Doll
	{
		// List of the clothing items currently displayed on the doll
		// Only one of each clothing type can be selected at a time
		public List<ClothingItem> ClothingItems { get; set; }

		// Default Constructor
		public Doll(ClothingItem BaseTop, 
					ClothingItem BaseBottom) 
		{
			ClothingItems = new List<ClothingItem>();

			// Set the default clothing items
			ClothingItems.Add(BaseTop);
			ClothingItems.Add(BaseBottom);
		}

		// Function to select / replace clothing items
	}
}
