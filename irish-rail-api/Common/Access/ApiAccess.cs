using irish_rail_api.Common.Access.RequestStore;
using irish_rail_api.Common.Xml;
using System.Xml;

namespace irish_rail_api.Common.Access {
	public class ApiAccess<T> : IApiAccess<T> {
		public IEnumerable<T> GetResources(Uri uri) {
			var requestStoreEntry = ApiRequestStoreSession.Store.Retrieve<T>(uri);
			if (requestStoreEntry != null)
				return requestStoreEntry;

			using var httpClient = new HttpClient();
			var response = httpClient.GetAsync(uri).Result;

			if (response.IsSuccessStatusCode) {
				var serialiser = XmlSerialiserFactory.GetXmlSerialiser<T>();
				using var reader = XmlReader.Create(response.Content.ReadAsStreamAsync().Result);
				var xmlNode = serialiser.Deserialize(reader) as IXmlNode<T>;
				var result = xmlNode?.Items;

				if (result != null)
					ApiRequestStoreSession.Store.Save(uri, result.Cast<object>());

				return result ?? Enumerable.Empty<T>();
			}

			throw new ApiError(response.StatusCode, response.Content.ReadAsStringAsync().Result);
		}
	}
}
