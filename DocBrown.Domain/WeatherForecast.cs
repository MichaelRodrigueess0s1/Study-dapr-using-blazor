namespace DocBrown.Domain
{
	public class WeatherForecast
	{
		public string KeyID => ID.ToString();
		public long ID { get; set; }
		public DateOnly Date { get; set; }
		public int TemperatureC { get; set; }
		public string? Summary { get; set; }
		public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
	}
}