// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using System.Linq;
using DragonFruit.Common.Storage.Shared;
using DragonFruit.Six.API.Helpers;
using DragonFruit.Six.API.Stats;
using Newtonsoft.Json.Linq;

namespace DragonFruit.Six.API.Processing
{
    public static class Alignments
    {
        public static IEnumerable<AccountInfo> ToAccounts(this JObject jObject)
        {
            var json = JArray.FromObject(jObject[Misc.Profile]);

            foreach (var jToken in json)
            {
                var item = (JObject)jToken;
                yield return new AccountInfo
                {
                    PlayerName = item.GetString(Accounts.Name),
                    Guid = item.GetString(Accounts.ProfileIdentifier),
                    Platform = PlatformParser.PlatformEnumFor(item.GetString(Accounts.Platform))
                };
            }
        }

        public static GeneralStats ToGeneralStats(this JObject jObject, string guid)
        {
            if (jObject == null)
            {
                return new GeneralStats();
            }

            var json = (JObject)jObject[Misc.Results][guid];

            return new GeneralStats
            {
                Guid = guid,

                // Casual
                CasualKills = json.GetUInt(GeneralCasual.Kills),
                CasualDeaths = json.GetUInt(GeneralCasual.Deaths),
                CasualKd = json.GetFloat(GeneralCasual.Kills, 1) / json.GetFloat(GeneralCasual.Deaths, 1),

                CasualWins = json.GetUInt(GeneralCasual.Wins),
                CasualLosses = json.GetUInt(GeneralCasual.Losses),
                CasualWl = json.GetFloat(GeneralCasual.Wins, 1) / json.GetFloat(GeneralCasual.Losses, 1),

                CasualMatchesPlayed = json.GetUInt(GeneralCasual.Time),

                // General
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
                ShotsConnected = json.GetLong(General.BulletHit),

                // Terrorist Hunt
                HuntKills = json.GetUInt(GeneralPvE.Kills),
                HuntDeaths = json.GetUInt(GeneralPvE.Deaths),
                HuntKd = json.GetFloat(GeneralPvE.Kills, 1) / json.GetFloat(GeneralPvE.Deaths, 1),

                HuntWins = json.GetUInt(GeneralPvE.Wins),
                HuntLosses = json.GetUInt(GeneralPvE.Losses),
                HuntWl = json.GetFloat(GeneralPvE.Wins, 1) / json.GetFloat(GeneralPvE.Losses, 1),

                // Gamemodes
                HiScoreSecure = json.GetUInt(GeneralModeSpecifics.Secure),
                HiScoreBomb = json.GetUInt(GeneralModeSpecifics.Bomb),
                HiScoreHostage = json.GetUInt(GeneralModeSpecifics.Hostage),

                // Time Played
                TimePlayedCasual = TimeSpan.FromSeconds(json.GetDouble(GeneralCasual.Time)),
                TimePlayedTHunt = TimeSpan.FromSeconds(json.GetDouble(GeneralPvE.Time)),
                TimePlayedRanked = TimeSpan.FromSeconds(json.GetDouble(GeneralRanked.Time)),
                TimePlayedGeneral = TimeSpan.FromSeconds(json.GetDouble(OverallPvP.Time)),
                TimePlayedCustom = TimeSpan.FromSeconds(json.GetDouble(GeneralCustomGame.Time)),

                // Ranked
                RankedWins = json.GetUInt(GeneralRanked.Wins),
                RankedLosses = json.GetUInt(GeneralRanked.Losses),
                RankedWl = json.GetFloat(GeneralRanked.Wins, 1) / json.GetFloat(GeneralRanked.Losses, 1),
                RankedMatchesPlayed = json.GetUInt(GeneralRanked.MatchesPlayed),

                RankedKills = json.GetUInt(GeneralRanked.Kills),
                RankedDeaths = json.GetUInt(GeneralRanked.Deaths),
                RankedKd = json.GetFloat(GeneralRanked.Kills, 1) / json.GetFloat(GeneralRanked.Deaths, 1),

                // General (Overall Stats)
                Wins = json.GetUInt(OverallPvP.Wins),
                Losses = json.GetUInt(OverallPvP.Losses),
                Kills = json.GetUInt(OverallPvP.Kills),
                Deaths = json.GetUInt(OverallPvP.Deaths),
                WL = json.GetFloat(OverallPvP.WL)
            };
        }

        public static Season ToSeason(this JObject jObject, string guid)
        {
            var json = (JObject)jObject[Misc.Players][guid];

            return new Season
            {
                Guid = guid,

                SeasonId = json.GetByte(SeasonalRanked.Season),
                Rank = json.GetUInt(SeasonalRanked.Rank),
                MaxRank = json.GetUInt(SeasonalRanked.MaxRank),
                Wins = json.GetUInt(SeasonalRanked.Wins),
                Losses = json.GetUInt(SeasonalRanked.Losses),
                Abandons = json.GetUInt(SeasonalRanked.Abandons),
                MMR = json.GetDouble(SeasonalRanked.MMR),
                MaxMMR = json.GetDouble(SeasonalRanked.MaxMMR)
            };
        }

        public static IEnumerable<Operator> ToOperatorStats(this JObject jObject, string guid, Dictionary<string, string> operatorNameIndex, Dictionary<string, string> operatorIconMap = null)
        {
            var json = (JObject)jObject[Misc.Results][guid];

            foreach (var index in operatorNameIndex.Keys.ToArray())
            {
                var stats = new Operator
                {
                    Guid = guid,

                    Name = operatorNameIndex[index],
                    Index = index,
                    Kills = json.GetUInt(string.Format(OverallOperator.Kills, index)),
                    Deaths = json.GetUInt(string.Format(OverallOperator.Deaths, index)),
                    Wins = json.GetUInt(string.Format(OverallOperator.Wins, index)),
                    Losses = json.GetUInt(string.Format(OverallOperator.Losses, index)),
                    Headshots = json.GetUInt(string.Format(OverallOperator.Headshots, index)),
                    Downs = json.GetUInt(string.Format(OverallOperator.Downs, index)),
                    RoundsPlayed = json.GetUInt(string.Format(OverallOperator.Rounds, index)),
                    KD = json.GetFloat(string.Format(OverallOperator.Kills, index), 1) /
                         json.GetFloat(string.Format(OverallOperator.Deaths, index), 1),
                    WL = json.GetFloat(string.Format(OverallOperator.Wins, index), 1) /
                         json.GetFloat(string.Format(OverallOperator.Losses, index), 1)
                };

                //if a dictionary in the form ID -> op icon url is specified, set the link
                if (operatorIconMap != null)
                {
                    try
                    {
                        stats.ImageURL = operatorIconMap[index];
                    }
                    catch
                    {
                        //cannot find the operator icon index - it's not the end of the world, just continue
                    }
                }

                yield return stats;
            }
        }

        public static IEnumerable<WeaponStats> ToWeaponStats(this JObject jObject, string guid)
        {
            var json = (JObject)jObject[Misc.Results][guid];

            foreach (var index in References.WeaponClasses.Keys)
            {
                yield return new WeaponStats
                {
                    Guid = guid,

                    ClassName = References.WeaponClasses[index],
                    ClassID = index,
                    Kills = json.GetUInt(string.Format(OverallWeapon.Kills, index)),
                    Headshots = json.GetUInt(string.Format(OverallWeapon.Headshots, index)),
                    ShotsFired = json.GetUInt(string.Format(OverallWeapon.ShotsFired, index)),
                    ShotsLanded = json.GetUInt(string.Format(OverallWeapon.ShotsHit, index))
                };
            }
        }
    }
}
