// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
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

                    MatchesPlayed = json.GetUInt(GeneralCasual.MatchesPlayed),
                    TimePlayed = TimeSpan.FromSeconds(json.GetDouble(GeneralCasual.Time)),
                },

                Training = new ModeStatsContainer
                {
                    Kills = json.GetUInt(GeneralTraining.Kills),
                    Deaths = json.GetUInt(GeneralTraining.Deaths),
                    Kd = json.GetFloat(GeneralTraining.Kills, 1) / json.GetFloat(GeneralTraining.Deaths, 1),

                    Wins = json.GetUInt(GeneralTraining.Wins),
                    Losses = json.GetUInt(GeneralTraining.Losses),
                    Wl = json.GetFloat(GeneralTraining.Wins, 1) / json.GetFloat(GeneralTraining.Losses, 1),

                    TimePlayed = TimeSpan.FromSeconds(json.GetDouble(GeneralTraining.Time)),
                    MatchesPlayed = json.GetUInt(GeneralTraining.Wins) + json.GetUInt(GeneralTraining.Losses)
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
                    Kills = json.GetUInt(OverallMultiplayer.Kills),
                    Deaths = json.GetUInt(OverallMultiplayer.Deaths),
                    Kd = json.GetFloat(OverallMultiplayer.Kills, 1) / json.GetFloat(OverallMultiplayer.Deaths, 1),

                    Wins = json.GetUInt(OverallMultiplayer.Wins),
                    Losses = json.GetUInt(OverallMultiplayer.Losses),
                    Wl = json.GetFloat(OverallMultiplayer.Wins, 1) / json.GetFloat(OverallMultiplayer.Losses, 1),

                    TimePlayed = TimeSpan.FromSeconds(json.GetDouble(OverallMultiplayer.Time)),
                    //matches played set at the bottom...
                },

                Highscores = new HighScoreContainer
                {
                    Secure = json.GetInt(Highscores.Secure),
                    Bomb = json.GetInt(Highscores.Bomb),
                    Hostage = json.GetInt(Highscores.Hostage),
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
