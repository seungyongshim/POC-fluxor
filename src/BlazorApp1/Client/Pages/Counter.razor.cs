using BlazorApp1.Client.Store.CounterUseCase;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorApp1.Client.Pages;

public partial class Counter
{
    [Inject]
    private IState<CounterState> CounterState { get; set; }

    [Inject]
    private IJSRuntime JS { get; set; }

    [Inject]
    private IDispatcher Dispatcher { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender) 
    {
        //await JS.InvokeAsync<object>("routeNewPage", null);
        await base.OnAfterRenderAsync(firstRender);
    }

    private async Task IncrementCounterAction() 
    {
        Dispatcher.Dispatch(new IncrementCounterAction());
    }

    
}
