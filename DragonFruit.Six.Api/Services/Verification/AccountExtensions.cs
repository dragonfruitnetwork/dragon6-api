// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

namespace DragonFruit.Six.Api.Services.Verification
{
    public static class AccountExtensions
    {
        public static string GetName(this Dragon6User dragon6User) => string.IsNullOrEmpty(dragon6User.Title) ? GetName(dragon6User.AccountRole) : dragon6User.Title;
        public static string GetIcon(this Dragon6User dragon6User) => string.IsNullOrEmpty(dragon6User.TitleIcon) ? GetIcon(dragon6User.AccountRole) : dragon6User.TitleIcon;
        public static string GetColor(this Dragon6User dragon6User) => string.IsNullOrEmpty(dragon6User.TitleColour) ? GetColor(dragon6User.AccountRole) : dragon6User.TitleColour;

        /// <summary>
        /// Retrieves the default title for the <see cref="AccountRole"/> provided
        /// </summary>
        public static string GetName(this AccountRole role) => role switch
        {
            AccountRole.BlockedByAdmin => "Account blocked by admin",
            AccountRole.BlockedBySelf => "Account blocked by owner",

            AccountRole.Verified => "Verified User",
            AccountRole.Beta => "Beta Tester",
            AccountRole.Translator => "Dragon6 Translator",
            AccountRole.Supporter => "Dragon6 Supporter",
            AccountRole.Contributor => "Recognised Contributor",
            AccountRole.Developer => "Dragon6 Admin",

            _ => "Standard User"
        };

        /// <summary>
        /// Retrieves the default icon for the <see cref="AccountRole"/> provided
        /// </summary>
        public static string GetIcon(this AccountRole role) => role switch
        {
            AccountRole.BlockedByAdmin => "highlight_off",
            AccountRole.BlockedBySelf => "explore_off",

            AccountRole.Verified => "check",
            AccountRole.Beta => "bug_report",
            AccountRole.Translator => "translate",
            AccountRole.Supporter => "favorite",
            AccountRole.Contributor => "code",
            AccountRole.Developer => "verified_user",

            _ => "face",
        };

        /// <summary>
        /// Retrieves the default title color for the <see cref="AccountRole"/> provided
        /// </summary>
        public static string GetColor(this AccountRole role) => role switch
        {
            AccountRole.BlockedByAdmin => "#BD1818",
            AccountRole.BlockedBySelf => "#BD1818",

            AccountRole.Verified => "#20B2AA",
            AccountRole.Beta => "#FFA500",
            AccountRole.Translator => "#1f8b4c",
            AccountRole.Supporter => "#FFB6C1",
            AccountRole.Contributor => "#3498DB",
            AccountRole.Developer => "#90EE90",

            _ => "#FFFFFF",
        };
    }
}
