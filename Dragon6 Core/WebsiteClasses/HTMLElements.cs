using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonFruit.Six.Core
{
    public class HTMLElements
    {
        /// <summary>
        /// Returns the HTML code for a Bootstrap 4 Dual tone bar (red+green)
        /// </summary>
        /// <param name="green"></param>
        /// <returns></returns>
        public static string DualToneBar(double green)
        {
            double red = 101D - green;
            return $"<div class=\"progress\" style=\"height: 3px; \"><div class=\"progress-bar bg-success\" role=\"progressbar\" style=\"width: {green}%\" aria-valuenow={green} aria-valuemin=\"0\" aria-valuemax=\"100\"></div><div class=\"progress-bar bg-danger\" role=\"progressbar\" style=\"width: {red}% \" aria-valuenow={red} aria-valuemin=\"0\" aria-valuemax=\"100\"></div></div>";
        }

        /// <summary>
        /// Returns the HTML code for a Bootstrap 4 monotone bar (blue)
        /// </summary>
        /// <param name="green"></param>
        /// <returns></returns>
        public static string MonoToneBar(double blue)
        {
            double rest = 101D - blue;
            return $"<div class=\"progress\" style=\"height: 3px; \"><div class=\"progress-bar bg-info\" role=\"progressbar\" style=\"width: {blue}%\" aria-valuenow={blue} aria-valuemin=\"0\" aria-valuemax=\"100\"></div><div class=\"progress-bar bg-muted\" role=\"progressbar\" style=\"width: {rest}% ;background-color:#868e96\" aria-valuenow={rest} aria-valuemin=\"0\" aria-valuemax=\"100\"></div></div>";
        }

        /// <summary>
        /// Returns the HTML code for a Bootstrap 4 Dual tone bar (orange+green)
        /// </summary>
        /// <param name="green"></param>
        /// <returns></returns>
        public static string DualToneInvariant(double orange)
        {
            double green = 101D - orange;
            return $"<div class=\"progress\" style=\"height: 3px; \"><div class=\"progress-bar bg-warning\" role=\"progressbar\" style=\"width: {orange}%\" aria-valuenow={orange} aria-valuemin=\"0\" aria-valuemax=\"100\"></div><div class=\"progress-bar bg-success\" role=\"progressbar\" style=\"width: {green}% \" aria-valuenow={green} aria-valuemin=\"0\" aria-valuemax=\"100\"></div></div>";
        }
    }
}
