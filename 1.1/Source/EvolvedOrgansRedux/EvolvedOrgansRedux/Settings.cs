namespace EvolvedOrgansRedux {
    public class Settings : Verse.ModSettings {
        public bool CombatibilitySwitchEorVersionMidSave;
        public bool BodyPartAffinity;
        public override void ExposeData() {
            Verse.Scribe_Values.Look(ref CombatibilitySwitchEorVersionMidSave, "CombatibilitySwitchEORVersionMidSave");
            Verse.Scribe_Values.Look(ref BodyPartAffinity, "BodyPartAffinity");
            base.ExposeData();
        }
    }
    public class EvolvedOrgansReduxSettings : Verse.Mod {
        Settings settings;
        public EvolvedOrgansReduxSettings(Verse.ModContentPack content) : base(content) {
            this.settings = GetSettings<Settings>();
        }
        public override void DoSettingsWindowContents(UnityEngine.Rect inRect) {
            Verse.Listing_Standard listingStandard = new Verse.Listing_Standard();
            listingStandard.Begin(inRect);
            listingStandard.Label("Check this option if you are switching from another EOR Version to this one in the middle of a save. Please uncheck this option before starting a new save. The game has to be restarted for this change to take effect.");
            listingStandard.Gap();
            listingStandard.CheckboxLabeled("CombatibilitySwitchEORVersionMidSave", ref settings.CombatibilitySwitchEorVersionMidSave);
            listingStandard.GapLine();
            listingStandard.Label("Check this option if you want to put archotech arms on lower shoulders or additional non-Evor lungs into your body. The game has to be restarted for this change to take effect.");
            listingStandard.Gap();
            listingStandard.CheckboxLabeled("BodyPartAffinity", ref settings.BodyPartAffinity);
            listingStandard.End();
        }
        public override string SettingsCategory() {
            return "EvolvedOrgansRedux";
        }
    }
}