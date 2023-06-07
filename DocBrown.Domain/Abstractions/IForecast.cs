namespace DocBrown.Domain.Abstractions
{
	public interface IForecast : IBaseEntity
	{
		DateOnly Date { get; set; }
		int TemperatureC { get; set; }
		string? Summary { get; set; }
	}
}