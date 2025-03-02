using Microsoft.AspNetCore.Mvc;
using MyCloset.Data;
using Microsoft.EntityFrameworkCore;
using Azure.Storage.Blobs;
using MyCloset.Models;

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
		static ViewModels.MyClosetViewModel MyCloset = new ViewModels.MyClosetViewModel();

		// Is Base Top
		private static bool IsBaseTop(ClothingItem ClothingItem)
		{
			if(ClothingItem.Type == ClothingType.Top)
				return true;
			return false;
		}
		
		// Is Base Bottom
		private static bool IsBaseBottom(ClothingItem ClothingItem)
		{
			if (ClothingItem.Type == ClothingType.Bottoms)
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
			if (Closet.Count == 0 || Closet == null)
			{
				// TODO error
			}

			// Create the MyCloset View Model
			MyCloset.ClothingItems = Closet;
			MyCloset.BlobContainerUri = _containerClient.Uri;
			MyCloset.Doll = new Doll(Closet.Find(IsBaseTop), Closet.Find(IsBaseBottom));
			return View("Closet", MyCloset);
		}

		[HttpPost]
		public void OnSelectClothingItem(int Id)
		{
			Console.WriteLine("Hmmmmm");

			//
		}
	}
}
