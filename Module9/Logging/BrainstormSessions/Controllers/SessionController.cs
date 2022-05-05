using System.Threading.Tasks;
using BrainstormSessions.Core.Interfaces;
using BrainstormSessions.ViewModels;
//using log4net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BrainstormSessions.Controllers
{
    public class SessionController : Controller
    {
        private readonly IBrainstormSessionRepository _sessionRepository;
        //private readonly ILog _log = LogManager.GetLogger(typeof(SessionController));
        private readonly ILogger<SessionController> _logger;
        public SessionController(IBrainstormSessionRepository sessionRepository,
            ILogger<SessionController> logger)
        {
            _sessionRepository = sessionRepository;
            _logger = logger;
        }

        public async Task<IActionResult> Index(int? id)
        {
            //_log.Debug("SessionController/Index");
            _logger.LogDebug("SessionController/Index");

            if (!id.HasValue)
            {
                //_log.Warn($"Id {id} is not valid.");
                _logger.LogWarning($"Id {id} is not valid.");

                return RedirectToAction(actionName: nameof(Index),
                    controllerName: "Home");
            }

            var session = await _sessionRepository.GetByIdAsync(id.Value);

            if (session == null)
            {
                //_log.Warn($"Session {id.Value} was not found.");
                //_log.Error($"Session {id.Value} was not found.");
                _logger.LogWarning($"Session {id.Value} was not found.");
                _logger.LogError($"Session {id.Value} was not found.");

                return Content("Session not found.");
            }

            var viewModel = new StormSessionViewModel()
            {
                DateCreated = session.DateCreated,
                Name = session.Name,
                Id = session.Id
            };

            //_log.Debug($"Session Id: {session.Id}");
            _logger.LogDebug($"Session Id: {session.Id}");

            return View(viewModel);
        }
    }
}
