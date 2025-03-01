namespace MyCloset.Models
{
	// There is only one instance of the doll object
	public class Doll
	{
		// List of the clothing items currently displayed on the doll
		// only one of each clothing type will be selected at each time, enforced by the selector functions
		public List<ClothingItem> ClothingItems { get; set; }

		// Default Constructor
		public Doll() 
		{
			// TODO: add default clothing
			ClothingItems = new List<ClothingItem>();
		}

		// Function to select / replace clothing items
	}
}
