using Microsoft.AspNetCore.Mvc;
using MyCloset.Data;
using Microsoft.EntityFrameworkCore;

namespace MyCloset.Controllers
{
	public class MyClosetController : Controller
	{
		private readonly Context _context;

		// Database context
		public MyClosetController(Context context)
		{
			_context = context;
		}

		// Retrieve all clothing items from the database
		// Use asynchronous action to retrieve data from the database
		public async Task<IActionResult> Closet()
		{
			// Clothing Items database set
			var ClothingItems = await _context.ClothingItems.ToListAsync();
		
			// Wait until we get data back before returning the view
			return View(ClothingItems);
		}
	}
}
