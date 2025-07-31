using TestTask.UI.Base.Elements;
using UnityEngine;

namespace TestTask.UI.Base
{
    public class UiContainer : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        
        public int Order => _canvas.sortingOrder;
        public void SetOrder(int order) => _canvas.sortingOrder = order;

        public void AddElement(UiElement element) => element.transform.SetParent(_canvas.transform, false);
    }
}