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

        public void Light(Burner burner)
        {
            Debug.Log("[CracklingGasStoveBehavior]: Light");
        }

        public void TurnOffGas(Burner burner)
        {
            Debug.Log("[CracklingGasStoveBehavior]: TurnOffGas");
            burner.DisableCracklingEffect();
        }
    }
}