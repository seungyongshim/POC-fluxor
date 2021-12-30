using BlazorApp1.Shared;

namespace BlazorApp1.Client.Store.WeatherUseCase;

[FeatureState]
public record WeatherState(bool IsLoading,
                           IEnumerable<WeatherForecastDto> Forecasts,
                           IEnumerable<int> CheckedIds)
{
    private WeatherState() : this(true, null, Array.Empty<int>()) { }

    public IEnumerable<(bool Checked, WeatherForecastDto Dto)> TableView =>
        Forecasts.Select(x => (CheckedIds.Any(b => b == x.Id), x));
}

public record FetchDataAction;
public record DeleteDataAction;
public record CheckedAction(int Id);
public record UncheckedAction(int Id);
public record FetchDataResultAction(IEnumerable<WeatherForecastDto> Forecasts);

public static class WeatherReducers
{
    [ReducerMethod]
    public static WeatherState Handle(WeatherState state, FetchDataResultAction action) =>
        state with
        {
            IsLoading = false,
            Forecasts = action.Forecasts,
            CheckedIds = Array.Empty<int>()
        };

    [ReducerMethod]
    public static WeatherState Handle(WeatherState state, CheckedAction action) =>
        state with
        {
            CheckedIds = state.CheckedIds.Append(action.Id)
        };

    [ReducerMethod]
    public static WeatherState Handle(WeatherState state, UncheckedAction action) =>
        state with
        {
            CheckedIds = state.CheckedIds.Where(x => x != action.Id)
        };

    [ReducerMethod]
    public static WeatherState Handle(WeatherState state, DeleteDataAction _) =>
        state with
        {
            CheckedIds = Array.Empty<int>(),
            Forecasts = from a in state.Forecasts
                        where !state.CheckedIds.Any(b => b == a.Id) 
                        select a
        };
}

public record WeatherEffects(HttpClient HttpClient)
{
    [EffectMethod]
    public async Task Handle(FetchDataAction _, IDispatcher dispatcher)
    {
        var forecasts = await HttpClient.GetFromJsonAsync<IEnumerable<WeatherForecastDto>>("WeatherForecast");
        dispatcher.Dispatch(new FetchDataResultAction(forecasts));
    }
}
