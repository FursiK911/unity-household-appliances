using GasStove;
using UnityEngine;

namespace Gameplay
{
    public class EntryPoint: MonoBehaviour
    {
        [SerializeField]
        private Stove _stove;
        
        private void Awake()
        {
            _stove.Initialize();
        }
    }
}