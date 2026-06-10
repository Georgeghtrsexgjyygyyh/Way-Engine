using Entities;
using GameRender;
using ImGuiNET;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System;
using System.Collections.Generic;
using WayEngine.UI;

namespace WayEngineVs.Editor
{
    public class MainWindow : WindowM
    {

        public override void Render()
        {
            
            ImGuiWindowFlags windowFlags = ImGuiWindowFlags.MenuBar;

            if (ImGui.Begin("Way Engine", windowFlags))
            {
                
                if (ImGui.BeginMenuBar())
                {
                    
                    if (ImGui.BeginMenu("Create"))
                    {
                        
                        if (ImGui.BeginMenu("Object"))
                        {
                           
                            if (ImGui.MenuItem("Triangle"))
                            {
                                
                                Entity object0 = new Entity("Object0", "Triangle");

                                object0.name = $"Object{object0.ID}";

                                TransformSystem.ReloadTranslate(object0,0.0f,0.0f);
                                TransformSystem.ReloadRotate(object0, 90.0f);
                                TransformSystem.ReloadScale(object0, 1.0f, 1.0f);



                                Console.WriteLine("Triangle is summed!");

                            }

                            if (ImGui.MenuItem("Square"))
                            {
                                Entity object1 = new Entity("Object0", "Square");
                                object1.name = $"Object{object1.ID}";

                                TransformSystem.ReloadTranslate(object1, 0.0f, 0.0f);
                                TransformSystem.ReloadRotate(object1, 90.0f);
                                TransformSystem.ReloadScale(object1, 1.0f,1.0f);


                                Console.WriteLine("Square is summed!");
                            }

                            ImGui.EndMenu();
                        }

                        ImGui.EndMenu();
                    }

                    ImGui.EndMenuBar();
                }

                
                

                ImGui.End(); 
            }
        }
    }
}
