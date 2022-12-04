using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zip.InstallmentsService.ViewModels
{
    public class ValidationErrors
    {
        public List<Error> Errors { get; set; } = new List<Error>();
        public string Title { get; set; }
        public int StatusCode { get; set; }
    }
    public class Error
    {
        public string Message { get; }
        public string Source { get; }
        public Error(string source, string message)
        {
            Source = source;
            Message = message;
        }
    }
}
