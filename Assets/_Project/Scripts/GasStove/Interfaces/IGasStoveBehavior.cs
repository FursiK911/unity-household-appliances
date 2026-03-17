namespace GasStove.Interfaces
{
    public interface IGasStoveBehavior
    {
        void TurnOnGas(Burner burner);
        void AdjustFlame(Burner burner);
        void TurnOffGas(Burner burner);
    }
}