using GasStove.Interfaces;
using UnityEngine;

namespace GasStove.Behaviors
{
    public class PoppingGasStoveBehavior : IGasStoveBehavior
    {
        public void TurnOnGas(Burner burner)
        {
            Debug.Log("[PoppingGasStoveBehavior]: TurnOnGas");
            burner.EnablePoppingEffect();
        }

        public void AdjustFlame(Burner burner)
        {
            Debug.Log("[PoppingGasStoveBehavior]: AdjustFlame");
        }

        public void TurnOffGas(Burner burner)
        {
            Debug.Log("[PoppingGasStoveBehavior]: TurnOffGas");
            burner.DisablePoppingEffect();
        }
    }
}