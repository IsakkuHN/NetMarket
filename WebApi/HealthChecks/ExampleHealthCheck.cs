using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace WebApi.HealthChecks {
    public class ExampleHealthCheck : IHealthCheck {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default) {
            bool healthCheckResultHealthy = true;

            if(healthCheckResultHealthy) {
                return Task.FromResult(HealthCheckResult.Healthy("App is currently working fine."));
            }

            return Task.FromResult(HealthCheckResult.Unhealthy("App is not working correctly."));
        }
    }
}
