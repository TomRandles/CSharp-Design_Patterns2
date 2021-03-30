using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebAPI_with_MediatR.DataAccess;
using WebAPI_with_MediatR.Entities;

namespace WebAPI_with_MediatR.Controllers
{
    [ApiController]
    [Route("api/Contacts")]
    public class ContactsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ContactsController(IMediator mediator) => this.mediator = mediator;

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContact([FromRoute]Query query )
        {
            var contact = await mediator.Send(query);
            return Ok(contact);
        }

        #region nested classes
        public class Query : IRequest<Contact>
        {
            public int Id { get; set; }
        }

        // Business logic - handle a request. Looks up db and returns a Contact response object
        public class ContactHandler : IRequestHandler<Query, Contact>
        {
            private readonly ContactsContext context;

            public ContactHandler(ContactsContext context)
            {
                this.context = context;
            }
            public Task<Contact> Handle(Query request, CancellationToken cancellationToken)
            {
                return context.Contacts.Where(c => c.Id == request.Id).SingleOrDefaultAsync();
            }
        }
        #endregion
    }
}