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

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                var canConnect = await _context.Database.CanConnectAsync(cancellationToken);

                if (canConnect)
                {
                    return HealthCheckResult.Healthy("O serviço está saudável.");
                }
                else
                {
                    return HealthCheckResult.Unhealthy("O serviço não está saudável.");
                }
            }
            catch (Exception ex)
            {
                return HealthCheckResult.Unhealthy("O serviço não está saudável.", ex);
            }
        }
    }
}