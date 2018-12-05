using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace MultiPlayer.BusinessObjects.Models
{
	public class User
	{
		public User() => this.Games = new HashSet<Game>();

		[Key]
		[DataMember]
		public int Id { get; set; }
		[StringLength(50)]
		[DataMember]
		public string Username { get; set; }
		[StringLength(50)]
		[DataMember]
		public string Password { get; set; }
		[StringLength(50)]
		[DataMember]
		public string Firstname { get; set; }
		[StringLength(50)]
		[DataMember]
		public string Lastname { get; set; }
		[StringLength(50)]
		[DataMember]
		public string Email { get; set; }
		[IgnoreDataMember]
		public virtual ICollection<Game> Games { get; set; }
	}
}
