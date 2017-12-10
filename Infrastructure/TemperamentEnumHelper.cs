using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackwardChainingMVVM.Infrastructure
{
    public class EnumHelper
    {
        public static List<SimpleItem> TranslationsDictionary
        {
            get
            {
                var translationsDictionary = new List<SimpleItem>();

                translationsDictionary.Add(new SimpleItem(TemperamentEnum.Balanced, Properties.Resources.Balanced));
                translationsDictionary.Add(new SimpleItem(TemperamentEnum.Extravert, Properties.Resources.Extravert));
                translationsDictionary.Add(new SimpleItem(TemperamentEnum.Introvert, Properties.Resources.Introvert));
                translationsDictionary.Add(new SimpleItem(TemperamentEnum.Neurotic, Properties.Resources.Neurotic));
                translationsDictionary.Add(new SimpleItem(TemperamentEnum.Mixed, Properties.Resources.Mixed));

                return translationsDictionary;
            }
        }
    }

    public class SimpleItem
    {
        public SimpleItem(TemperamentEnum EnumKey, string Value)
        {
            this.EnumKey = EnumKey;
            this.Value = Value;
        }

        public TemperamentEnum EnumKey { get; set; }

        public string Value { get; set; }
    }
}
