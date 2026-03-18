using GasStove;
using Instruments;
using Matches;
using UnityEngine;

namespace Gameplay
{
    public class EntryPoint: MonoBehaviour
    {
        [SerializeField]
        private Stove _stove;
        [SerializeField] 
        private Matchbox _matchbox;
        [SerializeField]
        private GasAnalyzer _gasAnalyzer;
        [SerializeField]
        private GameplayProcessChecker _gameplayProcessChecker;
        
        private void Awake()
        {
            _stove.Initialize();
            _matchbox.Initialize();
            _gasAnalyzer.Initialize();
            _gameplayProcessChecker.Initialize();
        }
    }
}