// Dragon6 API Copyright 2020 DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Please refer to the LICENSE file for more info

namespace DragonFruit.Six.API.Verification
{
    public static class AccountTypeExtensions
    {
        public static string GetName(this Dragon6AccountInfo dragon6User) => string.IsNullOrEmpty(dragon6User.CustomTitle) ? GetDefaultName(dragon6User.AccountType) : dragon6User.CustomTitle;
        public static string GetIcon(this Dragon6AccountInfo dragon6User) => string.IsNullOrEmpty(dragon6User.CustomIcon) ? GetDefaultIcon(dragon6User.AccountType) : dragon6User.CustomIcon;
        public static string GetColor(this Dragon6AccountInfo dragon6User) => string.IsNullOrEmpty(dragon6User.CustomColour) ? GetDefaultColor(dragon6User.AccountType) : dragon6User.CustomColour;

        /// <summary>
        /// Retrieves the default title for the <see cref="AccountType"/> provided
        /// </summary>
        private static string GetDefaultName(this AccountType type) => type switch
        {
            AccountType.Blocked => "Data Blocked by Request",

            AccountType.Verified => "Verified User",
            AccountType.Beta => "Beta Tester",
            AccountType.Translator => "Dragon6 Translator",
            AccountType.Supporter => "Dragon6 Supporter",
            AccountType.Contributor => "Recognised Contributor",
            AccountType.Developer => "Dragon6 Admin",

            _ => "Standard User",
        };

        /// <summary>
        /// Retrieves the default icon for the <see cref="AccountType"/> provided
        /// </summary>
        private static string GetDefaultIcon(this AccountType type) => type switch
        {
            AccountType.Blocked => "explore_off",

            AccountType.Verified => "check",
            AccountType.Beta => "bug_report",
            AccountType.Translator => "translate",
            AccountType.Supporter => "favorite",
            AccountType.Contributor => "code",
            AccountType.Developer => "verified_user",

            _ => "face",
        };

        /// <summary>
        /// Retrieves the default title colour for the <see cref="AccountType"/> provided
        /// </summary>
        private static string GetDefaultColor(this AccountType type) => type switch
        {
            AccountType.Blocked => "#bd1818",

            AccountType.Verified => "#20B2AA",
            AccountType.Beta => "#FFA500",
            AccountType.Translator => "#1f8b4c",
            AccountType.Supporter => "#FFB6C1",
            AccountType.Contributor => "#3498DB",
            AccountType.Developer => "#90EE90",

            _ => "#ffffff",
        };
    }
}
