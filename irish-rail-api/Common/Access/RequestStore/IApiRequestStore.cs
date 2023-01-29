namespace irish_rail_api.Common.Access.RequestStore {
	public interface IApiRequestStore {
		IEnumerable<T>? Retrieve<T>(Uri uri);

		void Save(Uri uri, IEnumerable<object> result);
	}
}