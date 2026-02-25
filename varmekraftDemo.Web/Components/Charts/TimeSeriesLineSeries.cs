namespace varmekraftDemo.Web.Components.Charts;

public sealed record TimeSeriesLineSeries<TItem>(
    string Name,
    Func<TItem, decimal?> YSelector,
    Func<TItem, bool>? ItemFilter = null);
