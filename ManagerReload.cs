namespace Avae.Razor;

internal interface IManagerReload
{
    bool Reload { get; }
}

class ManagerReload(bool isWasm) : IManagerReload
{
    public bool Reload { get => !isWasm; }
}
