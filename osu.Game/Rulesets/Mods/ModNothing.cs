// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Localisation;
using osu.Game.Beatmaps;
using osu.Game.Graphics;

namespace osu.Game.Rulesets.Mods
{
    public abstract class ModNothing : Mod, IApplicableToDifficulty
    {
        public override string Name => "Nothing";
        public override string Acronym => "NG";
        public override IconUsage? Icon => OsuIcon.ModHardRock;
        public override ModType Type => ModType.Conversion;
        public override LocalisableString Description => "Everything just got a bit of nothing...";
        public override Type[] IncompatibleMods => new[] { typeof(ModEasy), typeof(ModHardRock), typeof(ModDifficultyAdjust) };
        public override bool Ranked => UsesDefaultConfiguration;
        public override bool ValidForFreestyleAsRequiredMod => true;

        protected const float ADJUST_RATIO = 1.4f;

        public virtual void ApplyToDifficulty(BeatmapDifficulty difficulty)
        {
            difficulty.DrainRate = Math.Min(difficulty.DrainRate * ADJUST_RATIO, 10.0f);
        }
    }
}
