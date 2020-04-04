using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DL.Inventory.Core.Model
{
    public class User
    {
        [_MapperTO("ID_USER")]
        public int id_user { get; set; }

        [_MapperTO("USERNAME")]
        public string username { get; set; }

        [_MapperTO("EMAIL")]
        public string email { get; set; }

        [_MapperTO("AGE")]
        public int age { get; set; }

        [_MapperTO("LOGIN")]
        public string login { get; set; }

        [_MapperTO("PASSWORD")]
        public string password { get; set; }

        [_MapperTO("FACEID")]
        public string faceid { get; set; }

        [_MapperTO("TOUCHID")]
        public string touchid { get; set; }

        [_MapperTO("ACTIVE")]
        public string active { get; set; }

        [_MapperTO("ATTEMPTS")]
        public int attempts { get; set; }

        [_MapperTO("BLOCKED")]
        public string blocked { get; set; }

        [_MapperTO("PROFILE_ID")]
        public int profile_id { get; set; }

        [_MapperTO("CHANGE_PASSWORD")]
        public int change_password { get; set; }
    }
}
