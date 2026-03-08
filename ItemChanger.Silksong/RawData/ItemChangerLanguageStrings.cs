using ItemChanger.Serialization;
using ItemChanger.Silksong.Extensions;
using ItemChanger.Silksong.Serialization;
using ItemChanger.Silksong.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItemChanger.Silksong.RawData;

internal static class ItemChangerLanguageStrings
{
    public static LanguageString FMT_PAY_ROSARIES => LanguageString.FromItemChanger(nameof(FMT_PAY_ROSARIES));
    public static LanguageString FMT_FAST_TRAVEL_PATTERN => LanguageString.FromItemChanger(nameof(FMT_FAST_TRAVEL_PATTERN));
    public static LanguageString FMT_MATERIUM_ENTRY_NAME => LanguageString.FromItemChanger(nameof(FMT_MATERIUM_ENTRY_NAME));
    public static LanguageString FMT_JOURNAL_ENTRY_NAME => LanguageString.FromItemChanger(nameof(FMT_JOURNAL_ENTRY_NAME));

    public static CompositeString CreatePayRosariesString(IValueProvider<int> rosaryCount)
    {
        return CompositeString.Create(FMT_PAY_ROSARIES, new Dictionary<string, IValueProvider<object>>()
        {
            { "ROSARY_COUNT", rosaryCount.Embox() },
            { "ROSARY_NAME", BaseLanguageStrings.Rosaries }
        });
    }
}
