using GameRender;
using ImGuiNET;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WayEngine.UI;


namespace WayEngineVs.Editor
{
    public abstract class WindowM
    {
        public static HierarchyWindow Hwindow = new HierarchyWindow();
        public static MainWindow Mwindow = new MainWindow();
        public static InspectorWindow Iwindow = new InspectorWindow();


        public static List<WindowM> WindowMList = new List<WindowM> {Hwindow,Mwindow,Iwindow};


        public abstract void Render();

        public static void RenderWindow(ImGuiController _controller, FrameEventArgs args, GameWindow ts)
        {
            _controller.Update(ts, (float)args.Time);


            WindowMList.ForEach(w => w.Render());


            _controller.Render();
        }



    }
}
