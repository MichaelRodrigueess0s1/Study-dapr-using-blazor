using DocBrown.Domain.Abstractions;

namespace DocBrown.Domain
{
	public class WeatherForecast : BaseEntity, IForecast
	{
		public DateOnly Date { get; set; }
		public int TemperatureC { get; set; }
		public string? Summary { get; set; }
		public decimal TemperatureF => 32 + (int)(TemperatureC / 0.5556);
	}
}