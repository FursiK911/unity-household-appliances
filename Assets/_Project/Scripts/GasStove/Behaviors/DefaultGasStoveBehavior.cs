using GasStove.Interfaces;
using UnityEngine;

namespace GasStove.Behaviors
{
    public class DefaultGasStoveBehavior: IGasStoveBehavior
    {
        public void TurnOnGas(Burner burner) 
        {
            Debug.Log("[DefaultGasStoveBehavior] TurnOnGas");
            if (!burner.IsBurning)
            {
                burner.EnableGasEffect();
            }
            else
            {
                burner.EnableBurnerEffect();
            }
        }
        public void Light(Burner burner)
        {
            Debug.Log("[DefaultGasStoveBehavior] Light");
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