using Microsoft.Extensions.Hosting;

namespace Aurora.Engine.Hosting;

/// <summary>
/// Initializes a new instance of the <see cref="EngineHost"/> class.
/// </summary>
public class EngineHost : IEngineHost
{
    private readonly IHost host;

    public EngineHost(IHost host)
    {
        this.host = host;
    }

    public IServiceProvider Services => host.Services;

    public Task StartAsync(CancellationToken cancellationToken = default)
    {
        return host.StartAsync(cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken = default)
    {
        return host.StopAsync(cancellationToken);
    }

    #region IDisposable

    private bool isDisposed;

    protected virtual void Dispose(bool disposing)
    {
        if (!isDisposed)
        {
            if (disposing)
            {
                host.Dispose();
            }

            isDisposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    #endregion
}
