using Hangfire;
using MediatR;

namespace WebApi.MediatRHangfireBridge
{
    public static class MediatorExtensions
    {
        public static void Enqueue(this IMediator mediator, string jobName, IRequest request)
        {
            var client = new BackgroundJobClient();
            client.Enqueue<MediatorHangfireBridge>(bridge => bridge.Send(jobName, request));
        }

        public static void Enqueue(this IMediator mediator, IRequest request)
        {
            var client = new BackgroundJobClient();
            client.Enqueue<MediatorHangfireBridge>(bridge => bridge.Send(request));
        }

        public static void AddOrUpdate(this IMediator mediator, IRequest request, string cronExpression)
        {
            RecurringJob.AddOrUpdate<MediatorHangfireBridge>(bridge => bridge.Send(request), cronExpression);
        }

        public static void AddOrUpdate<TResponse>(this IMediator mediator, IRequest<TResponse> request, string cronExpression)
        {
            RecurringJob.AddOrUpdate<MediatorHangfireBridge>(bridge => bridge.Send<TResponse>(request), cronExpression);
        }
    }
}
