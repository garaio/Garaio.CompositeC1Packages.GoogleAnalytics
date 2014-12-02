using System;

using Composite.Data;
using Composite.Data.Hierarchy;
using Composite.Data.Hierarchy.DataAncestorProviders;
using Composite.Data.ProcessControlled.ProcessControllers.GenericPublishProcessController;

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
	}
}
