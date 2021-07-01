// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Linq;
using DragonFruit.Common.Data.Extensions;
using DragonFruit.Six.Api.Containers;
using DragonFruit.Six.Api.Entities;
using DragonFruit.Six.Api.Strings;
using DragonFruit.Six.Api.Strings.Stats;
using DragonFruit.Six.Api.Strings.Stats.Modes;
using DragonFruit.Six.Api.Utils;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.Api.Deserializers
{
    public static class GeneralStatsDeserializer
    {
        public static ILookup<string, GeneralStats> DeserializeGeneralStats(this JObject json)
        {
            var results = (json[Misc.Results] as JObject)?.Properties().Select(DeserializeInternal);
            results ??= Enumerable.Empty<GeneralStats>();

            return results.ToLookup(x => x.ProfileId);
        }

        private static GeneralStats DeserializeInternal(JProperty data)
        {
            var property = (JObject)data.Value;

            return new GeneralStats
            {
                ProfileId = data.Name,

                #region Playlists

                Casual = new PlaylistStats
                {
                    Kills = property.GetUInt(Casual.Kills.ToStatsKey()),
                    Deaths = property.GetUInt(Casual.Deaths.ToStatsKey()),

                    Wins = property.GetUInt(Casual.Wins.ToStatsKey()),
                    Losses = property.GetUInt(Casual.Losses.ToStatsKey()),

                    MatchesPlayed = property.GetUInt(Casual.MatchesPlayed.ToStatsKey()),
                    Duration = property.GetUInt(Casual.Time.ToStatsKey())
                },

                Training = new PlaylistStats
                {
                    Kills = property.GetUInt(Training.Kills.ToStatsKey()),
                    Deaths = property.GetUInt(Training.Deaths.ToStatsKey()),

                    Wins = property.GetUInt(Training.Wins.ToStatsKey()),
                    Losses = property.GetUInt(Training.Losses.ToStatsKey()),

                    Duration = property.GetUInt(Training.Time.ToStatsKey()),
                    MatchesPlayed = property.GetUInt(Training.MatchesPlayed.ToStatsKey())
                },

                Ranked = new PlaylistStats
                {
                    Kills = property.GetUInt(Ranked.Kills.ToStatsKey()),
                    Deaths = property.GetUInt(Ranked.Deaths.ToStatsKey()),

                    Wins = property.GetUInt(Ranked.Wins.ToStatsKey()),
                    Losses = property.GetUInt(Ranked.Losses.ToStatsKey()),

                    Duration = property.GetUInt(Ranked.Time.ToStatsKey()),
                    MatchesPlayed = property.GetUInt(Ranked.MatchesPlayed.ToStatsKey()),
                },

                Overall = new PlaylistStats
                {
                    Kills = property.GetUInt(General.Kills.ToStatsKey()),
                    Deaths = property.GetUInt(General.Deaths.ToStatsKey()),

                    Wins = property.GetUInt(General.Wins.ToStatsKey()),
                    Losses = property.GetUInt(General.Losses.ToStatsKey()),

                    Duration = property.GetUInt(General.Time.ToStatsKey()),
                    MatchesPlayed = property.GetUInt(General.MatchesPlayed.ToStatsKey())
                },

                #endregion

                #region Modes

                Bomb = new BombModeStats
                {
                    Wins = property.GetUInt(Bomb.Wins.ToStatsKey()),
                    Losses = property.GetUInt(Bomb.Losses.ToStatsKey()),

                    Highscore = property.GetUInt(Bomb.Highscore.ToStatsKey()),

                    Duration = property.GetUInt(Bomb.Time.ToStatsKey()),
                    MatchesPlayed = property.GetUInt(Bomb.MatchesPlayed.ToStatsKey())
                },

                Hostage = new HostageModeStats
                {
                    Wins = property.GetUInt(Hostage.Wins.ToStatsKey()),
                    Losses = property.GetUInt(Hostage.Losses.ToStatsKey()),

                    Highscore = property.GetUInt(Hostage.Highscore.ToStatsKey()),

                    Duration = property.GetUInt(Hostage.Time.ToStatsKey()),
                    MatchesPlayed = property.GetUInt(Hostage.MatchesPlayed.ToStatsKey()),

                    Rescues = property.GetUInt(Hostage.Rescues.ToStatsKey()),
                    Defenses = property.GetUInt(Hostage.Defenses.ToStatsKey())
                },

                Secure = new SecureModeStats
                {
                    Wins = property.GetUInt(Secure.Wins.ToStatsKey()),
                    Losses = property.GetUInt(Secure.Losses.ToStatsKey()),

                    Highscore = property.GetUInt(Secure.Highscore.ToStatsKey()),

                    Duration = property.GetUInt(Secure.Time.ToStatsKey()),
                    MatchesPlayed = property.GetUInt(Secure.MatchesPlayed.ToStatsKey()),

                    Aggressions = property.GetUInt(Secure.Aggressions.ToStatsKey()),
                    Defenses = property.GetUInt(Secure.Defenses.ToStatsKey()),
                    Captures = property.GetUInt(Secure.Captures.ToStatsKey())
                },

                #endregion

                // non-containerised stats
                Barricades = property.GetUInt(General.Barricades.ToStatsKey()),
                Reinforcements = property.GetUInt(General.Reinforcements.ToStatsKey()),
                GadgetsDestroyed = property.GetUInt(General.GadgetsDestroyed.ToStatsKey()),

                Downs = property.GetUInt(General.Downs.ToStatsKey()),
                Revives = property.GetUInt(General.Revives.ToStatsKey()),

                // todo move to killtypes class?
                Penetrations = property.GetUInt(General.Penetrations.ToStatsKey()),
                Headshots = property.GetUInt(General.Headshots.ToStatsKey()),
                Knifes = property.GetUInt(General.Knives.ToStatsKey()),
                BlindKills = property.GetUInt(General.BlindKills.ToStatsKey()),

                Assists = property.GetUInt(General.Assists.ToStatsKey()),
                DownAssists = property.GetUInt(General.DownAssists.ToStatsKey()),
                Suicides = property.GetUInt(General.Suicides.ToStatsKey()),

                ShotsFired = property.GetULong(General.BulletFired.ToStatsKey()),
                ShotsConnected = property.GetULong(General.BulletHit.ToStatsKey()),

                Experience = property.GetULong(General.Experience.ToStatsKey()),
            };
        }
    }
}
