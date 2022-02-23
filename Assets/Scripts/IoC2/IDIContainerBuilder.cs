public interface IDIContainerBuilder
{
  public DIContainer GenerateContainer();

  public void RegisterSingleton<TService>(TService instance);

  public void RegisterSingleton<TService>();

  public void RegisterSingleton<TService, TImplementation>() where TImplementation : TService;

  public void RegisterTransient<TService>();

  public void RegisterTransient<TService, TImplementation>() where TImplementation : TService;
}
