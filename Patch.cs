using HarmonyLib;
using UnityEngine;

namespace ErrorMeterChanger
{
    public static class Patch
    {
        private static bool flag = false;

        public static scrController controller
        {
            get
            {
                return scrController.instance;
            }
        }
        [HarmonyPatch(typeof(scnGame), "Update")]
        public static class UpdateLayoutPatch
        {
            public static void Postfix()
            {
                RectTransform errormeter = controller.errorMeter.wrapperRectTransform.gameObject.GetComponent<RectTransform>();
                float YPos = Main.setting.YPos * 4;

                if (errormeter == null) return;

                if (!flag)
                {
                    Main.setting.OriginalOffMin = errormeter.offsetMin;
                    Main.setting.OriginalOffMax = errormeter.offsetMax;
                    Main.setting.OriginalLocalScale = errormeter.localScale;
                    flag = true;
                }

                if ((!Main.setting.ChangePosition || !Main.setting.ChangeSize) && flag)
                {
                    SetDefault();
                }

                if (Main.setting.ChangePosition)
                {
                    errormeter.offsetMax = new Vector2(
                        Main.setting.OriginalOffMin.x + 
                        (Main.setting.ChangePosition ? Main.setting.XPos : 0),
                        Main.setting.OriginalOffMin.y + 
                        (Main.setting.ChangePosition ? YPos * -1 : 0)
                    );

                    errormeter.offsetMax = new Vector2(
                        Main.setting.OriginalOffMax.x +
                        (Main.setting.ChangePosition ? Main.setting.XPos : 0),
                        Main.setting.OriginalOffMax.y + 
                        (Main.setting.ChangePosition ? YPos * -1 : 0)
                    );
                }
                if (Main.setting.ChangeSize)
                {
                    errormeter.localScale = new Vector3(Main.setting.XSize, Main.setting.YSize, Main.setting.OriginalLocalScale.z);
                }
            }
            public static void SetDefault()
            {
                RectTransform errormeter = controller.errorMeter.wrapperRectTransform.gameObject.GetComponent<RectTransform>();

                if (errormeter == null) return;

                if (!Main.setting.ChangePosition)
                {
                    errormeter.offsetMin = new Vector2(Main.setting.OriginalOffMin.x, Main.setting.OriginalOffMin.y);
                    errormeter.offsetMax = new Vector2(Main.setting.OriginalOffMax.x, Main.setting.OriginalOffMax.y);
                }
                if (!Main.setting.ChangeSize)
                {
                    errormeter.localScale = new Vector3(Main.setting.OriginalLocalScale.x, Main.setting.OriginalLocalScale.y,
                    Main.setting.OriginalLocalScale.z);
                }
            }
        }
    }
}