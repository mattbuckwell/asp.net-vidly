using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vidly_project.Models;

namespace vidly_project.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}