using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Cheke.ClientSide;
using Cheke.WinCtrl.Properties;
using Cheke.WinCtrl.Storage;
using DevExpress.LookAndFeel;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Blending;
using DevExpress.XtraGrid.Design;
using System.Drawing;

namespace Cheke.WinCtrl.GridControlCommand
{
    internal static class GridStyleCommand
    {
        private static XAppearances _XAppearances = null;

        public const string BlueBackground = "Blue";
        public const string GreenBackground = "Green";
        public const string PinkBackground = "Pink";
        public const string WorldBackground = "World";
        public const string YellowBackground = "Yellow";

        public const string NoBackgroundImage = "(None)";
        public const string DefaultPaintStyle = "Default";
        public const string DefaultStyleFormat = "(Default)";

        internal static string _SkinName = UserLookAndFeel.Default.SkinName;
        internal static string _PaintStyleName = DefaultPaintStyle;
        internal static string _StyleFormatName = DefaultStyleFormat;
        internal static string _BackgroundImageName = NoBackgroundImage;

        internal static SortedList<string, string> _UserDefinedBackgroundImages = new SortedList<string, string>();

        internal static void SaveStyleToFile(string userid)
        {
            //Save PaintStyleName
            if (_PaintStyleName.Length > 0)
            {
                string fileName = String.Format("{0}.PaintStyle.style", userid);
                using (StyleStorage storage = new StyleStorage(fileName))
                {
                    storage.Save(_PaintStyleName);
                    storage.Dispose();
                }

                SaveStyleToServer(fileName, _PaintStyleName);
            }

            //Save BackgroundImageName
            if (_BackgroundImageName.Length > 0)
            {
                string fileName = String.Format("{0}.BackgroundImage.style", userid);
                using (StyleStorage storage = new StyleStorage(fileName))
                {
                    storage.Save(_BackgroundImageName);
                    storage.Dispose();
                }

                SaveStyleToServer(fileName, _BackgroundImageName);
            }

            //Save StyleSchemaName
            if (_StyleFormatName.Length > 0)
            {
                string fileName = String.Format("{0}.StyleSchema.style", userid);
                using (StyleStorage storage = new StyleStorage(fileName))
                {
                    storage.Save(_StyleFormatName);
                    storage.Dispose();
                }

                SaveStyleToServer(fileName, _StyleFormatName);
            }

            //Save SkinName
            if (_SkinName.Length > 0)
            {
                string fileName = String.Format("{0}.SkinName.style", userid);
                using (StyleStorage storage = new StyleStorage(fileName))
                {
                    storage.Save(_SkinName);
                    storage.Dispose();
                }

                SaveStyleToServer(fileName, _SkinName);
            }
        }

        private static void SaveStyleToServer(string fileName, object obj)
        {
            if (FormMainBase.Instance == null)
                return;

            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);

