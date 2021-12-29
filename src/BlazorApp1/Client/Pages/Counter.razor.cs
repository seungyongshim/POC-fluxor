using BlazorApp1.Client.Store.CounterUseCase;
using Microsoft.AspNetCore.Components;

namespace BlazorApp1.Client.Pages;

public partial class Counter
{
    [Inject]
    IState<CounterState> CounterState { get; set; }

    [Inject]
    public IDispatcher Dispatcher { get; set; }

    private void IncrementCounterAction() =>
        Dispatcher.Dispatch(new IncrementCounterAction());
}
