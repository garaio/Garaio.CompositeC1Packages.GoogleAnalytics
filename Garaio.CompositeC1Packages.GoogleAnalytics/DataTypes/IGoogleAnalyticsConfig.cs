using System;

using Composite.Data;
using Composite.Data.Hierarchy;
using Composite.Data.Hierarchy.DataAncestorProviders;
using Composite.Data.ProcessControlled.ProcessControllers.GenericPublishProcessController;
using Composite.Data.Types;

namespace Garaio.CompositeC1Packages.GoogleAnalytics.DataTypes
{
	[Title("Google Analytics Account")]
	[AutoUpdateble]
	[DataAncestorProvider(typeof(NoAncestorDataAncestorProvider))]
	[KeyPropertyName("Id")]
	[LabelPropertyName("AccountId")]
	[DataScope(DataScopeIdentifier.PublicName)]
	[PublishProcessControllerType(typeof(GenericPublishProcessController))]
	[ImmutableTypeId("{DDA96BBF-F050-4B87-ADE8-6053BCFA7514}")]
	public interface IGoogleAnalyticsConfig : IData
	{
		[StoreFieldType(PhysicalStoreFieldType.Guid)]
		[ImmutableFieldId("{B8132C63-5028-449F-AF0F-99160F65B326}")]
		Guid Id { get; set; }

		[StoreFieldType(PhysicalStoreFieldType.String, 16)]
		[ImmutableFieldId("{1687AAFA-EF32-4479-B20A-6D21DE5E27E3}")]
		string AccountId { get; set; }

		[StoreFieldType(PhysicalStoreFieldType.Guid, IsNullable = true)]
		[ImmutableFieldId("943E0EBE-DAF5-4F3B-B858-BA4EEBC2F0F4")]
		[ForeignKey(typeof(IPage), "Id", AllowCascadeDeletes = false, NullReferenceValue = null, NullReferenceValueType = typeof(Guid?))]
		[FormRenderingProfile(Label = "Google Analytics Einstellungenseite", HelpText = "Die C1 Seite wo man die Google Analytics Einstellungen vergeben kann.")]
		Guid? PageId { get; set; }
	}
}
