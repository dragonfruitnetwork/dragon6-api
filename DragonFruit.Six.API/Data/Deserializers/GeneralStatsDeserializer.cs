// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using DragonFruit.Common.Data.Helpers;
using DragonFruit.Six.API.Data.Containers;
using DragonFruit.Six.API.Data.Strings;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.API.Data.Deserializers
{
    public static class GeneralStatsDeserializer
    {
        public static GeneralStats DeserializeGeneralStatsFor(this JObject jObject, string guid)
        {
            if (jObject == null)
            {
                return new GeneralStats();
            }

            var json = (JObject)jObject[Misc.Results][guid];

            var result = new GeneralStats
            {
                Guid = guid,

                Casual = new ModeStatsContainer
                {
                    Kills = json.GetUInt(GeneralCasual.Kills),
                    Deaths = json.GetUInt(GeneralCasual.Deaths),
                    Kd = json.GetFloat(GeneralCasual.Kills, 1) / json.GetFloat(GeneralCasual.Deaths, 1),

                    Wins = json.GetUInt(GeneralCasual.Wins),
                    Losses = json.GetUInt(GeneralCasual.Losses),
                    Wl = json.GetFloat(GeneralCasual.Wins, 1) / json.GetFloat(GeneralCasual.Losses, 1),

                    MatchesPlayed = json.GetUInt(GeneralCasual.Time),
                    TimePlayed = TimeSpan.FromSeconds(json.GetDouble(GeneralCasual.Time)),
                },

                Training = new ModeStatsContainer
                {
                    Kills = json.GetUInt(GeneralPvE.Kills),
                    Deaths = json.GetUInt(GeneralPvE.Deaths),
                    Kd = json.GetFloat(GeneralPvE.Kills, 1) / json.GetFloat(GeneralPvE.Deaths, 1),

                    Wins = json.GetUInt(GeneralPvE.Wins),
                    Losses = json.GetUInt(GeneralPvE.Losses),
                    Wl = json.GetFloat(GeneralPvE.Wins, 1) / json.GetFloat(GeneralPvE.Losses, 1),

                    TimePlayed = TimeSpan.FromSeconds(json.GetDouble(GeneralPvE.Time)),
                    MatchesPlayed = json.GetUInt(GeneralPvE.Wins) + json.GetUInt(GeneralPvE.Losses)
                },

                Ranked = new ModeStatsContainer
                {
                    Kills = json.GetUInt(GeneralRanked.Kills),
                    Deaths = json.GetUInt(GeneralRanked.Deaths),
                    Kd = json.GetFloat(GeneralRanked.Kills, 1) / json.GetFloat(GeneralRanked.Deaths, 1),

                    Wins = json.GetUInt(GeneralRanked.Wins),
                    Losses = json.GetUInt(GeneralRanked.Losses),
                    Wl = json.GetFloat(GeneralRanked.Wins, 1) / json.GetFloat(GeneralRanked.Losses, 1),

                    TimePlayed = TimeSpan.FromSeconds(json.GetDouble(GeneralRanked.Time)),
                    MatchesPlayed = json.GetUInt(GeneralRanked.MatchesPlayed),
                },

                Overall = new ModeStatsContainer
                {
                    Kills = json.GetUInt(OverallPvP.Kills),
                    Deaths = json.GetUInt(OverallPvP.Deaths),
                    Kd = json.GetFloat(OverallPvP.Kills, 1) / json.GetFloat(OverallPvP.Deaths, 1),

                    Wins = json.GetUInt(OverallPvP.Wins),
                    Losses = json.GetUInt(OverallPvP.Losses),
                    Wl = json.GetFloat(OverallPvP.Wins, 1) / json.GetFloat(OverallPvP.Losses, 1),

                    TimePlayed = TimeSpan.FromSeconds(json.GetDouble(OverallPvP.Time)),
                    //matches played set at the bottom...
                },

                Highscores = new HighScoreContainer
                {
                    Secure = json.GetInt(GeneralModeSpecifics.Secure),
                    Bomb = json.GetInt(GeneralModeSpecifics.Bomb),
                    Hostage = json.GetInt(GeneralModeSpecifics.Hostage),
                },

                // Non-Containered Stats
                Barricades = json.GetUInt(General.Barricades),
                Reinforcements = json.GetUInt(General.Reinforcements),

                Downs = json.GetUInt(General.Downs),
                Revives = json.GetUInt(General.Revives),

                Penetrations = json.GetUInt(General.Penetrations),
                Headshots = json.GetUInt(General.Headshots),
                Knifes = json.GetUInt(General.Knives),

                Assists = json.GetUInt(General.Assists),
                Suicides = json.GetUInt(General.Suicides),

                ShotsFired = json.GetLong(General.BulletFired),
                ShotsConnected = json.GetLong(General.BulletHit)
            };

            result.Overall.MatchesPlayed = result.Casual.MatchesPlayed + result.Ranked.MatchesPlayed + result.Training.MatchesPlayed;

            return result;
        }
    }
}
