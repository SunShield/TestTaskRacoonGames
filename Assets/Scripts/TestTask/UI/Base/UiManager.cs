using System;
using System.Collections.Generic;
using System.Linq;
using TestTask.DataLayer;
using TestTask.Service.Classes;
using TestTask.UI.Base.Elements;
using UnityEngine;

namespace TestTask.UI.Base
{
    public class UiManager : MonoSingleton<UiManager>
    {
        private const int UseDefaultOrder = -1;
        
        [SerializeField] private Transform _inactiveUi;
        [SerializeField] private Transform _activeUi;
        [SerializeField] private List<UiContainer> _uiContainers = new ();
        
        private readonly Dictionary<Type, (UiElement element, int order)> _activeElements = new ();
        private readonly Dictionary<Type, (UiElement element, int order)> _inactiveElements = new ();
        private Dictionary<int, UiContainer> _uiContainersMap;
        private Dictionary<int, UiContainer> UiContainersMap 
            => _uiContainersMap ??= _uiContainers.ToDictionary(c => c.Order);


        public TElement ShowUiElement<TElement>(int order = UseDefaultOrder)
            where TElement : UiElement
            => ShowUiElement(typeof(TElement), order) as TElement;
        
        public UiElement ShowUiElement(Type elementType, int order = UseDefaultOrder)
        {
            (UiElement element, int order) elementData = (null, 0);

            if (_activeElements.TryGetValue(elementType, out elementData)) { }
            else if (_inactiveElements.TryGetValue(elementType, out elementData))
            {
                ActivateElement(elementType, elementData.order);
            }
            else
                elementData = CreateUiElement(elementType);
             
            if (order == UseDefaultOrder) order = elementData.order;
            AssignElementToContainer(elementData.element, order);
            return elementData.element;
        }
        
        public void HideUiElement<TElement>() => HideUiElement(typeof(TElement));

        public void HideUiElement(Type elementType)
        {
            if (_inactiveElements.ContainsKey(elementType)) return;
            
            if (!_activeElements.ContainsKey(elementType))
                DeactivateElement(elementType);
        }

        private void ActivateElement(Type elementType, int order)
        {
            var element = _activeElements[elementType];
            _activeElements.Remove(elementType);
            _inactiveElements.Add(elementType, element);
        }

        private void DeactivateElement(Type elementType)
        {
            var element = _inactiveElements[elementType];
            _inactiveElements.Remove(elementType);
            _activeElements.Add(elementType, element);
        }

        private (UiElement element, int order) CreateUiElement(Type elementType)
        {
            var data = GameDataProvider.Instance.UiElementsDatabase.UiElementsDictionary[elementType];
            var instance = Instantiate(data.Element, _inactiveUi);
            var elementData = (instance, data.DefaultOrder);
            _inactiveElements.Add(elementType, elementData);
            return elementData;
        }

        private void AssignElementToContainer(UiElement element, int order)
        {
            if (!UiContainersMap.ContainsKey(order))
            {
                var uiContainer = Instantiate(GameDataProvider.Instance.UiElementsDatabase.ContainerPrefab, _activeUi);
                UiContainersMap.Add(order, uiContainer);
                uiContainer.SetOrder(order);
            }
                
            var container = UiContainersMap[order];
            container.AddElement(element);
        }
    }
}