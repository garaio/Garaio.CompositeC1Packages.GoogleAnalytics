using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Garaio.CompositeC1Packages.GoogleAnalytics.Package.Garaio.ConsoleExtensions
{
	public partial class GoogleAnalytics : Page
	{
		/// <summary>
		///     ASP.NET OnLoad Page Lifecycle Event.
		/// </summary>
		/// <param name="e">Die Event-Argumente.</param>
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			SuccessAlert.Visible = false;

			if (!IsPostBack)
			{
				GoogleAnalyticsManager googleAnalyticsManager = new GoogleAnalyticsManager();
				TxtAccount.Text = googleAnalyticsManager.GetAccountId();

				DataBind();
			}
		}

		protected void SaveData(object sender, CommandEventArgs e)
		{
			if (Page.IsValid)
			{
				GoogleAnalyticsManager googleAnalyticsManager = new GoogleAnalyticsManager();
				googleAnalyticsManager.UpdateAccountId(TxtAccount.Text);

				SuccessAlert.Visible = true;
			}
		}
	}
}