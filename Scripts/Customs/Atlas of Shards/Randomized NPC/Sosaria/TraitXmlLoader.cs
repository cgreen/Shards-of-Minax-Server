using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Server.Regions.Sosaria.Traits;

namespace Server.Regions.Sosaria
{
    public static class TraitXmlLoader
    {
        public static IEnumerable<SosariaISpeechTrait> Load(string path)
        {
            var doc = new XmlDocument();
            doc.Load(path);

            var root = doc.DocumentElement;

            foreach (XmlNode traitNode in root.SelectNodes("trait"))
            {
                var name     = traitNode.Attributes["name"].Value;
                var priority = int.TryParse(traitNode.Attributes["priority"]?.Value, out var p) ? p : 0;
                var trait    = new DataDrivenSpeechTrait(name, priority);

                foreach (XmlNode entry in traitNode.SelectNodes("entry"))
                {
                    var keyword   = entry.Attributes["keyword"].Value;
                    var itemType  = entry.Attributes["itemType"]?.Value;
                    var ctorAttr  = entry.Attributes["ctorArgs"]?.Value;
                    var ctorArgs  = !string.IsNullOrWhiteSpace(ctorAttr)
                                  ? ctorAttr.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                  : null;

                    var lines = new List<string>();
                    foreach (XmlNode line in entry.SelectNodes("line"))
                        lines.Add(line.InnerText.Trim());

                    trait.AddEntry(keyword, lines, itemType, ctorArgs);
                }

                yield return trait;
            }
        }
    }
}
