// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System;
using System.Linq;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Mods;
using osu.Game.Rulesets.Objects;
using osu.Game.Rulesets.Osu.Objects;
using osu.Game.Rulesets.Osu.Utils;

namespace osu.Game.Rulesets.Osu.Mods
{
    public class OsuModNothing : ModNothing
    {
        public override double ScoreMultiplier => UsesDefaultConfiguration ? 5.00 : 1;
        public override Type[] IncompatibleMods => base.IncompatibleMods.Concat(new[] { typeof(OsuModHardRock), typeof(OsuModDifficultyAdjust), typeof(OsuModEasy) }).ToArray();
        public override void ApplyToDifficulty(BeatmapDifficulty difficulty)
        {
            base.ApplyToDifficulty(difficulty);

            difficulty.OverallDifficulty = Math.Min(difficulty.OverallDifficulty * ADJUST_RATIO, 10.0f);
            difficulty.CircleSize = Math.Min(difficulty.CircleSize * 0.2f, 50.0f); // CS uses a custom 1.3 ratio.
            difficulty.ApproachRate = Math.Min(difficulty.ApproachRate * ADJUST_RATIO, 10.0f);
        }
    }
}
