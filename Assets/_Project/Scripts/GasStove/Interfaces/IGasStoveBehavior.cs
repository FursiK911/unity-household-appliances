namespace GasStove.Interfaces
{
    public interface IGasStoveBehavior
    {
        void TurnOnGas(Burner burner);
        void Light(Burner burner);
        void TurnOffGas(Burner burner);
    }
}