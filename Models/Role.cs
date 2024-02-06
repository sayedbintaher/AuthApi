using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetAuthApi.Models;

namespace AuthApi.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User>? Users { get; set; }
    }
}