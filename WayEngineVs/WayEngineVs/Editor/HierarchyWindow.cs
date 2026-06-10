using Entities;
using ImGuiNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WayEngineVs.Editor
{
    public class HierarchyWindow : WindowM
    {
        static Dictionary<Entity,bool> EntitiesGuiState = new Dictionary<Entity, bool>();
        public override void Render()
        {

            ImGui.Begin("Hierarchy");

            

            ImGui.TreePush("Objects");

            foreach(var entity in EntitySystem.EntitiesScene) 
            {
                if (!EntitiesGuiState.ContainsKey(entity.Value)) 
                {
                    EntitiesGuiState.Add(entity.Value, false);
                }

                if (ImGui.TreeNodeEx(entity.Value.name))
                {
                    if (!EntitiesGuiState[entity.Value])
                    {
                        EntitiesGuiState[EntitySystem.EntitiesScene[InspectorWindow.cur]] = false;
                        InspectorWindow.cur = entity.Key;
                        EntitiesGuiState[entity.Value] = true;
                    }

                    ImGui.TreePop();
                }

                
            }

            ImGui.TreePop();

            

            ImGui.End();

        }

     }
}