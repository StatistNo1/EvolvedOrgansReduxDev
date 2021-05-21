namespace EvolvedOrgansRedux {
    class PatchOperationCombatibilitySwitchEorVersionMidSaveUnchecked : Verse.PatchOperationPathed {
		private enum Order {
			Append,
			Prepend
		}

		private Verse.XmlContainer value;

		private PatchOperationCombatibilitySwitchEorVersionMidSaveUnchecked.Order order;

		protected override bool ApplyWorker(System.Xml.XmlDocument xml) {
				System.Xml.XmlNode node = this.value.node;
				bool result = false;

			if (xml.SelectNodes(this.xpath).Count > 0)
				result = true;

			if (!Verse.LoadedModManager.GetMod<EvolvedOrgansReduxSettings>().GetSettings<Settings>().CombatibilitySwitchEorVersionMidSave) {
				foreach (object current in xml.SelectNodes(this.xpath)) {
					System.Xml.XmlNode xmlNode = current as System.Xml.XmlNode;
					if (this.order == PatchOperationCombatibilitySwitchEorVersionMidSaveUnchecked.Order.Append) {
						for (int i = 0; i < node.ChildNodes.Count; i++) {
							xmlNode.AppendChild(xmlNode.OwnerDocument.ImportNode(node.ChildNodes[i], true));
						}
					} else if (this.order == PatchOperationCombatibilitySwitchEorVersionMidSaveUnchecked.Order.Prepend) {
						for (int j = node.ChildNodes.Count - 1; j >= 0; j--) {
							xmlNode.PrependChild(xmlNode.OwnerDocument.ImportNode(node.ChildNodes[j], true));
						}
					}
				}
			}
			return result;
		}
	}
	public class PatchOperationCombatibilitySwitchEorVersionMidSaveChecked : Verse.PatchOperationPathed {
		private enum Order {
			Append,
			Prepend
		}

		private Verse.XmlContainer value;

		private PatchOperationCombatibilitySwitchEorVersionMidSaveChecked.Order order = PatchOperationCombatibilitySwitchEorVersionMidSaveChecked.Order.Prepend;

		protected override bool ApplyWorker(System.Xml.XmlDocument xml) {
			System.Xml.XmlNode node = this.value.node;
			bool result = false;
			if (xml.SelectNodes(this.xpath).Count > 0)
				result = true;
			if (Verse.LoadedModManager.GetMod<EvolvedOrgansReduxSettings>().GetSettings<Settings>().CombatibilitySwitchEorVersionMidSave) {

				foreach (object current in xml.SelectNodes(this.xpath)) {
					result = true;
					System.Xml.XmlNode xmlNode = current as System.Xml.XmlNode;
					System.Xml.XmlNode parentNode = xmlNode.ParentNode;
					if (this.order == PatchOperationCombatibilitySwitchEorVersionMidSaveChecked.Order.Append) {
						for (int i = 0; i < node.ChildNodes.Count; i++) {
							parentNode.InsertAfter(parentNode.OwnerDocument.ImportNode(node.ChildNodes[i], true), xmlNode);
						}
					} else if (this.order == PatchOperationCombatibilitySwitchEorVersionMidSaveChecked.Order.Prepend) {
						for (int j = node.ChildNodes.Count - 1; j >= 0; j--) {
							parentNode.InsertBefore(parentNode.OwnerDocument.ImportNode(node.ChildNodes[j], true), xmlNode);
						}
					}
				}
			}
			return result;
		}
	}
}