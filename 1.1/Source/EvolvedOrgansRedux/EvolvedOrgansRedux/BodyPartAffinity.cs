namespace EvolvedOrgansRedux {
    public class BodyPartAffinity {
        public BodyPartAffinity(string nameOfThisMod) {
            //Put the new RecipeDefs first into this list and add them later
            System.Collections.Generic.List<Verse.RecipeDef> RecipesToAdd = new System.Collections.Generic.List<Verse.RecipeDef>();
            foreach (Verse.RecipeDef rd in Verse.DefDatabase<Verse.RecipeDef>.AllDefs) {
                try {
                    if (rd.IsSurgery) {
                        //There are three BodyParts that are added by Evor that I would think could use the affinity.
                        if (rd.modContentPack.Name != nameOfThisMod) {
                            //Lower Shoulders for arms.
                            if (rd.appliedOnFixedBodyParts.Contains(Verse.DefDatabase<Verse.BodyPartDef>.GetNamed("Shoulder"))) {
                                RecipesToAdd.Add(CopyRecipeDef(rd, "LowerShoulder"));
                            }
                            //Chest Cavity Left for lungs
                            else if (rd.appliedOnFixedBodyParts.Contains(Verse.DefDatabase<Verse.BodyPartDef>.GetNamed("Lung"))) {
                                RecipesToAdd.Add(CopyRecipeDef(rd, "BodyCavity1"));
                            }
                            //Chest Cavity Right for Hearts
                            else if (rd.appliedOnFixedBodyParts.Contains(Verse.DefDatabase<Verse.BodyPartDef>.GetNamed("Heart"))) {
                                RecipesToAdd.Add(CopyRecipeDef(rd, "BodyCavity2"));
                            }
                        }
                    }
                } catch {
                    Verse.Log.Error("BodyPartAffinity Exception: " + rd.defName);
                }
            }
            //Add the RecipeDefs into the actual list the game looks up.
            foreach (Verse.RecipeDef rd in RecipesToAdd) {
                Verse.DefDatabase<Verse.RecipeDef>.Add(rd);
                Verse.DefDatabase<Verse.RecipeDef>.GetNamed(rd.defName).ResolveReferences();
            }
        }
        //Copy the Surgery Recipe the basegame or mod uses to install the bodypart into their usual appliedOnFixedBodyParts.
        //Change the appliedOnFixedBodyParts it gets installed into and add the researchPrerequisite
        private Verse.RecipeDef CopyRecipeDef(Verse.RecipeDef rd, string bodyPart) {
            return new Verse.RecipeDef {
                defName = "Evor_" + rd.defName,
                label = rd.label,
                description = rd.description,
                workerClass = rd.workerClass,
                jobString = rd.jobString,
                workAmount = rd.workAmount,
                skillRequirements = rd.skillRequirements,
                recipeUsers = rd.recipeUsers,
                ingredients = rd.ingredients,
                fixedIngredientFilter = rd.fixedIngredientFilter,
                appliedOnFixedBodyParts = new System.Collections.Generic.List<Verse.BodyPartDef> { Verse.DefDatabase<Verse.BodyPartDef>.GetNamed(bodyPart) },
                addsHediff = rd.addsHediff,
                researchPrerequisite = Verse.DefDatabase<Verse.ResearchProjectDef>.GetNamed("EVOR_Research_Limbs3"),
                descriptionHyperlinks = rd.descriptionHyperlinks
            };
        }
    }
}
