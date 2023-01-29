namespace irish_rail_api.Common.Access {
	public interface IApiAccess<T> {
		IEnumerable<T> GetResources(Uri uri);
	}
}