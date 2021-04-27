using System;
using my_book.Data.Models;

namespace my_book.Data.ViewModels
{
    public class CustomActionResultVM
    {
        public Exception Exception { get; set; }
        public Publisher Publisher { get; set; }

    }
}