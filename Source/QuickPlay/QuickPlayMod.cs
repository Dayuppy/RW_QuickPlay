using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;
using UnityEngine;

namespace QuickPlay
{
    public class QuickPlaySettings : ModSettings
    {
        /// <summary>
        /// The three settings our mod has.
        /// </summary>
        public bool exampleBool;
        public float exampleFloat = 200f;
        public List<Pawn> exampleListOfPawns = new List<Pawn>();

        /// <summary>
        /// The part that writes our settings to file. Note that saving is by ref.
        /// </summary>
        public override void ExposeData()
        {
            Scribe_Values.Look(ref exampleBool, "exampleBool");
            Scribe_Values.Look(ref exampleFloat, "exampleFloat", 200f);
            Scribe_Collections.Look(ref exampleListOfPawns, "exampleListOfPawns", LookMode.Reference);
            base.ExposeData();
        }
    }
    public class QuickPlayMod : Mod
    {
        /// <summary>
        /// A reference to our settings.
        /// </summary>
        QuickPlaySettings settings;

        /// <summary>
        /// A mandatory constructor which resolves the reference to our settings.
        /// </summary>
        /// <param name="content"></param>
        public QuickPlayMod(ModContentPack content) : base(content)
        {
            this.settings = GetSettings<QuickPlaySettings>();
            Log.Message("Hello World!"); //Outputs "Hello World!" to the dev console.
        }


        /// <summary>
        /// The (optional) GUI part to set your settings.
        /// </summary>
        /// <param name="inRect">A Unity Rect with the size of the settings window.</param>
        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listingStandard = new Listing_Standard();
            listingStandard.Begin(inRect);
            listingStandard.CheckboxLabeled("exampleBoolExplanation", ref settings.exampleBool, "exampleBoolToolTip");
            listingStandard.Label("exampleFloatExplanation");
            settings.exampleFloat = listingStandard.Slider(settings.exampleFloat, 100f, 300f);
            listingStandard.End();
            base.DoSettingsWindowContents(inRect);
        }

        /// <summary>
        /// Override SettingsCategory to show up in the list of settings.
        /// Using .Translate() is optional, but does allow for localisation.
        /// </summary>
        /// <returns>The (translated) mod name.</returns>
        public override string SettingsCategory()
        {
            return "QuickPlayMod".Translate();
        }
    }
}
