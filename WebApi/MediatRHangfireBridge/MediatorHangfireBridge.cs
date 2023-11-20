using MediatR;
using System.ComponentModel;

namespace WebApi.MediatRHangfireBridge
{
    /// <summary>
    /// Class that allows use Mediator in hangfire methods  
    /// </summary>
    internal class MediatorHangfireBridge
    {
        private readonly IMediator _mediator;

        public MediatorHangfireBridge(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Send(IRequest command)
        {
            await _mediator.Send(command);
        }

        public async Task Send<TRequest>(IRequest<TRequest> command)
        {
            await _mediator.Send(command);
        }
    }
}
