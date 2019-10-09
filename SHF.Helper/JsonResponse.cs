using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.Helper
{
    public class JsonResponse<TEntity> where TEntity : class
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public int? MessageCode { get; set; }
        public string Message { get; set; }
        public string ReturnUrl { get; set; }
        public string Icon { get; set; }
        public int StatusCode { get; set; }
        public TEntity Entity { get; set; }
        public IEnumerable<string> ValidationSummary { get; set; }
        public IEnumerable<JsonValidationError> Errors { get; set; }

        public JsonResponse()
        {
            Errors = new List<JsonValidationError>();
            ValidationSummary = new List<string>();
        }
    }
}
