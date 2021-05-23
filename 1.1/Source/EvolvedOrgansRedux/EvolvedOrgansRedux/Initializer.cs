﻿using HarmonyLib;
using System.Reflection;

namespace EvolvedOrgansRedux {
    [Verse.StaticConstructorOnStartup]
    public static class Initializer {
        static Initializer() {
            Harmony harmony = new Harmony("EvolvedOrgansRedux");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            new AddDefsForEachModdedRace(harmony.Id);

            if (Verse.LoadedModManager.GetMod<EvolvedOrgansReduxSettings>().GetSettings<Settings>().BodyPartAffinity) {
                new BodyPartAffinity(harmony.Id);
            }
        }
    }
}