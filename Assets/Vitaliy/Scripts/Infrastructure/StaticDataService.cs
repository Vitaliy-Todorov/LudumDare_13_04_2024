using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using UnityEngine;

namespace Infrastructure
{
    public class StaticDataService
    {
        private Dictionary<Type, Window> _windows;
        private Dictionary<EEntity, StaticData> _entities;

        private const string WINDOWS_PATH = "Prefabs/UI/Menu/Windows";
        private readonly string STATIC_DATA_PATH = "Data";

        public StaticDataService()
        {
            _windows =
                Resources
                    .LoadAll<Window>(WINDOWS_PATH)
                    .ToDictionary(levelData => levelData.GetType(), levelData => levelData);
            _entities = Resources.LoadAll<StaticData>(STATIC_DATA_PATH).ToDictionary(data => data.Type, data => data);
        }
    
        public Window GetWindow(Type type) => 
            _windows[type];

        public StaticData GetEntityData(EEntity type) => 
            _entities[type];
    }
}