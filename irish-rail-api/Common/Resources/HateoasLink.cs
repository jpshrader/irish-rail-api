namespace irish_rail_api.Common.Resources {
	public class HateoasLink {
		public const string SELF = "self";
		public const string SELF_DETAILED = "self_detailed";

		public string Href { get; set; }

		public string Rel { get; set; }

		public string Method { get; set; }

		public HateoasLink(string href, string rel, HateoasMethod method) {
			Href = href;
			Rel = rel;
			Method = method.ToString();
		}

		public static HateoasLink BuildGetLink(string href, string rel, params string[] routeArgs) {
			return new HateoasLink(SpliceArgsIntoRoute(href, routeArgs), rel, HateoasMethod.GET);
		}

		private static string SpliceArgsIntoRoute(string href, params string[] routeArgs) {
			for (var i = 0; i < routeArgs.Length; i++) {
				href = href.Replace(GetHrefSegmentToReplace(href), routeArgs[i]);
			}

			return href;
		}

		private static string GetHrefSegmentToReplace(string href) {
			var openBrace = href.IndexOf('{');
			var closedBrace = href.IndexOf('}') + 1;

			return href[openBrace..closedBrace];
		}
	}
}