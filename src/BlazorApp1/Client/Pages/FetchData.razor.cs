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

    private void Check(ChangeEventArgs e, int id)
    {
        if (e.Value is bool @checked)
        {
            Dispatcher.Dispatch(@checked ? new CheckedAction(id)
                                         : new UncheckedAction(id));
        }
    }

    private void Delete()
    {
        Dispatcher.Dispatch(new DeleteDataAction());
    }
}