                FormMainBase.Instance.SaveLayoutToServer(fileName, ms.ToArray());
            }  
        }

        internal static void RestoreStyleFromFile(string userid)
        {
            //Restore PaintStyleName
            string fileName = String.Format("{0}.PaintStyle.style", userid);
            using (StyleStorage storage = new StyleStorage(fileName))
            {
                string paintStyleName = storage.Read() as string;
                if (paintStyleName != null)
                {
                    _PaintStyleName = paintStyleName;
                }
                storage.Dispose();
            }

            //Restore BackGroundImage
            fileName = String.Format("{0}.BackgroundImage.style", userid);
            using (StyleStorage storage = new StyleStorage(fileName))
            {
                string backgroundImageName = storage.Read() as string;
                if (backgroundImageName != null)
                {
                    _BackgroundImageName = backgroundImageName;
                }
                storage.Dispose();
            }
            
            //Load User Defined background images
            string directoryPath = string.Format("{0}\\BackgroundImages", Application.StartupPath);
            if (Directory.Exists(directoryPath))
            {
                string[] files = Directory.GetFiles(directoryPath);
                foreach (string item in files)
                {
                    int index = item.LastIndexOf('\\');
                    string imageName = item.Substring(index + 1);
                    index = imageName.LastIndexOf('.');
                    string extension = imageName.Substring(index + 1).ToLower();
                    if (extension == "jpg" || extension == "bmp" || extension == "gif")
                    {
                        imageName = imageName.Substring(0, index);
                        _UserDefinedBackgroundImages.Add(imageName, item);
                    }
                }
            }

            //Restore StyleSchemaName
            fileName = String.Format("{0}.StyleSchema.style", userid);
            using (StyleStorage storage = new StyleStorage(fileName))
            {
                string styleSchemaName = storage.Read() as string;
                if (styleSchemaName != null)
                {
                    _StyleFormatName = styleSchemaName;
                }
                storage.Dispose();
            }

            //Restore SkinName
            fileName = String.Format("{0}.SkinName.style", userid);
            using (StyleStorage storage = new StyleStorage(fileName))
            {
                string skinName = storage.Read() as string;
                if (skinName != null)
                {
                    _SkinName = skinName;
                }
                storage.Dispose();
            }
        }

        internal static XAppearances XAppearances
        {
            get
            {
                if (_XAppearances == null)
                {
                    _XAppearances = new XAppearances(string.Format("{0}\\DevExpress.XtraGrid.Appearances.xml", Application.StartupPath));
                }

                return _XAppearances;
            }
        }

        internal static void ApplyStyle(GridControl gridControl)
        {
            XtraGridBlending xtraGridBlending = new XtraGridBlending();
            xtraGridBlending.GridControl = gridControl;
            xtraGridBlending.Enabled = false;

            //Skin
            if (_SkinName != null && _SkinName.Length > 0)
            {
                gridControl.LookAndFeel.SkinName = _SkinName;
            }

            //Look & Feel
            if (_PaintStyleName.Length > 0)
            {
                gridControl.SwitchPaintStyle(_PaintStyleName);
            }

            //BackgroundImage
            if (_BackgroundImageName == BlueBackground)
            {
                xtraGridBlending.Enabled = true;
                xtraGridBlending.GridControl.BackgroundImage = GridResource.Blue;
            }
            else if (_BackgroundImageName == GreenBackground)
            {
                xtraGridBlending.Enabled = true;
                xtraGridBlending.GridControl.BackgroundImage = GridResource.Green;
            }
            else if (_BackgroundImageName == PinkBackground)
            {
                xtraGridBlending.Enabled = true;
                xtraGridBlending.GridControl.BackgroundImage = GridResource.Pink;
            }
            else if (_BackgroundImageName == YellowBackground)
            {
                xtraGridBlending.Enabled = true;
                xtraGridBlending.GridControl.BackgroundImage = GridResource.Yellow;
            }
            else if (_BackgroundImageName == WorldBackground)
            {
                xtraGridBlending.Enabled = true;
                xtraGridBlending.GridControl.BackgroundImage = GridResource.World;
            }
            else
            {
                if (_UserDefinedBackgroundImages.ContainsKey(_BackgroundImageName))
                {
                    xtraGridBlending.Enabled = true;
                    Image image = Image.FromFile(_UserDefinedBackgroundImages[_BackgroundImageName]);
                    xtraGridBlending.GridControl.BackgroundImage = image;
                }
                else
                {
                    xtraGridBlending.Enabled = false;
                    xtraGridBlending.GridControl.BackgroundImage = null;
                }
            }


            //StyleFormat
            if (XAppearances != null && _StyleFormatName.Length > 0)
            {
                ApplyStyleSchema(gridControl, _StyleFormatName);
                xtraGridBlending.RefreshStyles();
            }
        }

        private static void ApplyStyleSchema(GridControl gridControl, string styleSchema)
        {
            XAppearances.LoadScheme(styleSchema, gridControl.MainView);

            foreach (GridLevelNode item in gridControl.LevelTree.Nodes)
            {
                XAppearances.LoadScheme(styleSchema, item.LevelTemplate);

                SetNodeStyleSchema(item, styleSchema);
            }
        }

        private static void SetNodeStyleSchema(GridLevelNode parent, string styleSchema)
        {
            foreach (GridLevelNode item in parent.Nodes)
            {
                XAppearances.LoadScheme(styleSchema, item.LevelTemplate);

                if (item.Nodes.Count > 0)
                {
                    SetNodeStyleSchema(item, styleSchema);
                }
            }
        }

        internal static void ApplyApplicationStyle()
        {
            //Skin
            if (_SkinName != null && _SkinName.Length > 0)
            {
                UserLookAndFeel.Default.SetSkinStyle(_SkinName);
            }
            else
            {
                if (Enum.IsDefined(typeof (LookAndFeelStyle), _PaintStyleName))
                {
                    UserLookAndFeel.Default.UseWindowsXPTheme = false;
                    UserLookAndFeel.Default.Style =
                        (LookAndFeelStyle) Enum.Parse(typeof (LookAndFeelStyle), _PaintStyleName);
                }
                else
                {
                    UserLookAndFeel.Default.SetWindowsXPStyle();
                }
            }
        }

        internal static void ApplyStyleAll()
        {
            string interfaceName = typeof (IApplyGridStyle).Name;
            foreach (Form item in Application.OpenForms)
            {
                FieldInfo[] fields = ReflectorUtilitiy.GetFieldCollection(item, false, true);
                foreach (FieldInfo field in fields)
                {
                    if (field.FieldType.GetInterface(interfaceName) != null)
                    {
                        IApplyGridStyle gridStyle = field.GetValue(item) as IApplyGridStyle;
                        if (gridStyle != null)
                        {
                            gridStyle.ApplyStyle();
                        }
                    }
                }
            }

            ApplyApplicationStyle();
        }
    }
}