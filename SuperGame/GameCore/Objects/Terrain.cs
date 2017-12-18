using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Numerics;
using GameCore.Models;
using GameCore.Render;

namespace GameCore.Objects
{
    public class Terrain : GameObject
    {
        private IRenderPrimitive[,] primitives = new IRenderPrimitive[TerrainSize, TerrainSize];
        private const int TerrainCellSize = 128;
        private const int TerrainSize = 16;

        public string[] Map { get; set; }

        public Terrain(string terrainFile)
        {
            
            Map = new string[TerrainSize];

            Map = File.ReadAllLines(terrainFile);

            Name = "Terrain";

        }

        public override void OnAttachToWorld()
        {
           if (World.RenderManager != null)
            {
                var offset = new Vector2(TerrainCellSize * TerrainSize, TerrainCellSize * TerrainSize);
                offset /= 2;

                for (var i = 0; i < TerrainSize; i++)
                {
                    var mapRow = Map[i].Split(' ');
                    for (var j = 0; j < TerrainSize; j++)
                    {
                        var cell = World.RenderManager.CreatePrimitive();
                        cell.Size = new Vector2(TerrainCellSize + 1, TerrainCellSize + 1);
                        cell.Position = new Vector2(TerrainCellSize * i, TerrainCellSize * j) - offset;

                        cell.ImageName = "terrain\\topdownTile_" + mapRow[j];

                        if (mapRow[j].Equals("12"))
                            AddPhysicsModel(cell);

                        primitives[i, j] = cell;
                    }

                }

                
            }

            base.OnAttachToWorld();
        }

        // тут просто захардкожено добавление физических моделей к определённым ячейкам
        public void AddPhysicsModel(IRenderPrimitive initPrimitive)
        {
            var cellWithPhysics = new MapObject
            {
                Position = initPrimitive.Position,
                Size = initPrimitive.Size
            };

            var PhysicModel = new PhysicsSphere
            {
                IsSatatic = true,
                Radius = cellWithPhysics.Size.Length() / 2.0f,
                MapObject = cellWithPhysics
            };

            World.PhysicsManager.Models.Add(PhysicModel);
        }

        public override void OnDetach()
        {
            if (World.RenderManager != null)
            {
                for (var i = 0; i < TerrainSize; i++)
                {
                    for (var j = 0; j < TerrainSize; j++)
                    {
                        World.RenderManager.DestroyPrimitive(primitives[i, j]);
                    }
                }
            }

            base.OnDetach();
        }
    }
}