using BlazorApp1.Client.Store.WeatherUseCase;
using Havit.Blazor.Components.Web;
using Havit.Blazor.Components.Web.Bootstrap;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Client.Pages;

public partial class FetchData
{
    [Inject]
    private IState<WeatherState> WeatherState { get; set; }

    [Inject]
    private IDispatcher Dispatcher { get; set; }

    [Inject]
    private IHxMessageBoxService MessageBox { get; set; }

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

    private async Task ShowDeleteModal()
    {
        var ret = await MessageBox.ConfirmAsync($"{WeatherState.Value.CheckedIds.Count()}개 항목을 삭제하시겠습니까?");

        if (ret)
        {
            Dispatcher.Dispatch(new DeleteDataAction());
        }
    }
}
