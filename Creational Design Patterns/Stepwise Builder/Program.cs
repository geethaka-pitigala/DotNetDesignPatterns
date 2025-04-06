public class Program
{
    public static void Main(string[] args)
    {
        var carBuilder = new CarBuilder();
        var car = carBuilder.Create().OfType(CarType.SUV)
            .OfWheelSize(20)
            .Build();
        Console.WriteLine(car);
    }
}

public enum CarType{
    Sedan,
    SUV,
    Truck
}

public class Car{
    public CarType Type { get; set;}
    public int WheelSize { get; set;}

    public override string ToString(){
        return $"Car Type: {Type}, Wheel Size: {WheelSize}";
    }

}

public interface ISpecifyCarType{
    public ISpecifyWheelSize OfType(CarType type);
}

public interface ISpecifyWheelSize{
    public IBuildCar OfWheelSize(int size);
}

public interface IBuildCar{
    public Car Build();
}

public class CarBuilder{
    private Implementation _implementation = new Implementation();

    public ISpecifyCarType Create(){
        return _implementation;
    }

    private class Implementation: ISpecifyCarType, ISpecifyWheelSize, IBuildCar{
        private Car _car = new Car();

        public ISpecifyWheelSize OfType(CarType type){
            _car.Type = type;
            return 
            this;
        }

        public IBuildCar OfWheelSize(int size){
            switch (_car.Type){
                case CarType.SUV:
                    if (size < 18) throw new ArgumentException("SUVs must have a wheel size of at least 18 inches.");
                    break;
                case CarType.Truck:
                    if (size < 20) throw new ArgumentException("Trucks must have a wheel size of at least 20 inches.");
                    break;
                default:
                    if (size < 16) throw new ArgumentException("Sedans must have a wheel size of at least 16 inches.");
                    break;
            }

            _car.WheelSize = size;
            return this;
        }

        public Car Build(){
            return _car;
        }
    }
}