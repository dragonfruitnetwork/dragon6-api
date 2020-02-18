// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

namespace DragonFruit.Six.API.Processing {
  public static class Accounts {
    public static readonly string Name = "nameOnPlatform";
    public static readonly string Platform = "platformType";

    public static readonly string PlatformIdentifier = "idOnPlatform";
    public static readonly string ProfileIdentifier = "profileId";
    public static readonly string UserIdentifier = "userId";
  }

  public static class Misc {
    public static readonly string Results = "results";
    public static readonly string Profile = "profiles";
    public static readonly string Players = "players";
  }

  public static class GeneralCasual {
    public static readonly string Kills = "casualpvp_kills:infinite";
    public static readonly string Deaths = "casualpvp_death:infinite";

    public static readonly string Wins = "casualpvp_matchwon:infinite";
    public static readonly string Losses = "casualpvp_matchlost:infinite";

    public static readonly string MatchesPlayed =
        "casualpvp_matchplayed:infinite";
    public static readonly string Time = "casualpvp_timeplayed:infinite";
  }

  public static class GeneralRanked {
    public static readonly string Kills = "rankedpvp_kills:infinite";
    public static readonly string Deaths = "rankedpvp_death:infinite";

    public static readonly string Wins = "rankedpvp_matchwon:infinite";
    public static readonly string Losses = "rankedpvp_matchlost:infinite";

    public static readonly string MatchesPlayed =
        "rankedpvp_matchplayed:infinite";
    public static readonly string Time = "rankedpvp_timeplayed:infinite";
  }

  public static class SeasonalRanked {
    public static readonly string Season = "season";
    public static readonly string Rank = "rank";
    public static readonly string MaxRank = "max_rank";
    public static readonly string Wins = "wins";
    public static readonly string Losses = "losses";
    public static readonly string Abandons = "abandons";
    public static readonly string MMR = "mmr";
    public static readonly string MaxMMR = "max_mmr";
  }

  public static class GeneralPvE {
    public static readonly string Kills = "generalpve_kills:infinite";
    public static readonly string Deaths = "generalpve_death:infinite";

    public static readonly string Wins = "generalpve_matchwon:infinite";
    public static readonly string Losses = "generalpve_matchlost:infinite";

    // public static readonly string MatchesPlayed = ""; [NOT AVALIABLE - Add
    // Wins and Losses]
    public static readonly string Time = "generalpve_timeplayed:infinite";
  }

  public static class GeneralCustomGame {
    public static readonly string Time = "custompvp_timeplayed:infinite";
  }

  public static class GeneralModeSpecifics {
    public static readonly string Bomb = "plantbombpvp_bestscore:infinite";
    public static readonly string Hostage =
        "rescuehostagepvp_bestscore:infinite";
    public static readonly string Secure = "secureareapvp_bestscore:infinite";
  }

  public static class General {
    public static readonly string Barricades =
        "generalpvp_barricadedeployed:infinite";
    public static readonly string Reinforcements =
        "generalpvp_reinforcementdeploy:infinite";

    public static readonly string Downs = "generalpvp_dbno:infinite";
    public static readonly string Revives = "generalpvp_revive:infinite";

    public static readonly string Headshots = "generalpvp_headshot:infinite";
    public static readonly string Knives = "generalpvp_meleekills:infinite";
    public static readonly string Penetrations =
        "generalpvp_penetrationkills:infinite";

    public static readonly string Assists = "generalpvp_killassists:infinite";
    public static readonly string Suicides = "generalpvp_suicide:infinite";

    public static readonly string BulletFired =
        "generalpvp_bulletfired:infinite";
    public static readonly string BulletHit = "generalpvp_bullethit:infinite";

    public static readonly string Level = "level";
  }

  public static class OverallPvP {
    public static readonly string Kills = "generalpvp_kills:infinite";
    public static readonly string Deaths = "generalpvp_death:infinite";

    public static readonly string Wins = "generalpvp_matchwon:infinite";
    public static readonly string Losses = "generalpvp_matchlost:infinite";
    public static readonly string WL = "generalpvp_matchwlratio:infinite";

    public static readonly string Time = "generalpvp_timeplayed:infinite";
  }

  public static class OverallWeapon {
    public static readonly string Kills = "weapontypepvp_kills:{0}:infinite";
    public static readonly string Headshots =
        "weapontypepvp_headshot:{0}:infinite";
    public static readonly string ShotsFired =
        "weapontypepvp_bulletfired:{0}:infinite";
    public static readonly string ShotsHit =
        "weapontypepvp_bullethit:{0}:infinite";
  }

  public static class OverallOperator {
    public static readonly string Kills = "operatorpvp_roundwon:{0}:infinite";
    public static readonly string Deaths = "operatorpvp_roundlost:{0}:infinite";
    public static readonly string Wins = "operatorpvp_kills:{0}:infinite";
    public static readonly string Losses = "operatorpvp_death:{0}:infinite";
    public static readonly string Downs = "operatorpvp_headshot:{0}:infinite";
    public static readonly string Headshots = "operatorpvp_dbno:{0}:infinite";
    public static readonly string Rounds =
        "operatorpvp_roundplayed:{0}:infinite";
    public static readonly string Time = "operatorpvp_timeplayed:{0}:infinite";
  }

  public static class LoginData {
    public static readonly string Sessions = "sessionsCount";
    public static readonly string Guid = "profileId";
    public static readonly string PlatformId = "applicationId";
    public static readonly string FirstLogin = "firstSessionDate";
    public static readonly string LastLogin = "lastSessionDate";
  }
}
