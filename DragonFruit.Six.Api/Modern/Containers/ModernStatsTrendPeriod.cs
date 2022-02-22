// Dragon6 API Copyright DragonFruit Network <inbox@dragonfruit.network>
// Licensed under Apache-2. Refer to the LICENSE file for more info

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DragonFruit.Six.Api.Modern.Containers
{
    public class ModernStatsTrendPeriod<T>
    {
        private readonly string _dateRange;

        private DateTime? _start, _end;
        private IEnumerable<string> _periods;

        public ModernStatsTrendPeriod(string dateRange, T value)
        {
            _dateRange = dateRange;
            Value = value;
        }

        public T Value { get; set; }

        public DateTime Start => _start ??= ParsePeriodDate(Periods.First());
        public DateTime End => _end ??= ParsePeriodDate(Periods.Last());

        private IEnumerable<string> Periods => _periods ??= _dateRange.Split(':');

        private static DateTime ParsePeriodDate(string date) => DateTime.ParseExact(date, "yyyy-MM-dd", null, DateTimeStyles.AssumeUniversal);
    }
}
