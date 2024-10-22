using CinemaAPI.Data;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace CinemaAPI.Util
{
    public class HealthCheckCuston : IHealthCheck
    {
        private readonly CinemaContext _context;

        public HealthCheckCuston(CinemaContext context)
        {
            _context = context;
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {

            try
            {
                var canConnect = _context.Database.CanConnectAsync(cancellationToken).Result;

                if (canConnect)
                {
                    return Task.FromResult(HealthCheckResult.Healthy("O serviço está saudável."));
                }
                else
                {
                    return Task.FromResult(HealthCheckResult.Unhealthy("O serviço não está saudável."));
                }
            }
            catch (Exception ex)
            {
                return Task.FromResult(HealthCheckResult.Unhealthy("O serviço não está saudável.", ex));
            }

        }
    }
}
