﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volleyball.DTO
{
    public class TeamPlayerDto
    {
        public int? Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? Email { get; set; }

        public int Heigth { get; set; }

        public int JerseyNumber { get; set; }



    }
}
