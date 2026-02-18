namespace varmekraftDemo.Web.Components.Charts;

public sealed record CategoryBarSeries<TItem>(
    string Name,
    Func<TItem, decimal?> YSelector,
    bool Negate = false);
