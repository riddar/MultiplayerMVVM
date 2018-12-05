using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace MultiPlayer.BusinessObjects.Models
{
	public class Game
	{
		public Game() => this.Users = new HashSet<User>();

		[Key]
		[DataMember]
		public int Id { get; set; }
		[StringLength(50)]
		[DataMember]
		public string Name { get; set; }
		[DataMember]
		public virtual ICollection<User> Users { get; set; }
	}
}
