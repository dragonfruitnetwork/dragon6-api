// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using DragonFruit.Common.Data.Extensions;
using DragonFruit.Six.API.Data.Containers;
using DragonFruit.Six.API.Data.Strings;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.API.Data.Deserializers
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

                Casual = new PlaylistStatsContainer
                {
                    Kills = json.GetUInt(GeneralCasual.Kills),
                    Deaths = json.GetUInt(GeneralCasual.Deaths),

                    Wins = json.GetUInt(GeneralCasual.Wins),
                    Losses = json.GetUInt(GeneralCasual.Losses),

                    MatchesPlayed = json.GetUInt(GeneralCasual.MatchesPlayed),
                    Duration = json.GetUInt(GeneralCasual.Time),
                },

                Training = new PlaylistStatsContainer
                {
                    Kills = json.GetUInt(GeneralTraining.Kills),
                    Deaths = json.GetUInt(GeneralTraining.Deaths),

                    Wins = json.GetUInt(GeneralTraining.Wins),
                    Losses = json.GetUInt(GeneralTraining.Losses),

                    Duration = json.GetUInt(GeneralTraining.Time),
                    MatchesPlayed = json.GetUInt(GeneralTraining.MatchesPlayed)
                },

                Ranked = new PlaylistStatsContainer
                {
                    Kills = json.GetUInt(GeneralRanked.Kills),
                    Deaths = json.GetUInt(GeneralRanked.Deaths),

                    Wins = json.GetUInt(GeneralRanked.Wins),
                    Losses = json.GetUInt(GeneralRanked.Losses),

                    Duration = json.GetUInt(GeneralRanked.Time),
                    MatchesPlayed = json.GetUInt(GeneralRanked.MatchesPlayed),
                },

                Overall = new PlaylistStatsContainer
                {
                    Kills = json.GetUInt(OverallMultiplayer.Kills),
                    Deaths = json.GetUInt(OverallMultiplayer.Deaths),

                    Wins = json.GetUInt(OverallMultiplayer.Wins),
                    Losses = json.GetUInt(OverallMultiplayer.Losses),

                    Duration = json.GetUInt(OverallMultiplayer.Time),
                    MatchesPlayed = json.GetUInt(OverallMultiplayer.MatchesPlayed)
                },

                #endregion

                #region Modes

                Bomb = new ModeStatsContainer
                {
                    Wins = json.GetUInt(ModeBomb.Wins),
                    Losses = json.GetUInt(ModeBomb.Losses),

                    Highscore = json.GetUInt(ModeBomb.Highscore),

                    Duration = json.GetUInt(ModeBomb.Time),
                    MatchesPlayed = json.GetUInt(ModeBomb.MatchesPlayed)
                },

                Hostage = new ModeStatsContainer
                {
                    Wins = json.GetUInt(ModeHostage.Wins),
                    Losses = json.GetUInt(ModeHostage.Losses),

                    Highscore = json.GetUInt(ModeHostage.Highscore),

                    Duration = json.GetUInt(ModeHostage.Time),
                    MatchesPlayed = json.GetUInt(ModeHostage.MatchesPlayed)
                },

                Secure = new ModeStatsContainer
                {
                    Wins = json.GetUInt(ModeSecure.Wins),
                    Losses = json.GetUInt(ModeSecure.Losses),

                    Highscore = json.GetUInt(ModeSecure.Highscore),

                    Duration = json.GetUInt(ModeSecure.Time),
                    MatchesPlayed = json.GetUInt(ModeSecure.MatchesPlayed)
                },

                #endregion

                // non-containerised stats
                Barricades = json.GetUInt(General.Barricades),
                Reinforcements = json.GetUInt(General.Reinforcements),
                Downs = json.GetUInt(General.Downs),
                Revives = json.GetUInt(General.Revives),

                // todo move to killtypes class?
                Penetrations = json.GetUInt(General.Penetrations),
                Headshots = json.GetUInt(General.Headshots),
                Knifes = json.GetUInt(General.Knives),
                Assists = json.GetUInt(General.Assists),
                Suicides = json.GetUInt(General.Suicides),
                ShotsFired = json.GetLong(General.BulletFired),
                ShotsConnected = json.GetLong(General.BulletHit)
            };

            return result;
        }
    }
}
