using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TownRaiserImGui
{
    public enum CursorState
    {
        Default,
        Select,
        Move,
        Attack,
        Target
    }
    // code obtained from StackOverflow, as posted by user "Nick"
    // http://stackoverflow.com/questions/550918/change-cursor-hotspot-in-winforms-net
    public struct IconInfo
    {
        public bool fIcon;
        public int xHotspot;
        public int yHotspot;
        public IntPtr hbmMask;
        public IntPtr hbmColor;
    }

    public class CustomCursorGraphicController
    {
#if !MONOGAME
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetIconInfo(IntPtr hIcon, ref IconInfo pIconInfo);
        [DllImport("user32.dll")]
        public static extern IntPtr CreateIconIndirect(ref IconInfo icon);

        
        private static readonly string cursorDirectory = "Content/GlobalContent/CursorGraphics/";
        private static readonly string selectCursorFileName = "SelectCursor.png";
        private static readonly string moveCursorFileName = "MoveCursor.png";
        private static readonly string attackCursorFileName = "AttackCursor.png";
        private static readonly string targetCursorFileName = "TargetCursor.png";

        private static System.Windows.Forms.Cursor m_SelectCursor;
        private static System.Windows.Forms.Cursor m_MoveCursor;
        private static System.Windows.Forms.Cursor m_AttackCursor;
        private static System.Windows.Forms.Cursor m_TargetCursor;

        private static System.Windows.Forms.Form m_GameAsForm;


#endif
        private static CursorState m_CurrentCursorState;
        public static CursorState CurrentCursorState
        {
            get
            {
                return m_CurrentCursorState;
            }
            set
            {
                bool changed = value != m_CurrentCursorState;
                m_CurrentCursorState = value;

#if !MONOGAME
                if (changed && m_GameAsForm != null)
                {
                    switch(m_CurrentCursorState)
                    {
                        case CursorState.Select:
                            m_GameAsForm.Cursor = m_SelectCursor;
                            break;
                        case CursorState.Move:
                            m_GameAsForm.Cursor = m_MoveCursor;
                            break;
                        case CursorState.Attack:
                            m_GameAsForm.Cursor = m_AttackCursor;
                            break;
                        case CursorState.Target:
                            m_GameAsForm.Cursor = m_TargetCursor;
                            break;
                        default:
                            throw new Exception("Default state not supported for this game. This is mainly so we can set the game up with a custom cursor.");
                    }
                }
#endif
            }
        }


        public static void Initialize(Microsoft.Xna.Framework.Game game)
        {
#if !MONOGAME
            
            m_SelectCursor = CreateCursor((Bitmap)Bitmap.FromFile($"{cursorDirectory}{selectCursorFileName}"));
            m_MoveCursor = CreateCursor((Bitmap)Bitmap.FromFile($"{cursorDirectory}{moveCursorFileName}"));
            m_AttackCursor = CreateCursor((Bitmap)Bitmap.FromFile($"{cursorDirectory}{attackCursorFileName}"));
            m_TargetCursor = CreateCursor((Bitmap)Bitmap.FromFile($"{cursorDirectory}{targetCursorFileName}"));

            m_GameAsForm = (System.Windows.Forms.Form)System.Windows.Forms.Control.FromHandle(game.Window.Handle);
            CurrentCursorState = CursorState.Select;
#endif

        }

#if !MONOGAME
        private static System.Windows.Forms.Cursor CreateCursor(System.Drawing.Bitmap bmp)
        {
            IntPtr ptr = bmp.GetHicon();
            IconInfo tmp = new IconInfo();
            GetIconInfo(ptr, ref tmp);

            //Our cursor's click point will be the middle of the image.
            tmp.xHotspot = bmp.Width/2;
            tmp.yHotspot = bmp.Height/2;
            tmp.fIcon = false;
            ptr = CreateIconIndirect(ref tmp);
            return new System.Windows.Forms.Cursor(ptr);
        }
#endif
    }
}
