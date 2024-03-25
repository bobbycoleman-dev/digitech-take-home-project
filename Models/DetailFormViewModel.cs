#pragma warning disable
using System;
namespace DigitechTakeHomeProject.Models
{
	public class DetailFormViewModel
	{
		public Patient Patient { get; set; } = new Patient();
		public bool? isNotEditable { get; set; }
	}
}

