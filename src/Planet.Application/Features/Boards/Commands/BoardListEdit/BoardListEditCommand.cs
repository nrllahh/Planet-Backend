using Planet.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planet.Application.Features.Boards.Commands.BoardListEdit
{
    public sealed class BoardListEditCommand : CommandBase<BoardListEditResponse>
    {

        public Guid BoardId { get; init; }
        public Guid ListId { get; init; }
        public string Title { get; init; }
        public decimal Order { get; init; }
    }
}
