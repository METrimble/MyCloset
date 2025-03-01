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

			// Create the MyCloset View Model
			var MyCloset = new ViewModels.MyClosetViewModel();
			MyCloset.ClothingItems = Closet;
			MyCloset.BlobContainerUri = _containerClient.Uri;

			return View(MyCloset);
		}
	}
}
