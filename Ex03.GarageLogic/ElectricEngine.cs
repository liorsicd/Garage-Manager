namespace Ex03.GarageLogic
{
    public class ElectricEngine : EnergySource
    {
        public ElectricEngine(EnergySource.eEnergyTypes i_EnergyType)
            : base(i_EnergyType)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
