using GasStove;
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
        
        private void Awake()
        {
            _stove.Initialize();
            _matchbox.Initialize();
        }
    }
}