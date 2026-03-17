using GasStove.Interfaces;
using UnityEngine;

namespace GasStove.Behaviors
{
    public class DefaultGasStoveBehavior: IGasStoveBehavior
    {
        public void TurnOnGas(Burner burner) 
        {
            Debug.Log("[DefaultGasStoveBehavior] TurnOnGas");
            burner.EnableGasEffect();
        }
        public void AdjustFlame(Burner burner)
        {
            Debug.Log("[DefaultGasStoveBehavior] AdjustFlame");
            burner.DisableGasEffect();
            burner.EnableBurnerEffect();
        }
        public void TurnOffGas(Burner burner) 
        {
            Debug.Log("[DefaultGasStoveBehavior] TurnOffGas");
            burner.DisableGasEffect();
            burner.DisableBurnerEffect();
        }
    }
}