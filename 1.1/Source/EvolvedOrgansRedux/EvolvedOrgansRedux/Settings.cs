namespace EvolvedOrgansRedux {
    public class Settings : Verse.ModSettings {
        public bool CombatibilitySwitchEorVersionMidSave;
        public override void ExposeData() {
            Verse.Scribe_Values.Look(ref CombatibilitySwitchEorVersionMidSave, "CombatibilitySwitchEORVersionMidSave");
            base.ExposeData();
        }
    }
    public class EvolvedOrgansReduxSettings : Verse.Mod {
        Settings SettingsCombatibilitySwitchEorVersionMidSave;
        public EvolvedOrgansReduxSettings(Verse.ModContentPack content) : base(content) {
            this.SettingsCombatibilitySwitchEorVersionMidSave = GetSettings<Settings>();
        }
        public override void DoSettingsWindowContents(UnityEngine.Rect inRect) {
            
            Verse.Listing_Standard listingStandard = new Verse.Listing_Standard();
             listingStandard.Begin(inRect);
            listingStandard.Label("Check this option if you are switching from another EOR Version to this one in the middle of a save. Please uncheck this option before starting a new save.");
            listingStandard.End();
            Verse.Listing_Standard listingStandard2 = new Verse.Listing_Standard();
            listingStandard2.Begin(inRect);
            listingStandard2.CheckboxLabeled("", ref SettingsCombatibilitySwitchEorVersionMidSave.CombatibilitySwitchEorVersionMidSave);
            listingStandard2.End();
        }
        public override string SettingsCategory() {
            return "EvolvedOrgansRedux";
        }
    }
}