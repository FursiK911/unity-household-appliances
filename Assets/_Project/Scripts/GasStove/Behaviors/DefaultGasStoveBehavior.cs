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
                burner.ChangeGasEffect(burner.CurrentGasStrength);
            }
            else
            {
                burner.ChangeBurnerEffect(burner.CurrentGasStrength);
            }
        }
        public void Light(Burner burner)
        {
            Debug.Log("[DefaultGasStoveBehavior] Light");
            burner.DisableGasEffect();
            burner.ChangeBurnerEffect(burner.CurrentGasStrength);
        }
        public void TurnOffGas(Burner burner) 
        {
            Debug.Log("[DefaultGasStoveBehavior] TurnOffGas");
            burner.DisableGasEffect();
            burner.DisableBurnerEffect();
        }
    }
}