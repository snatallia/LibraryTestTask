using Library.Domain;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Library.Application.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommand: IRequest<Guid>
    {
        public string Name { get; set; }      
        public string Surname { get; set; }
    }
}
