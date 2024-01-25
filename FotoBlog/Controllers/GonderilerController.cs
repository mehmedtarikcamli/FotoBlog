using FotoBlog.Data;
using FotoBlog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FotoBlog.Controllers
{
	public class GonderilerController : Controller
	{
		private UygulamaDbContext _db;
		private IWebHostEnvironment _env;

		public GonderilerController(UygulamaDbContext db, IWebHostEnvironment env) 
		{
			_db = db;
			_env = env;
		}
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Yeni()
		{
			return View();
		}

		[HttpPost, ValidateAntiForgeryToken]
		public IActionResult Yeni(YeniGonderiViewModel vm)
		{
			if (ModelState.IsValid)
			{
				string ext = Path.GetExtension(vm.Resim.FileName);
				string yeniDosyaAd = Guid.NewGuid() + ext;
				string yol = Path.Combine(_env.WebRootPath, "img", "upload", yeniDosyaAd);

				using(var fs = new FileStream(yol, FileMode.CreateNew))
				{
					vm.Resim.CopyTo(fs);
				}

				_db.Gonderiler.Add(new Gonderi
				{
					Baslik = vm.Baslik,
					ResimYolu = yeniDosyaAd
				});

				_db.SaveChanges();

				return RedirectToAction("Index", "Home", new { Sonuc = "Eklendi" });
			}

			return View();
		}

		public IActionResult Duzenle(int id)
		{
			var gonderi = _db.Gonderiler.Find(id);

			if (gonderi == null)
			{
				return NotFound();
			}

			return View(gonderi);
		}

		[HttpPost]
		public IActionResult Duzenle(int id, Gonderi gonderi)
		{
			if (id != gonderi.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
                    var mevcutGonderi = _db.Gonderiler.Find(id);

                    string eskiResimYolu = Path.Combine(_env.WebRootPath, "img", "upload", mevcutGonderi.ResimYolu);

                    string yeniResimYolu = Path.Combine(_env.WebRootPath, "img", "upload", gonderi.ResimYolu);

                    if (eskiResimYolu != yeniResimYolu)
                    {
                        System.IO.File.Delete(eskiResimYolu);
                    }

                    mevcutGonderi.Baslik = gonderi.Baslik;
                    mevcutGonderi.ResimYolu = gonderi.ResimYolu;

                    _db.Update(mevcutGonderi);
					_db.SaveChanges();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!GonderiVarMi(id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}

				return RedirectToAction("Index", "Home");
			}

			return View(gonderi);
		}

		private bool GonderiVarMi(int id)
		{
			return _db.Gonderiler.Any(e => e.Id == id);
		}

		public IActionResult Sil(int id)
		{
			var gonderi = _db.Gonderiler.Find(id);

			if (gonderi == null)
			{
				return NotFound();
			}

			return View(gonderi);
		}

		[HttpPost, ActionName("SilOnaylandi")]
		public IActionResult SilOnaylandi(int id)
		{
			
			var gonderi = _db.Gonderiler.Find(id);

			if (gonderi == null)
			{
				return NotFound();
			}

			string silinecekYol = Path.Combine(_env.WebRootPath, "img", "upload", gonderi.ResimYolu);

            System.IO.File.Delete(silinecekYol);

            _db.Gonderiler.Remove(gonderi);
			_db.SaveChanges();

			return RedirectToAction("Index", "Home");
		}
	}
}
