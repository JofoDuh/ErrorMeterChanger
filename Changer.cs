using UnityEngine;

namespace ErrorMeterChanger
{
    public class Changer
    {
        public static void Settings()
        {
            Main.setting.ChangePosition = GUILayout.Toggle(Main.setting.ChangePosition, "Change Position");
            if (Main.setting.ChangePosition)
            {
                // Begin an indented section
                GUILayout.BeginHorizontal();
                GUILayout.Space(20f); // Add horizontal space for indentation
                GUILayout.BeginVertical(); // Nested layout for content

                GUILayout.BeginHorizontal();
                float newPosXSlide = MoreGUILayout.NamedSlider("X Pos:", Main.setting.XPos, -1500f, 1500f, 300f, 1, 50f);
                if (Main.setting.XPos != newPosXSlide)
                {
                    Main.setting.XPos = newPosXSlide;
                }
                // Same for the Off opacity value
                float newPosYSlide = MoreGUILayout.NamedSlider("Y Pos:", Main.setting.YPos, -1500f, 1500f, 300f, 1, 50f);
                if (Main.setting.YPos != newPosYSlide)
                {
                    Main.setting.YPos = newPosYSlide;
                }
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
                // Get the text from the opacity field as a string
                string newPosX = MoreGUILayout.NamedTextField("X:", Main.setting.XPos.ToString("F0"), 100f, 20f);
                // Try to parse the text field input to a float
                if (float.TryParse(newPosX, out float parsedPosXNew))
                {
                    // Update setting if the new value is different
                    if (Main.setting.XPos != parsedPosXNew)
                    {
                        Main.setting.XPos = parsedPosXNew;
                    }
                }

                // Get the text from the opacity field as a string
                string newPosY = MoreGUILayout.NamedTextField("Y:", Main.setting.YPos.ToString("F0"), 100f, 20f);
                // Try to parse the text field input to a float
                if (float.TryParse(newPosY, out float parsedPosYNew))
                {
                    // Update setting if the new value is different
                    if (Main.setting.YPos != parsedPosYNew)
                    {
                        Main.setting.YPos = parsedPosYNew;
                    }
                }
                GUILayout.EndHorizontal();
                GUILayout.EndVertical();
                GUILayout.EndHorizontal();
            }
            GUILayout.Space(5); // Add space between sections

            //Size Changer
            Main.setting.ChangeSize = GUILayout.Toggle(Main.setting.ChangeSize, "Change Size");
            if (Main.setting.ChangeSize)
            {
                // Begin an indented section
                GUILayout.BeginHorizontal();
                GUILayout.Space(20f); // Add horizontal space for indentation
                GUILayout.BeginVertical(); // Nested layout for content

                GUILayout.BeginHorizontal();
                float newSizeXSlide = MoreGUILayout.NamedSlider("X Size:", Main.setting.XSize, 0, 10f, 300f, 0.01f, 50f, "{0:F2}");
                if (Main.setting.XSize != newSizeXSlide)
                {
                    Main.setting.XSize = newSizeXSlide;
                    if (Main.setting.SquareSizeIsEnabled)
                    {
                        Main.setting.YSize = newSizeXSlide; // Keep Y same as X for a perfect square
                    }
                }
                // Same for the Off opacity value
                float newSizeYSlide = MoreGUILayout.NamedSlider("Y Size:", Main.setting.YSize, 0, 10f, 300f, 0.01f, 50f, "{0:F2}");
                if (Main.setting.YSize != newSizeYSlide)
                {
                    Main.setting.YSize = newSizeYSlide;
                    if (Main.setting.SquareSizeIsEnabled)
                    {
                        Main.setting.XSize = newSizeYSlide; // Keep Y same as X for a perfect square
                    }
                }
                GUILayout.EndHorizontal();
                GUILayout.BeginHorizontal();
                // Text Field for X Size
                string newSizeX = MoreGUILayout.NamedTextField("X:", Main.setting.XSize.ToString("0.00##"), 100f, 20f);
                if (float.TryParse(newSizeX, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out float parsedSizeXNew))
                {
                    if (Main.setting.XSize != parsedSizeXNew)
                    {
                        Main.setting.XSize = parsedSizeXNew;

                        if (Main.setting.SquareSizeIsEnabled)
                        {
                            Main.setting.YSize = parsedSizeXNew;
                        }
                    }
                }

                // Text Field for Y Size
                string newSizeY = MoreGUILayout.NamedTextField("Y:", Main.setting.YSize.ToString("0.00##"), 100f, 20f);
                if (float.TryParse(newSizeY, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out float parsedSizeYNew))
                {
                    if (Main.setting.YSize != parsedSizeYNew)
                    {
                        Main.setting.YSize = parsedSizeYNew;

                        if (Main.setting.SquareSizeIsEnabled)
                        {
                            Main.setting.XSize = parsedSizeYNew;
                        }
                    }
                }
                GUILayout.EndHorizontal();

                // Add a toggle to enable or disable linking
                Main.setting.SquareSizeIsEnabled = GUILayout.Toggle(Main.setting.SquareSizeIsEnabled, "Link X and Y");
                GUILayout.EndVertical();
                GUILayout.EndHorizontal();
            }
        }
    }
}