using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Instruments
{
    public class GasAnalyzerDisplay : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private TMP_Text _tmpText;
        [SerializeField] private Image _panelImage;

        [Header("Settings")] 
        [SerializeField] private string _normalText;
        [SerializeField] private Color _normalColor;
        [Space]
        [SerializeField] private string _gasText;
        [SerializeField] private Color _gasColor;

        public void Initialize()
        {
            ShowEmptyGasScreen();
        }

        public void ShowEmptyGasScreen()
        {
            _panelImage.color = _normalColor;
            _tmpText.text = _normalText;
        }

        public void ShowGasScreen()
        {
            _panelImage.color = _gasColor;
            _tmpText.text = _gasText;
        }
    }
}