namespace irish_rail_api.Common.Access.RequestStore {
	public static class ApiRequestStoreSession {
		private static readonly Lazy<ApiRequestStore> instance = new(() => new ApiRequestStore(storeRetentionLimit: RetentionPolicy), isThreadSafe: true);

		public static bool IsEnabled { get; set; }

		public static int RetentionPolicy { get; set; }

		public static ApiRequestStore Store => instance.Value;
	}
}
