using System;
using System.Collections.Generic;
using System.Numerics;
using GameCore.Render;

namespace GameCore.Objects
{
    // ландшавт
    public class Terrain: GameObject
    {
        private const int TerrainSize = 16;
        private const int TerrainCellSize = 128;
        private IRenderPrimitive[,] primitives = new IRenderPrimitive[TerrainSize, TerrainSize];
        public List<string> Map { get; set; }

        public Terrain()
        {
            Map = new List<string>();
            
        }

        public override void OnAttachToWorld()
        {
            //var rand = new Random();
            if (Map.Count == 0)
            {
                for (int i = 0; i < TerrainSize; i++)
                {
                    var row = "";
                    for (int j = 0; j < TerrainSize; j++)
                    {
                        row += "25 ";
                    }
                    Map.Add(row);
                }
            }

            if (World.RenderManager != null)
            {
                var offset = new Vector2(TerrainSize * TerrainCellSize, TerrainSize * TerrainCellSize);
                offset /= 2;

                for (int i = 0; i < TerrainSize; i++)
                {
                    var mapRow = Map[i].Split(' ');
                    for (int j = 0; j < TerrainSize; j++)
                    { 
                        var cell = World.RenderManager.CreatePrimitive();
                        cell.Size = new Vector2(TerrainCellSize, TerrainCellSize);
                        cell.Position = new Vector2(TerrainCellSize * i , TerrainCellSize * j ) - offset;

                        cell.ImageName = "terrain\\topdownTile_" + mapRow[j];


                        // тут ещё можно заюзать шум Перлина
                        //if (rand.NextDouble() > .8)
                        //{
                        //}
                        //else
                        //{
                        //    cell.ImageName = "terrain\\topdownTile_25";
                        //}

                        primitives[i, j] = cell;
                    }
                }
            }
            base.OnAttachToWorld();
        }

        public override void OnDetach()
        {
            if (World.RenderManager != null)
            {
                for (int i = 0; i < TerrainSize; i++)
                {
                    for (int j = 0; j < TerrainSize; j++)
                    {
                        World.RenderManager.DestroyPrimitive(primitives[i, j]);
                    }
                }
            }
            base.OnDetach();
        }
    }
}