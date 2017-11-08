using System;
using System.Collections.Generic;
using System.Text;

namespace tdc2017poa_xam
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
    }

    public class Session
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class Article
    {
        public int Id { get; set; }
        public string Headline { get; set; }
        public string Body { get; set; }
    }
}
