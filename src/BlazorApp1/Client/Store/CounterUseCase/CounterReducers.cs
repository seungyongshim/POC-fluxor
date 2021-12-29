namespace BlazorApp1.Client.Store.CounterUseCase;

public static class CounterReducers
{
    [ReducerMethod]
    public static CounterState ReduceIncrementCounterAction(CounterState state, IncrementCounterAction action) =>
        state with { ClickCount = 1 + state.ClickCount };
}
