using BlazorApp1.Client.Store.WeatherUseCase;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Client.Pages;

public partial class FetchData
{
    [Inject]
    private IState<WeatherState> WeatherState { get; set; }

    [Inject]
    private IDispatcher Dispatcher { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        Dispatcher.Dispatch(new FetchDataAction());
    }
}
