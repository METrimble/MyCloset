using MyCloset.Models;
using System.Reflection.Metadata.Ecma335;

namespace MyCloset.ViewModels
{
	public class MyClosetViewModel
	{
		public Uri BlobContainerUri { get; set; }
		public List<ClothingItem> ClothingItems { get; set; }
		public Doll Doll { get; set; }

	}
}
