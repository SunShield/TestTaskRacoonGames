using UnityEngine;

namespace TestTask.UI.Base.Elements
{
    public abstract class UiElement : MonoBehaviour
    {
        // later could (and possibly should) be made async
        public virtual void OnOpen() { }

        public void CloseSelf()
        {
            UiManager.Instance.HideUiElement(GetType());
            OnClose();
        }
        
        protected virtual void OnClose() { }
    }
}