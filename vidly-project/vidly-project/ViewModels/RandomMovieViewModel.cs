using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vidly_project.Models;

namespace vidly_project.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}