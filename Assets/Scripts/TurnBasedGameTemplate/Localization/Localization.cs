using System;
using System.Collections.Generic;
using TurnBasedGameTemplate.Tools.Patterns.Singleton;

namespace TurnBasedGameTemplate.Localization
{
    public class Localization : Singleton<Localization>
    {
        readonly Dictionary<LocalizationIds, string> data = new Dictionary<LocalizationIds, string>();

        public Localization()
        {
            foreach (var id in Enum.GetValues(typeof(LocalizationIds))) data.Add((LocalizationIds) id, id.ToString());
        }

        public string Get(LocalizationIds id) => data[id];
    }
}