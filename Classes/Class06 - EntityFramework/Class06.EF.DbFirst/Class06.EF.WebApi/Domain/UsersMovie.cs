using System;
using System.Collections.Generic;

namespace Class06.EF.WebApi.Domain
{
    public partial class UsersMovie
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public int Id { get; set; }

        public virtual Movie Movie { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
