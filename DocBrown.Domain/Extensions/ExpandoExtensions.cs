using AutoMapper;
using System.Dynamic;

namespace DocBrown.Domain.Extensions
{
	public static class ExpandoObjectMapper
	{
		public static T Map<T>(this ExpandoObject expandoObject) where T : class, new()
		{
			var configuration = new MapperConfiguration(cfg => { });
			var mapper = configuration.CreateMapper();
			var result = mapper.Map<T>(expandoObject);
			return result;
		}
	}

	public static class DictionaryMapper
	{
		public static T Map<T>(this Dictionary<string, object> expandoObject, IMapper mapper)
		{
			var result = mapper.Map<T>(expandoObject);
			return result;
		}
	}
}
