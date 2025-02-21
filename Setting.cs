using System.IO;
using System.Xml.Serialization;
using UnityEngine;
using UnityModManagerNet;

namespace ErrorMeterChanger
{
    public class Setting : UnityModManager.ModSettings
    {
        public bool ChangeSize = false;
        public bool ChangePosition = false;
        public bool SquareSizeIsEnabled = true;
        public float XPos = 0;
        public float YPos = 0;
        public float XSize = 1f;
        public float YSize = 1f;
        public Vector2 OriginalOffMin;
        public Vector2 OriginalOffMax;
        public Vector3 OriginalLocalScale;
        public override void Save(UnityModManager.ModEntry modEntry) {
            var filepath = GetPath(modEntry);
            try {
                using (var writer = new StreamWriter(filepath)) {
                    var serializer = new XmlSerializer(GetType());
                    serializer.Serialize(writer, this);
                }
            } catch {
            }
        }
       
        public override string GetPath(UnityModManager.ModEntry modEntry) {
            return Path.Combine(modEntry.Path, GetType().Name + ".xml");
        }
  
    }
}