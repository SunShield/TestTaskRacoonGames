using System;
using System.Collections.Generic;
using System.Linq;
using TestTask.UI;
using TestTask.UI.Base;
using UnityEngine;

namespace TestTask.DataLayer.Databases.Ui
{
    [CreateAssetMenu(fileName = "UiDatabase", menuName = "Data/UI Database")]
    public class UiElementsDatabase : ScriptableObject
    {
        [field: SerializeField] public UiContainer ContainerPrefab { get; private set; }
        [SerializeField] private List<UiElementDatabaseEntry> _elements = new ();
        
        private Dictionary<Type, UiElementDatabaseEntry> _uiElementsDictionary;
        public Dictionary<Type, UiElementDatabaseEntry> UiElementsDictionary 
            => _uiElementsDictionary ??= _elements.ToDictionary(sde => sde.Element.GetType());
    }
}