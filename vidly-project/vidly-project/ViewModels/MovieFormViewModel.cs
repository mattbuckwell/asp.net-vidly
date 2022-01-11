using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vidly_project.Models;

namespace vidly_project.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genre { get; set; }
        public Movie Movie { get; set; }
    }
}