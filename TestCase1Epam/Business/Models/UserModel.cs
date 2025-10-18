﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCase1Epam.Business.Models
{

    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName {  get; set; }
        public string Email { get; set; }
        public Adress Adress { get; set; }
        public string phone { get; set; }
        public string Website { get; set; }
        public Company Company { get; set; }
    
    }
}
