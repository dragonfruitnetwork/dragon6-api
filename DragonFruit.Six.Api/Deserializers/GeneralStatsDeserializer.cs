// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System.Collections.Generic;
using System.Linq;
using DragonFruit.Common.Data.Extensions;
using DragonFruit.Six.Api.Containers;
using DragonFruit.Six.Api.Entities;
using DragonFruit.Six.Api.Strings;
using DragonFruit.Six.Api.Utils;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.Api.Deserializers
{
    public static class GeneralStatsDeserializer
    {
        public static ILookup<string, GeneralStats> DeserializeGeneralStats(this JObject jObject)
        {
            var results = jObject[Misc.Results]?.ToObject<Dictionary<string, JObject>>();
            var enumeratedResults = results?.Select(DeserializeGeneralStats) ?? Enumerable.Empty<GeneralStats>();

            return enumeratedResults.ToLookup(x => x.ProfileId);
        }

        private static GeneralStats DeserializeGeneralStats(KeyValuePair<string, JObject> data) => new()
        {
            ProfileId = data.Key,

            #region Playlists

            Casual = new PlaylistStats
            {
                Kills = data.Value.GetUInt(Casual.Kills.ToStatsKey()),
                Deaths = data.Value.GetUInt(Casual.Deaths.ToStatsKey()),

                Wins = data.Value.GetUInt(Casual.Wins.ToStatsKey()),
                Losses = data.Value.GetUInt(Casual.Losses.ToStatsKey()),

                MatchesPlayed = data.Value.GetUInt(Casual.MatchesPlayed.ToStatsKey()),
                Duration = data.Value.GetUInt(Casual.Time.ToStatsKey())
            },

            Training = new PlaylistStats
            {
                Kills = data.Value.GetUInt(Training.Kills.ToStatsKey()),
                Deaths = data.Value.GetUInt(Training.Deaths.ToStatsKey()),

                Wins = data.Value.GetUInt(Training.Wins.ToStatsKey()),
                Losses = data.Value.GetUInt(Training.Losses.ToStatsKey()),

                Duration = data.Value.GetUInt(Training.Time.ToStatsKey()),
                MatchesPlayed = data.Value.GetUInt(Training.MatchesPlayed.ToStatsKey())
            },

            Ranked = new PlaylistStats
            {
                Kills = data.Value.GetUInt(Ranked.Kills.ToStatsKey()),
                Deaths = data.Value.GetUInt(Ranked.Deaths.ToStatsKey()),

                Wins = data.Value.GetUInt(Ranked.Wins.ToStatsKey()),
                Losses = data.Value.GetUInt(Ranked.Losses.ToStatsKey()),

                Duration = data.Value.GetUInt(Ranked.Time.ToStatsKey()),
                MatchesPlayed = data.Value.GetUInt(Ranked.MatchesPlayed.ToStatsKey()),
            },

            Overall = new PlaylistStats
            {
                Kills = data.Value.GetUInt(General.Kills.ToStatsKey()),
                Deaths = data.Value.GetUInt(General.Deaths.ToStatsKey()),

                Wins = data.Value.GetUInt(General.Wins.ToStatsKey()),
                Losses = data.Value.GetUInt(General.Losses.ToStatsKey()),

                Duration = data.Value.GetUInt(General.Time.ToStatsKey()),
                MatchesPlayed = data.Value.GetUInt(General.MatchesPlayed.ToStatsKey())
            },

            #endregion

            #region Modes

            Bomb = new BombModeStats
            {
                Wins = data.Value.GetUInt(Modes.Bomb.Wins.ToStatsKey()),
                Losses = data.Value.GetUInt(Modes.Bomb.Losses.ToStatsKey()),

                Highscore = data.Value.GetUInt(Modes.Bomb.Highscore.ToStatsKey()),

                Duration = data.Value.GetUInt(Modes.Bomb.Time.ToStatsKey()),
                MatchesPlayed = data.Value.GetUInt(Modes.Bomb.MatchesPlayed.ToStatsKey())
            },

            Hostage = new HostageModeStats
            {
                Wins = data.Value.GetUInt(Modes.Hostage.Wins.ToStatsKey()),
                Losses = data.Value.GetUInt(Modes.Hostage.Losses.ToStatsKey()),

                Highscore = data.Value.GetUInt(Modes.Hostage.Highscore.ToStatsKey()),

                Duration = data.Value.GetUInt(Modes.Hostage.Time.ToStatsKey()),
                MatchesPlayed = data.Value.GetUInt(Modes.Hostage.MatchesPlayed.ToStatsKey()),

                Rescues = data.Value.GetUInt(Modes.Hostage.Rescues.ToStatsKey()),
                Defenses = data.Value.GetUInt(Modes.Hostage.Defenses.ToStatsKey())
            },

            Secure = new SecureModeStats
            {
                Wins = data.Value.GetUInt(Modes.Secure.Wins.ToStatsKey()),
                Losses = data.Value.GetUInt(Modes.Secure.Losses.ToStatsKey()),

                Highscore = data.Value.GetUInt(Modes.Secure.Highscore.ToStatsKey()),

                Duration = data.Value.GetUInt(Modes.Secure.Time.ToStatsKey()),
                MatchesPlayed = data.Value.GetUInt(Modes.Secure.MatchesPlayed.ToStatsKey()),

                Aggressions = data.Value.GetUInt(Modes.Secure.Aggressions.ToStatsKey()),
                Defenses = data.Value.GetUInt(Modes.Secure.Defenses.ToStatsKey()),
                Captures = data.Value.GetUInt(Modes.Secure.Captures.ToStatsKey())
            },

            #endregion

            // non-containerised stats
            Barricades = data.Value.GetUInt(General.Barricades.ToStatsKey()),
            Reinforcements = data.Value.GetUInt(General.Reinforcements.ToStatsKey()),
            GadgetsDestroyed = data.Value.GetUInt(General.GadgetsDestroyed.ToStatsKey()),

            Downs = data.Value.GetUInt(General.Downs.ToStatsKey()),
            Revives = data.Value.GetUInt(General.Revives.ToStatsKey()),

            // todo move to killtypes class?
            Penetrations = data.Value.GetUInt(General.Penetrations.ToStatsKey()),
            Headshots = data.Value.GetUInt(General.Headshots.ToStatsKey()),
            Knifes = data.Value.GetUInt(General.Knives.ToStatsKey()),
            BlindKills = data.Value.GetUInt(General.BlindKills.ToStatsKey()),

            Assists = data.Value.GetUInt(General.Assists.ToStatsKey()),
            DownAssists = data.Value.GetUInt(General.DownAssists.ToStatsKey()),
            Suicides = data.Value.GetUInt(General.Suicides.ToStatsKey()),

            ShotsFired = data.Value.GetULong(General.BulletFired.ToStatsKey()),
            ShotsConnected = data.Value.GetULong(General.BulletHit.ToStatsKey()),

            Experience = data.Value.GetULong(General.Experience.ToStatsKey()),
        };
    }
}
