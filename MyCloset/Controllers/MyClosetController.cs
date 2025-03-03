using Microsoft.AspNetCore.Mvc;
using MyCloset.Data;
using Microsoft.EntityFrameworkCore;
using Azure.Storage.Blobs;
using MyCloset.Models;
using MyCloset.ViewModels;

namespace MyCloset.Controllers
{
	public class MyClosetController : Controller
	{
		// Database context
		private readonly Context _context;

		// Blob Account Container and Stoage
		private const string ContainerName = "mycloset";
		private readonly BlobServiceClient _blobServiceClient;
		private readonly BlobContainerClient _containerClient;

		// My Closet Model used to send multiple parmaters into the view
		static ViewModels.MyClosetViewModel MyClosetParam = new ViewModels.MyClosetViewModel();

		// Is Base Top
		private static bool IsBaseTop(ClothingItem ClothingItem)
		{
			if(ClothingItem.Type == ClothingType.Top && ClothingItem.IsBase)
				return true;
			return false;
		}
		
		// Is Base Bottom
		private static bool IsBaseBottom(ClothingItem ClothingItem)
		{
			if (ClothingItem.Type == ClothingType.Bottoms && ClothingItem.IsBase)
				return true;
			return false;
		}

		// Constructor
		public MyClosetController(Context context, BlobServiceClient blobServiceClient)
		{
			_context = context;

			_blobServiceClient = blobServiceClient;
			_containerClient = _blobServiceClient.GetBlobContainerClient(ContainerName);
		}

		// Build the default closet view
		public async Task<IActionResult> Closet()
		{
			// Wait until we get data back before returning the view
			var Closet = await _context.ClothingItems.ToListAsync();

			// Error handling
			if (Closet == null ||
				Closet.Find(IsBaseTop) == null ||
				Closet.Find(IsBaseBottom) == null)
			{
				// TODO error
			}

			// Create the MyCloset View Model
			MyClosetParam.ClothingItems = Closet;
			MyClosetParam.BlobContainerUri = _containerClient.Uri;
			MyClosetParam.Doll = new Doll(Closet.Find(IsBaseTop), Closet.Find(IsBaseBottom));

			return View("Closet", MyClosetParam);
		}

		[HttpPost]
		// Triggered when a clothing item has been selected or deselected
		public ActionResult OnSelectClothingItem(int Id)
		{
			// Retreive the clothing item selected
			ClothingItem SelectedClothingItem = MyClosetParam.ClothingItems.Find(i => i.Id == Id);

			// Error Handling
			if(SelectedClothingItem == null || 
			   MyClosetParam.ClothingItems == null || 
			   MyClosetParam.Doll.ClothingItems == null)
			{
				// TODO error alert
				return PartialView("_Doll", new Tuple<Doll, Uri>(MyClosetParam.Doll, MyClosetParam.BlobContainerUri));
			}

			// If clothing exists on the doll, remove it
			if (MyClosetParam.Doll.ClothingItems.IndexOf(SelectedClothingItem) != -1)
			{
				MyClosetParam.Doll.ClothingItems.Remove(SelectedClothingItem);

				// If this is a Top or Bottom and removing it left the doll without either,
				// Make sure the base clothing is added back
				if (SelectedClothingItem.Type == ClothingType.Bottoms && 
					MyClosetParam.Doll.ClothingItems.Find(c => c.Type == ClothingType.Bottoms) == null)
					MyClosetParam.Doll.ClothingItems.Add(MyClosetParam.ClothingItems.Find(IsBaseBottom));

				else if (SelectedClothingItem.Type == ClothingType.Top && 
					     MyClosetParam.Doll.ClothingItems.Find(c => c.Type == ClothingType.Top) == null)
					MyClosetParam.Doll.ClothingItems.Add(MyClosetParam.ClothingItems.Find(IsBaseTop));
			}

			// If clothing does not exist on the doll, add it 
			else
			{
				MyClosetParam.Doll.ClothingItems.Add(SelectedClothingItem);

				// See if base clothing is on the doll
				ClothingItem BaseBottom = null;
				ClothingItem BaseTop = null;

				BaseBottom = MyClosetParam.Doll.ClothingItems.Find(IsBaseBottom);
				BaseTop = MyClosetParam.Doll.ClothingItems.Find(IsBaseTop);

				// If this is a Top or Bottom, make sure the base clothing is removed after adding new 
				if (SelectedClothingItem.Type == ClothingType.Bottoms && BaseBottom != null)
					MyClosetParam.Doll.ClothingItems.Remove(BaseBottom);

				else if (SelectedClothingItem.Type == ClothingType.Top && BaseTop != null)
					MyClosetParam.Doll.ClothingItems.Remove(BaseTop);
			}

			return PartialView("_Doll", new Tuple<Doll, Uri>(MyClosetParam.Doll, MyClosetParam.BlobContainerUri));
		}
	}
}
