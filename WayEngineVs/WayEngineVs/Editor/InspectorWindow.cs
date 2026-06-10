using ImGuiNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Entities;
using OpenTK.Mathematics;

namespace WayEngineVs.Editor
{
    public class InspectorWindow : WindowM
    {
        private static int _cur = 1;

        public static int cur 
        {
            get => _cur;

            set
            {
                _cur = value;
                CheckTSR();
                CheckColor();
            }
        }

        static float PosX;
        static float PosY;

        static float ScaleX = 1.0f;
        static float ScaleY = 1.0f;

        static float RotateZ = 0.0f;


        static Color4 color;

        static System.Numerics.Vector4 imguiColor = new System.Numerics.Vector4(color.R, color.G, color.B, 1.0f);


        public override void Render()
        {
            ImGui.Begin("Inspector");      

            ControlTSR();

            ImGui.End();

        }


        public void ControlTSR()
        {
            ImGui.Text($"Entity: {EntitySystem.EntitiesScene[cur].name}");

            PositionGui();

            if (cur > 1)
            {
                ScaleGui();
                RotateGui();
            }

            

            ImGui.ColorPicker4("Color", ref imguiColor);

            color = new Color4((float)imguiColor.X, (float)imguiColor.Y, (float)imguiColor.Z, 1.0f);

            ColorSystem.SetColor(EntitySystem.EntitiesScene[cur], color);
       
        }


        public static void CheckColor() 
        {
            color = ComponentSystem.GetProperty<Component.Color>(EntitySystem.EntitiesScene[cur], "Color").color;
        }

        public static void CheckTSR() 
        {
            PosX = ComponentSystem.GetProperty<Component.Transform>(EntitySystem.EntitiesScene[cur], "Transform").xyPos.M42;

            PosY = ComponentSystem.GetProperty<Component.Transform>(EntitySystem.EntitiesScene[cur], "Transform").xyPos.M41;

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            ScaleX = ComponentSystem.GetProperty<Component.Transform>(EntitySystem.EntitiesScene[cur], "Transform").xyScale.M41;

            ScaleY = ComponentSystem.GetProperty<Component.Transform>(EntitySystem.EntitiesScene[cur], "Transform").xyScale.M42;

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            RotateZ = ComponentSystem.GetProperty<Component.Transform>(EntitySystem.EntitiesScene[cur], "Transform").zRotate.M43;
        }

        public void PositionGui() 
        {
            ImGui.Text("");

            ImGui.SameLine(150.0f);

            ImGui.Text("X");

            ImGui.SameLine(250.0f);

            ImGui.Text("Y");

            ImGui.Text("Position");

            ImGui.SameLine(100.0f);

            ImGui.SetNextItemWidth(100.0f);

            ImGui.DragFloat("##px", ref PosX, 0.01f);

            ImGui.SameLine(210.0f);

            ImGui.SetNextItemWidth(100.0f);

            ImGui.DragFloat("##py", ref PosY, 0.01f);

            TransformSystem.ReloadTranslate(EntitySystem.EntitiesScene[cur], (double)PosX, (double)PosY);

        }

        public void ScaleGui() 
        {
            ImGui.Text("Scale");

            ImGui.SameLine(100.0f);

            ImGui.SetNextItemWidth(100.0f);

            ImGui.DragFloat("##sx", ref ScaleX, 0.01f);

            ImGui.SameLine(210.0f);

            ImGui.SetNextItemWidth(100.0f);

            ImGui.DragFloat("##sy", ref ScaleY, 0.01f);

            if (ScaleX >= 0 && ScaleY >= 0)
            {

                TransformSystem.ReloadScale(EntitySystem.EntitiesScene[cur], (double)ScaleX, (double)ScaleY);

            }
        }

        public void RotateGui()
        {
            ImGui.Text("Rotate");

            ImGui.SameLine(100.0f);

            ImGui.SetNextItemWidth(100.0f);

            ImGui.DragFloat("##rz", ref RotateZ, 0.01f);

            TransformSystem.ReloadRotate(EntitySystem.EntitiesScene[cur], (double)RotateZ);
        }
    }
}
