// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Common.Data.Extensions;
using DragonFruit.Six.API.Data.Containers;
using DragonFruit.Six.API.Data.Strings;
using DragonFruit.Six.API.Utils;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.API.Data.Deserializers
{
    public static class ClassicStatsDeserializer
    {
        public static ClassicStats DeserializeClassicStatsFor(this JObject jObject, string guid)
        {
            // try to get the user but if there is nothing return null
            var json = jObject[Misc.Results]?[guid] as JObject;

            if (json == null)
                return null;

            var result = new ClassicStats
            {
                Guid = guid,

                #region Playlists

                Casual = new PlaylistStats
                {
                    Kills = json.GetUInt(ClassicCasual.Kills.ToStatsKey()),
                    Deaths = json.GetUInt(ClassicCasual.Deaths.ToStatsKey()),

                    Wins = json.GetUInt(ClassicCasual.Wins.ToStatsKey()),
                    Losses = json.GetUInt(ClassicCasual.Losses.ToStatsKey()),

                    MatchesPlayed = json.GetUInt(ClassicCasual.MatchesPlayed.ToStatsKey()),
                    Duration = json.GetUInt(ClassicCasual.Time.ToStatsKey())
                },

                Training = new PlaylistStats
                {
                    Kills = json.GetUInt(ClassicTraining.Kills.ToStatsKey()),
                    Deaths = json.GetUInt(ClassicTraining.Deaths.ToStatsKey()),

                    Wins = json.GetUInt(ClassicTraining.Wins.ToStatsKey()),
                    Losses = json.GetUInt(ClassicTraining.Losses.ToStatsKey()),

                    Duration = json.GetUInt(ClassicTraining.Time.ToStatsKey()),
                    MatchesPlayed = json.GetUInt(ClassicTraining.MatchesPlayed.ToStatsKey())
                },

                Ranked = new PlaylistStats
                {
                    Kills = json.GetUInt(ClassicRanked.Kills.ToStatsKey()),
                    Deaths = json.GetUInt(ClassicRanked.Deaths.ToStatsKey()),

                    Wins = json.GetUInt(ClassicRanked.Wins.ToStatsKey()),
                    Losses = json.GetUInt(ClassicRanked.Losses.ToStatsKey()),

                    Duration = json.GetUInt(ClassicRanked.Time.ToStatsKey()),
                    MatchesPlayed = json.GetUInt(ClassicRanked.MatchesPlayed.ToStatsKey()),
                },

                Overall = new PlaylistStats
                {
                    Kills = json.GetUInt(Classic.Kills.ToStatsKey()),
                    Deaths = json.GetUInt(Classic.Deaths.ToStatsKey()),

                    Wins = json.GetUInt(Classic.Wins.ToStatsKey()),
                    Losses = json.GetUInt(Classic.Losses.ToStatsKey()),

                    Duration = json.GetUInt(Classic.Time.ToStatsKey()),
                    MatchesPlayed = json.GetUInt(Classic.MatchesPlayed.ToStatsKey())
                },

                #endregion

                #region Modes

                Bomb = new BombModeStats
                {
                    Wins = json.GetUInt(ClassicModes.Bomb.Wins.ToStatsKey()),
                    Losses = json.GetUInt(ClassicModes.Bomb.Losses.ToStatsKey()),

                    Highscore = json.GetUInt(ClassicModes.Bomb.Highscore.ToStatsKey()),

                    Duration = json.GetUInt(ClassicModes.Bomb.Time.ToStatsKey()),
                    MatchesPlayed = json.GetUInt(ClassicModes.Bomb.MatchesPlayed.ToStatsKey())
                },

                Hostage = new HostageModeStats
                {
                    Wins = json.GetUInt(ClassicModes.Hostage.Wins.ToStatsKey()),
                    Losses = json.GetUInt(ClassicModes.Hostage.Losses.ToStatsKey()),

                    Highscore = json.GetUInt(ClassicModes.Hostage.Highscore.ToStatsKey()),

                    Duration = json.GetUInt(ClassicModes.Hostage.Time.ToStatsKey()),
                    MatchesPlayed = json.GetUInt(ClassicModes.Hostage.MatchesPlayed.ToStatsKey()),

                    Rescues = json.GetUInt(ClassicModes.Hostage.Rescues.ToStatsKey()),
                    Defenses = json.GetUInt(ClassicModes.Hostage.Defenses.ToStatsKey())
                },

                Secure = new SecureModeStats
                {
                    Wins = json.GetUInt(ClassicModes.Secure.Wins.ToStatsKey()),
                    Losses = json.GetUInt(ClassicModes.Secure.Losses.ToStatsKey()),

                    Highscore = json.GetUInt(ClassicModes.Secure.Highscore.ToStatsKey()),

                    Duration = json.GetUInt(ClassicModes.Secure.Time.ToStatsKey()),
                    MatchesPlayed = json.GetUInt(ClassicModes.Secure.MatchesPlayed.ToStatsKey()),

                    Aggressions = json.GetUInt(ClassicModes.Secure.Aggressions.ToStatsKey()),
                    Defenses = json.GetUInt(ClassicModes.Secure.Defenses.ToStatsKey()),
                    Captures = json.GetUInt(ClassicModes.Secure.Captures.ToStatsKey())
                },

                #endregion

                // non-containerised stats
                Barricades = json.GetUInt(Classic.Barricades.ToStatsKey()),
                Reinforcements = json.GetUInt(Classic.Reinforcements.ToStatsKey()),
                GadgetsDestroyed = json.GetUInt(Classic.GadgetsDestroyed.ToStatsKey()),

                Downs = json.GetUInt(Classic.Downs.ToStatsKey()),
                Revives = json.GetUInt(Classic.Revives.ToStatsKey()),

                // todo move to killtypes class?
                Penetrations = json.GetUInt(Classic.Penetrations.ToStatsKey()),
                Headshots = json.GetUInt(Classic.Headshots.ToStatsKey()),
                Knifes = json.GetUInt(Classic.Knives.ToStatsKey()),
                BlindKills = json.GetUInt(Classic.BlindKills.ToStatsKey()),

                Assists = json.GetUInt(Classic.Assists.ToStatsKey()),
                DownAssists = json.GetUInt(Classic.DownAssists.ToStatsKey()),
                Suicides = json.GetUInt(Classic.Suicides.ToStatsKey()),

                ShotsFired = json.GetULong(Classic.BulletFired.ToStatsKey()),
                ShotsConnected = json.GetULong(Classic.BulletHit.ToStatsKey()),

                Experience = json.GetULong(Classic.Experience.ToStatsKey()),
                DistanceTravelled = json.GetULong(Classic.DistanceTravelled.ToStatsKey())
            };

            return result;
        }
    }
}
