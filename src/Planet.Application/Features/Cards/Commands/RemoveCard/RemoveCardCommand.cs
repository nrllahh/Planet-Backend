using Planet.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planet.Application.Features.Cards.Commands.RemoveCard
{
    public class RemoveCardCommand : CommandBase<RemoveCardResponse>
    {
        public Guid CardId { get; init; }
    }
   
}
