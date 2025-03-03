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

		// Remove clothing item from doll 
		public void RemoveClothingItemFromDoll(ClothingItem SelectedClothingItem,
											   ClothingItem BaseBottom,
											   ClothingItem BaseTop)
		{
			this.ClothingItems.Remove(SelectedClothingItem);

			// If this is a Top or Bottom and removing it left the doll without either,
			// add the base clothing is added back
			if (SelectedClothingItem.Type == ClothingType.Bottoms &&
				this.ClothingItems.Find(c => c.Type == ClothingType.Bottoms) == null)
			{
				this.ClothingItems.Add(BaseBottom);
			}

			else if (SelectedClothingItem.Type == ClothingType.Top &&
					 this.ClothingItems.Find(c => c.Type == ClothingType.Top) == null)
			{
				this.ClothingItems.Add(BaseTop);
			}
		}

		// Add clothing item to doll
		public void AddClothingItemToDoll(ClothingItem SelectedClothingItem)
		{
			this.ClothingItems.Add(SelectedClothingItem);

			// See if base clothing is on the doll
			ClothingItem BaseBottom = this.ClothingItems.Find(c => c.IsBaseBottom());
			ClothingItem BaseTop = this.ClothingItems.Find(c => c.IsBaseTop());

			// If this is a Top or Bottom, make sure the base clothing is removed after adding new 
			if (SelectedClothingItem.Type == ClothingType.Bottoms && BaseBottom != null)
				this.ClothingItems.Remove(BaseBottom);

			else if (SelectedClothingItem.Type == ClothingType.Top && BaseTop != null)
				this.ClothingItems.Remove(BaseTop);
		}

		// Clothing Item currently equipped on doll
		public bool ClothingItemEquipped(ClothingItem SelectedClothingItem)
		{
			if (this.ClothingItems.IndexOf(SelectedClothingItem) == -1)
				return false;

			return true;
		}
	}
}
