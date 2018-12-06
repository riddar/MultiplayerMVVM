using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MultiPlayer.BusinessObjects.Models
{
	public class Game
	{
		[Key]
		public int Id { get; set; }
		[StringLength(50)]
		public string Name { get; set; }
		public virtual IList<Match> Matches { get; set; }
	}
}
