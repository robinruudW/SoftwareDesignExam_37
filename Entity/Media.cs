using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam_37.Entity
{
	public abstract class Media
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string? Description { get; set; }

		public int? YearOfRelease { get; set; }

		public double? MyAppScore { get; set; }

	}
}
