﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using GameCore.Models;
using GameCore.Objects;
using GameCore.Render;
using Newtonsoft.Json;

namespace GameCore.Managers
{
    public class World
    {
        private List<GameObject> objects;
        private List<GameObject> needAttachObjects;
        private Thread simulationThread;
        private bool isSimulation;
  
        public IRenderManager RenderManager { get; set; }
        public InputManager InputManager { get; set; }
        public Physics PhysicsManager { get; set; }

        public World()
        {
            needAttachObjects= new List<GameObject>();
            PhysicsManager = new Physics();
            objects = new List<GameObject>();
            InputManager = new InputManager();
        }

        // расчет всего нашего мира (обновление координат, ...)
        public void BeginSimulation()
        {
            simulationThread = new Thread(SimulationLoop);
            simulationThread.Start();
        }

        private void SimulationLoop()
        {
            var timer = new Stopwatch();

            // хранит время, за которое рендерится последний кадр
            float dt = 0.0f;

            isSimulation = true;

            while (isSimulation)
            {
                timer.Restart();
                PhysicsManager.OnTick(dt);

                foreach (var gameObject in objects)
                {
                    gameObject.OnTick(dt);
                }

                //var toDestroy = objects.Where(x => x.IsNeedDestroy).ToList();

                //foreach (var gameObject in toDestroy)
                //{
                //    RemoveObject(gameObject);
                //}

                if (RenderManager != null)
                {
                    RenderManager.RunInUIThread(RemoveAllDestroyObject);
                    RenderManager.RunInUIThread(AttachAllUnattachObject);
                    RenderManager.BeginRender();
                }
                else
                {
                    RemoveAllDestroyObject();
                    AttachAllUnattachObject();
                }
                
                //RenderManager?.BeginRender();
                Thread.Sleep(16);

                timer.Stop();
                dt = (float) timer.Elapsed.TotalSeconds;

            }
        }

        private void AttachAllUnattachObject()
        {
            foreach (var gameObject in needAttachObjects)
            {
                gameObject.OnAttachToWorld();
                objects.Add(gameObject);
            }

            needAttachObjects.Clear();
        }

        private void RemoveAllDestroyObject()
        {
            var toDestroy = objects.Where(x => x.IsNeedDestroy).ToList();

            foreach (var gameObject in toDestroy)
            {
                RemoveObject(gameObject);
            }
        }

        public void EndSimulation()
        {
//            if (simulationThread != null)
//                simulationThread.Abort();
//            simulationThread?.Abort();
            isSimulation = false;
        }

        // меняет существующий экзмепляр World
        public void LoadWorld(string file)
        {
            ClearWorld();
            //objects.Clear();

            if (File.Exists(file))
            {
                var jsonData = File.ReadAllText(file);
                var jsonOpt = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Objects,
                };

                var saveModel = JsonConvert.DeserializeObject<SaveModel>(jsonData, jsonOpt);

                foreach (var gameObj in saveModel.Objects)
                {
                    AddObject(gameObj);
                }
            }
        }

        public void CreateDefaultWorld()
        {

            ClearWorld();

            //objects.Clear();

            AddObject(new Terrain
            {
                Name = "Земля"
            });

            AddObject(new MapObject
            {
                Size = new Vector2(128, 128),
                Position = new Vector2(150, 200),
                ImageName = "objects\\topdownTile_31",
                Name = "Куст"
            });

            AddObject(new Player
            {
                Size = new Vector2(128, 128),
                Position = new Vector2(0, 0),
                Name = "PlayerCharacter"
            });

            AddObject(new NPC
            {
                Size = new Vector2(128, 128),
                Position = new Vector2(200, -150),
                Name = "NPC1"
            });
        }

        public void AddObject(GameObject gameObj)
        {
            gameObj.World = this;
            if (simulationThread == Thread.CurrentThread)
            {
                needAttachObjects.Add(gameObj);
            }
            else
            {
                objects.Add(gameObj);
                gameObj.OnAttachToWorld();
            }
            
        }

        public void ClearWorld()
        {
            while (objects.Any())
            {
                RemoveObject(objects.First());
            }
        }

        public void RemoveObject(GameObject gameObj)
        {
            gameObj.OnDetach();
            objects.Remove(gameObj);
            gameObj.World = null;
        }

        public void SaveWorld(String file)
        {
            var saveModel = new SaveModel
            {
                //Ob/jects = objects.Select(x => x as MapObject).Where(x => x != null).ToList(),
                Objects = objects,
                Date = DateTime.Now
            };
            var jsonOpt = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects,
                Formatting = Formatting.Indented
            };

            var jsonData = JsonConvert.SerializeObject(saveModel, jsonOpt);
            File.WriteAllText(file, jsonData);

        }
    }
}
