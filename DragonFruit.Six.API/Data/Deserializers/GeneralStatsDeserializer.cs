// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Common.Data.Extensions;
using DragonFruit.Six.Api.Entities;
using DragonFruit.Six.Api.Data.Containers;
using DragonFruit.Six.Api.Data.Strings;
using DragonFruit.Six.Api.Utils;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.Api.Data.Deserializers
{
    public static class GeneralStatsDeserializer
    {
        public static GeneralStats DeserializeGeneralStatsFor(this JObject jObject, string guid)
        {
            // try to get the user but if there is nothing return null
            var json = jObject[Misc.Results]?[guid] as JObject;

            if (json == null)
                return null;

            var result = new GeneralStats
            {
                Guid = guid,

                #region Playlists

                Casual = new PlaylistStats
                {
                    Kills = json.GetUInt(Casual.Kills.ToStatsKey()),
                    Deaths = json.GetUInt(Casual.Deaths.ToStatsKey()),

                    Wins = json.GetUInt(Casual.Wins.ToStatsKey()),
                    Losses = json.GetUInt(Casual.Losses.ToStatsKey()),

                    MatchesPlayed = json.GetUInt(Casual.MatchesPlayed.ToStatsKey()),
                    Duration = json.GetUInt(Casual.Time.ToStatsKey())
                },

                Training = new PlaylistStats
                {
                    Kills = json.GetUInt(Training.Kills.ToStatsKey()),
                    Deaths = json.GetUInt(Training.Deaths.ToStatsKey()),

                    Wins = json.GetUInt(Training.Wins.ToStatsKey()),
                    Losses = json.GetUInt(Training.Losses.ToStatsKey()),

                    Duration = json.GetUInt(Training.Time.ToStatsKey()),
                    MatchesPlayed = json.GetUInt(Training.MatchesPlayed.ToStatsKey())
                },

                Ranked = new PlaylistStats
                {
                    Kills = json.GetUInt(Ranked.Kills.ToStatsKey()),
                    Deaths = json.GetUInt(Ranked.Deaths.ToStatsKey()),

                    Wins = json.GetUInt(Ranked.Wins.ToStatsKey()),
                    Losses = json.GetUInt(Ranked.Losses.ToStatsKey()),

                    Duration = json.GetUInt(Ranked.Time.ToStatsKey()),
                    MatchesPlayed = json.GetUInt(Ranked.MatchesPlayed.ToStatsKey()),
                },

                Overall = new PlaylistStats
                {
                    Kills = json.GetUInt(General.Kills.ToStatsKey()),
                    Deaths = json.GetUInt(General.Deaths.ToStatsKey()),

                    Wins = json.GetUInt(General.Wins.ToStatsKey()),
                    Losses = json.GetUInt(General.Losses.ToStatsKey()),

                    Duration = json.GetUInt(General.Time.ToStatsKey()),
                    MatchesPlayed = json.GetUInt(General.MatchesPlayed.ToStatsKey())
                },

                #endregion

                #region Modes

                Bomb = new BombModeStats
                {
                    Wins = json.GetUInt(Modes.Bomb.Wins.ToStatsKey()),
                    Losses = json.GetUInt(Modes.Bomb.Losses.ToStatsKey()),

                    Highscore = json.GetUInt(Modes.Bomb.Highscore.ToStatsKey()),

                    Duration = json.GetUInt(Modes.Bomb.Time.ToStatsKey()),
                    MatchesPlayed = json.GetUInt(Modes.Bomb.MatchesPlayed.ToStatsKey())
                },

                Hostage = new HostageModeStats
                {
                    Wins = json.GetUInt(Modes.Hostage.Wins.ToStatsKey()),
                    Losses = json.GetUInt(Modes.Hostage.Losses.ToStatsKey()),

                    Highscore = json.GetUInt(Modes.Hostage.Highscore.ToStatsKey()),

                    Duration = json.GetUInt(Modes.Hostage.Time.ToStatsKey()),
                    MatchesPlayed = json.GetUInt(Modes.Hostage.MatchesPlayed.ToStatsKey()),

                    Rescues = json.GetUInt(Modes.Hostage.Rescues.ToStatsKey()),
                    Defenses = json.GetUInt(Modes.Hostage.Defenses.ToStatsKey())
                },

                Secure = new SecureModeStats
                {
                    Wins = json.GetUInt(Modes.Secure.Wins.ToStatsKey()),
                    Losses = json.GetUInt(Modes.Secure.Losses.ToStatsKey()),

                    Highscore = json.GetUInt(Modes.Secure.Highscore.ToStatsKey()),

                    Duration = json.GetUInt(Modes.Secure.Time.ToStatsKey()),
                    MatchesPlayed = json.GetUInt(Modes.Secure.MatchesPlayed.ToStatsKey()),

                    Aggressions = json.GetUInt(Modes.Secure.Aggressions.ToStatsKey()),
                    Defenses = json.GetUInt(Modes.Secure.Defenses.ToStatsKey()),
                    Captures = json.GetUInt(Modes.Secure.Captures.ToStatsKey())
                },

                #endregion

                // non-containerised stats
                Barricades = json.GetUInt(General.Barricades.ToStatsKey()),
                Reinforcements = json.GetUInt(General.Reinforcements.ToStatsKey()),
                GadgetsDestroyed = json.GetUInt(General.GadgetsDestroyed.ToStatsKey()),

                Downs = json.GetUInt(General.Downs.ToStatsKey()),
                Revives = json.GetUInt(General.Revives.ToStatsKey()),

                // todo move to killtypes class?
                Penetrations = json.GetUInt(General.Penetrations.ToStatsKey()),
                Headshots = json.GetUInt(General.Headshots.ToStatsKey()),
                Knifes = json.GetUInt(General.Knives.ToStatsKey()),
                BlindKills = json.GetUInt(General.BlindKills.ToStatsKey()),

                Assists = json.GetUInt(General.Assists.ToStatsKey()),
                DownAssists = json.GetUInt(General.DownAssists.ToStatsKey()),
                Suicides = json.GetUInt(General.Suicides.ToStatsKey()),

                ShotsFired = json.GetULong(General.BulletFired.ToStatsKey()),
                ShotsConnected = json.GetULong(General.BulletHit.ToStatsKey()),

                Experience = json.GetULong(General.Experience.ToStatsKey()),
            };

            return result;
        }
    }
}
