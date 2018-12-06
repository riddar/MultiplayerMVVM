using System.ComponentModel.DataAnnotations.Schema;

namespace MultiPlayer.BusinessObjects.Models
{
	public class Match
	{
		public int Id { get; set; }

		public int? GameId { get; set; }

		[ForeignKey("GameId")]
		public virtual Game Game { get; set; }

		public int? UserId { get; set; }

		[ForeignKey("UserId")]
		public virtual User User { get; set; }
	}
}
