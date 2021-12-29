using BlazorApp1.Shared;

namespace BlazorApp1.Client.Store.WeatherUseCase;

[FeatureState]
public record WeatherState(bool IsLoading, IEnumerable<WeatherForecast> Forecasts)
{
    private WeatherState() : this(true, null)
    {
    }
}

public record FetchDataAction;

public static class WeatherReducers
{
    [ReducerMethod]
    public static WeatherState FetchDataResultAction(WeatherState state, FetchDataResultAction action) =>
        state with { IsLoading = false, Forecasts = action.Forecasts };
}

public record FetchDataResultAction(IEnumerable<WeatherForecast> Forecasts);

public record WeatherEffect(HttpClient HttpClient)
{
    [EffectMethod]
    public async Task Handle(FetchDataAction _, IDispatcher dispatcher)
    {
        var forecasts = await HttpClient.GetFromJsonAsync<IEnumerable<WeatherForecast>>("WeatherForecast");
        dispatcher.Dispatch(new FetchDataResultAction(forecasts));
    }
}
