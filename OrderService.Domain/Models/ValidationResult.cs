using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Domain.Models
{
    public class ValidationResult<T>
    {
        public List<String> Errors { get; }

        public T Model { get; }

        public bool IsValid => !Errors.Any();

        public ValidationResult(T model)
        {
            Model = model;
            Errors = new List<string>();
        }
    }
}
