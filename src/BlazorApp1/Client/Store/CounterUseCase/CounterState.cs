namespace BlazorApp1.Client.Store.CounterUseCase;

[FeatureState]
public record CounterState(int ClickCount)
{
    private CounterState() : this(0)
    {
    }
}
