using System.Collections.Concurrent;

namespace irish_rail_api.Common.Access.RequestStore {
	public class ApiRequestStore : IApiRequestStore {
		private readonly ConcurrentDictionary<Uri, ApiStoreItem> apiRequestStore;
		private readonly int storeRetentionLimit;

		public ApiRequestStore(int storeRetentionLimit) {
			this.storeRetentionLimit = storeRetentionLimit;
			apiRequestStore = new ConcurrentDictionary<Uri, ApiStoreItem>();
		}

		public IEnumerable<T>? Retrieve<T>(Uri uri) {
			if (apiRequestStore.ContainsKey(uri)) {
				var entry = apiRequestStore[uri];
				if (!entry.IsExpired(storeRetentionLimit)) {
					return entry.Item as IEnumerable<T>;
				} else {
					apiRequestStore.Remove(uri, out _);
				}
			}

			return null;
		}

		public void Save(Uri uri, IEnumerable<object> result) {
			var storeItem = new ApiStoreItem(result);
			if (apiRequestStore.ContainsKey(uri)) {
				apiRequestStore[uri] = storeItem;
			} else {
				apiRequestStore.TryAdd(uri, storeItem);
			}
		}
	}
}