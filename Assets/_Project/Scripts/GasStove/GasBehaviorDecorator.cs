using GasStove.Interfaces;

namespace GasStove.Behaviors
{
    public abstract class GasBehaviorDecorator : IGasStoveBehavior
    {
        protected IGasStoveBehavior _inner;

        public GasBehaviorDecorator(IGasStoveBehavior inner)
        {
            _inner = inner;
        }

        public virtual void TurnOnGas(Burner burner) => _inner.TurnOnGas(burner);
        public void AdjustFlame(Burner burner)
        {
            _inner.AdjustFlame(burner);
        }
        public virtual void TurnOffGas(Burner burner) => _inner.TurnOffGas(burner);
    }
}