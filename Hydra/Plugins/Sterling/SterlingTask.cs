namespace StockSharp.Hydra.Sterling
{
	using System;
	using System.ComponentModel;

	using Ecng.Xaml;

	using StockSharp.Hydra.Core;
	using StockSharp.Localization;
	using StockSharp.Sterling;

	using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

	[Category(TaskCategories.American)]
	[DisplayNameLoc(_sourceName)]
	[DescriptionLoc(LocalizedStrings.Str2281ParamsKey, _sourceName)]
	class SterlingTask : ConnectorHydraTask<SterlingTrader>
	{
		private const string _sourceName = "Sterling";

		[TaskSettingsDisplayName(_sourceName)]
		[CategoryOrder(_sourceName, 0)]
		private sealed class SterlingSettings : ConnectorHydraTaskSettings
		{
			public SterlingSettings(HydraTaskSettings settings)
				: base(settings)
			{
			}
		}

		public SterlingTask()
		{
		}

		public override Uri Icon
		{
			get { return "sterling_logo.png".GetResourceUrl(GetType()); }
		}

		private SterlingSettings _settings;

		public override HydraTaskSettings Settings
		{
			get { return _settings; }
		}

		protected override MarketDataConnector<SterlingTrader> CreateConnector(HydraTaskSettings settings)
		{
			_settings = new SterlingSettings(settings);

			if (settings.IsDefault)
			{
			}

			return new MarketDataConnector<SterlingTrader>(EntityRegistry.Securities, this, () => new SterlingTrader());
		}
	}
}