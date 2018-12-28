using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Client
    {
        public string Name
        {
            get;
            set;
        }
        public int Address
        {
            get;
            set;
        }
        public override string ToString()
        {
            return this.Name + "-" + this.Address;
        }
    }
}