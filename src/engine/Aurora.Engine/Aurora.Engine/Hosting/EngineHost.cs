namespace Aurora.Engine.Hosting;

/// <summary>
/// Initializes a new instance of the <see cref="EngineHost"/> class.
/// </summary>
public class EngineHost : IEngineHost
{
    public EngineHost(IServiceProvider services)
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

    #endregion
}
