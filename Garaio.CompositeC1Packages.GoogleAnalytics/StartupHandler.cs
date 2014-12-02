using System;

using Composite.Core.Application;
using Composite.Data.DynamicTypes;

using Garaio.CompositeC1Packages.GoogleAnalytics.DataTypes;

namespace Garaio.CompositeC1Packages.GoogleAnalytics
{
	[ApplicationStartup]
	public sealed class StartupHandler
	{
		public static void OnBeforeInitialize() { }

		public static void OnInitialized()
		{
			DynamicTypeManager.EnsureCreateStore(typeof(IGoogleAnalyticsConfig));
		}
	}
}
