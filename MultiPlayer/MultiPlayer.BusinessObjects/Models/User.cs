using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MultiPlayer.BusinessObjects.Models
{
	public class User
	{
		[Key]
		public int Id { get; set; }
		[StringLength(50)]
		public string Username { get; set; }
		[StringLength(50)]
		public string Password { get; set; }
		[StringLength(50)]
		public string Firstname { get; set; }
		[StringLength(50)]
		public string Lastname { get; set; }
		[StringLength(50)]
		public string Email { get; set; }
		public virtual IList<Match> Matches { get; set; }
	}
}
