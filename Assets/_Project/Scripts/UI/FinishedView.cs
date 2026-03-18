using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class FinishedView : MonoBehaviour
    {
        [SerializeField]
        private Button _exitButton;

        private void OnEnable()
        {
            _exitButton.onClick.AddListener(HandleExitButtonClick);
        }
        
        private void OnDisable()
        {
            _exitButton.onClick.RemoveListener(HandleExitButtonClick);
        }

        private void HandleExitButtonClick()
        {
            Application.Quit();
        }
    }
}