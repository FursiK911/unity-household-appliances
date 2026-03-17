using GasStove.Interfaces;
using UnityEngine;

namespace GasStove
{
    public class CracklingGasStoveBehavior : IGasStoveBehavior
    {
        public void TurnOnGas(Burner burner)
        {
            Debug.Log("[CracklingGasStoveBehavior]: TurnOnGas");
            burner.EnableCracklingEffect();
        }

        public void AdjustFlame(Burner burner)
        {
            Debug.Log("[CracklingGasStoveBehavior]: AdjustFlame");
        }

        public void TurnOffGas(Burner burner)
        {
            Debug.Log("[CracklingGasStoveBehavior]: TurnOffGas");
            burner.DisableCracklingEffect();
        }
    }
}