﻿using FotoBlog.Attributes;
using System.ComponentModel.DataAnnotations;

namespace FotoBlog.Models
{
	public class YeniGonderiViewModel
	{
		[Display(Name = "Başlık")]
		[Required(ErrorMessage = "{0} girilmesi zorunludur!")]
		public string Baslik { get; set; } = null!;

		[Display(Name = "Resim")]
		[Required(ErrorMessage = "{0} koyulması zorunludur!")]
		[GecerliResim(MaxDosyaBoyutuMb = 1.2)]
		public IFormFile Resim { get; set; } = null!;
	}
}
