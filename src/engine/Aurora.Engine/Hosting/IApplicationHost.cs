using Microsoft.Extensions.Hosting;

namespace Aurora.Engine.Hosting;

public interface IApplicationHost : IHost
{
    // create implementation in presentation/ui layer later
    // generic host for the application (use a generic host)
    // default configuration and services

    // usage:
    // created at startup
    // resolve an IEngineHost for a requested system
}

public class ApplicationHost : IApplicationHost
{
    public ApplicationHost(IServiceProvider services)
    {
        Services = services;
    }

    public IServiceProvider Services { get; }

    public Task StartAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task StopAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    #region IDisposable

    private bool isDisposed;

    protected virtual void Dispose(bool disposing)
    {
        if (!isDisposed)
        {
            if (disposing)
            {
                // TODO: dispose managed state (managed objects)
            }

            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null
            isDisposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    public IEngineHost CreateEngineHost(string systemIdentifier) => throw new NotImplementedException();

    #endregion
}