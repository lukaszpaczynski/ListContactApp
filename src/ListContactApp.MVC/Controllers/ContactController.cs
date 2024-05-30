namespace ListContactApp.MVC.Controllers
{
    public class ContactController : Controller
    {
        private readonly IMediator _mediator;

        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/")]
        [Route("Contact/Index")]
        public async Task<IActionResult> Index()
        {
            var contacts = await _mediator.Send(new GetAllContactsQuery());
            return View(contacts);
        }

        [HttpGet]
        [Route("Contact/Details")]
        public async Task<IActionResult> Details(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Email is required.");
            }

            var contact = await _mediator.Send(new GetContactByEmailQuery(email));
            return View(contact);
        }

        [HttpGet]
        [Authorize]
        [Route("Contact/Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [Route("Contact/Create")]
        public async Task<IActionResult> Create(CreateContactCommand command)
        {
            if (command == null || !ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize]
        [Route("Contact/Edit")]
        public async Task<IActionResult> Edit(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Email is required.");
            }

            var contact = await _mediator.Send(new GetContactByEmailQuery(email));
            return View(contact);
        }

        [HttpPost]
        [Authorize]
        [Route("Contact/Edit")]
        public async Task<IActionResult> Edit(EditContactCommand command)
        {
            if (command == null || !ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize]
        [Route("Contact/Delete")]
        public async Task<IActionResult> Delete(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Email is required.");
            }

            var contact = await _mediator.Send(new GetContactByEmailQuery(email));
            return View(contact);
        }

        [HttpPost]
        [Authorize]
        [Route("Contact/Delete")]
        public async Task<IActionResult> Delete(DeleteContactCommand command)
        {
            if (command == null)
            {
                return BadRequest("Invalid data.");
            }

            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
}
