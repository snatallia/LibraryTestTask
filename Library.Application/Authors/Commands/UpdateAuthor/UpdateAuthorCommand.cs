using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand:IRequest<Guid>
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }        
        public string Surname { get; set; }
    }
}
