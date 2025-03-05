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
				Closet.Find(c => c.IsBaseTop()) == null ||
				Closet.Find(c => c.IsBaseBottom()) == null)
			{
				// TODO error
			}

			// Create the MyCloset View Model
			MyClosetParam.ClothingItems = Closet;
			MyClosetParam.BlobContainerUri = _containerClient.Uri;
			MyClosetParam.Doll = new Doll(Closet.Find(c => c.IsBaseTop()), 
										  Closet.Find(c => c.IsBaseBottom()));

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
			if (MyClosetParam.Doll.ClothingItemEquipped(SelectedClothingItem))
			{
				MyClosetParam.Doll.RemoveClothingItemFromDoll(SelectedClothingItem,
															  MyClosetParam.ClothingItems.Find(c => c.IsBaseBottom()),
															  MyClosetParam.ClothingItems.Find(c => c.IsBaseTop()));
			}

			// If clothing does not exist on the doll, add it 
			else
			{
				MyClosetParam.Doll.AddClothingItemToDoll(SelectedClothingItem);
			}

			// Return a partial view of the doll, so only the doll partial is refreshed
			return PartialView("_Doll", new Tuple<Doll, Uri>(MyClosetParam.Doll, MyClosetParam.BlobContainerUri));
		}
	}
}
