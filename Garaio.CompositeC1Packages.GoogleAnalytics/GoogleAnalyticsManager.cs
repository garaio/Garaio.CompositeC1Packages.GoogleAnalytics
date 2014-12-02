using System;
using System.Configuration;
using System.Linq;

using Composite.Data;

using Garaio.CompositeC1Packages.GoogleAnalytics.DataTypes;

namespace Garaio.CompositeC1Packages.GoogleAnalytics
{
	/// <summary>
	/// Manager Klasse für den Google-Analytics Konfigurationseintrag.
	/// </summary>
	public class GoogleAnalyticsManager : IDisposable
	{
		private readonly DataConnection _dataConnection;

		private readonly bool _isOwnDataConnection;

		/// <summary>
		/// Instanziert einen <see cref="GoogleAnalyticsManager" />.
		/// <remarks>Die DataConnetion wird mittels eines unpublished publication scopes instanziert.</remarks>
		/// </summary>
		public GoogleAnalyticsManager()
		{
			_dataConnection = new DataConnection(PublicationScope.Unpublished);
			_isOwnDataConnection = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Liest die AccountId aus dem <see cref="IGoogleAnalyticsConfig"/> aus und gibt diese zurück.
		/// </summary>
		/// <returns>Liefert die Google-Analytics AccountId.</returns>
		public string GetAccountId()
		{
			IGoogleAnalyticsConfig googleAnalyticsEntry = _dataConnection.Get<IGoogleAnalyticsConfig>().SingleOrDefault();

			if (googleAnalyticsEntry == null)
			{
				googleAnalyticsEntry = DataConnection.New<IGoogleAnalyticsConfig>();
				googleAnalyticsEntry.Id = Guid.NewGuid();
				googleAnalyticsEntry.AccountId = string.Empty;
				_dataConnection.Add(googleAnalyticsEntry);
			}

			return googleAnalyticsEntry.AccountId;
		}

		/// <summary>
		/// Überschreibt eine bestehende <see cref="IGoogleAnalyticsConfig"/> mit der übergebenen Google-Analytics AccountId.
		/// </summary>
		/// <param name="accountId">Die Google-Analytics AccountId.</param>
		/// <exception cref="ConfigurationErrorsException">Wenn keine Google-Analytics Konfiguration gefunden wird.</exception>
		public void UpdateAccountId(string accountId)
		{
			if (accountId == null)
			{
				throw new ArgumentNullException("accountId");
			}

			IGoogleAnalyticsConfig googleAnalyticsEntry = _dataConnection.Get<IGoogleAnalyticsConfig>().SingleOrDefault();

			if (googleAnalyticsEntry == null)
			{
				throw new ConfigurationErrorsException("There is no Google Analytics configuration available.");
			}

			googleAnalyticsEntry.AccountId = accountId;
			_dataConnection.Update(googleAnalyticsEntry);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (_isOwnDataConnection && _dataConnection != null)
				{
					_dataConnection.Dispose();
				}
			}
		}
	}
}
