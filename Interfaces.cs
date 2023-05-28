using System; 
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first
{
    // Структура "Координата"
    public struct Coordinate
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }

    // Интерфейс "IFlyable"
    public interface IFlyable
    {
        void FlyTo(Coordinate newPosition);
        double GetFlyTime(Coordinate newPosition);
    }

    // Класс "Птица"
    public class Bird : IFlyable
    {
        public Coordinate CurrentPosition { get; set; }
        private readonly Random random = new Random();
        private const double MaxBirdSpeed = 20.0; // Максимальная скорость птицы (км/ч)

        public void FlyTo(Coordinate newPosition)
        {
            Console.WriteLine($"Птица летит от ({CurrentPosition.X}, {CurrentPosition.Y}, {CurrentPosition.Z}) до ({newPosition.X}, {newPosition.Y}, {newPosition.Z})");
            CurrentPosition = newPosition;
        }

        public double GetFlyTime(Coordinate newPosition)
        {
            double distance = CalculateDistance(CurrentPosition, newPosition);
            double speed = random.NextDouble() * MaxBirdSpeed; // Случайная скорость птицы (0-20 км/ч)
            double flyTime = distance / speed;
            return flyTime;
        }

        private double CalculateDistance(Coordinate position1, Coordinate position2)
        {
            double distance = Math.Sqrt(Math.Pow(position2.X - position1.X, 2) +
                                        Math.Pow(position2.Y - position1.Y, 2) +
                                        Math.Pow(position2.Z - position1.Z, 2));
            return distance;
        }
    }

    // Класс "Самолет"
    public class Airplane : IFlyable
    {
        public Coordinate CurrentPosition { get; set; }
        private const double InitialAirplaneSpeed = 200.0; // Начальная скорость самолета (км/ч)
        private const double SpeedIncreaseRate = 10.0; // Коэффициент увеличения скорости самолета (км/ч)
        private const double DistanceThreshold = 10.0; // Порог расстояния для увеличения скорости самолета (км)

        public void FlyTo(Coordinate newPosition)
        {
            Console.WriteLine($"Самолет летит от ({CurrentPosition.X}, {CurrentPosition.Y}, {CurrentPosition.Z}) до ({newPosition.X}, {newPosition.Y}, {newPosition.Z})");
            CurrentPosition = newPosition;
        }

        public double GetFlyTime(Coordinate newPosition)
        {
            double distance = CalculateDistance(CurrentPosition, newPosition);
            double flyTime = 0;

            if (distance <= DistanceThreshold)
            {
                flyTime = distance / InitialAirplaneSpeed;
            }
            else
            {
                double additionalDistance = distance - DistanceThreshold;
                double totalSpeed = InitialAirplaneSpeed + (SpeedIncreaseRate * (additionalDistance / DistanceThreshold));
                flyTime = (DistanceThreshold / InitialAirplaneSpeed) + (additionalDistance / totalSpeed);
            }

            return flyTime;
        }

        private double CalculateDistance(Coordinate position1, Coordinate position2)
        {
            double distance = Math.Sqrt(Math.Pow(position2.X - position1.X, 2) +
                                        Math.Pow(position2.Y - position1.Y, 2) +
                                        Math.Pow(position2.Z - position1.Z, 2));
            return distance;
        }
    }

    // Класс "Дрон"
    public class Drone : IFlyable
    {
        public Coordinate CurrentPosition { get; set; }
        private const double DroneSpeed = 40.0; // Скорость дрона (км/ч)
        private const double HoverDuration = 1.0; // Длительность зависания дрона (мин)
        private const double MaxDroneRange = 1000.0; // Максимальная дальность полета дрона (км)

        public void FlyTo(Coordinate newPosition)
        {
            Console.WriteLine($"Дрон летит от ({CurrentPosition.X}, {CurrentPosition.Y}, {CurrentPosition.Z}) до ({newPosition.X}, {newPosition.Y}, {newPosition.Z})");
            CurrentPosition = newPosition;
        }

        public double GetFlyTime(Coordinate newPosition)
        {
            double distance = CalculateDistance(CurrentPosition, newPosition);

            // Проверка ограничения на дальность полета дрона
            if (distance > MaxDroneRange)
            {
                Console.WriteLine("Дрон не может лететь на такое расстояние.");
                return -1; // Возврат -1, чтобы указать ошибку
            }

            double flyTime = distance / DroneSpeed;

            // Учет зависания дрона
            double hoverCount = flyTime / 10.0;
            double hoverTime = Math.Floor(hoverCount) * HoverDuration;
            flyTime += hoverTime;

            return flyTime;
        }

        private double CalculateDistance(Coordinate position1, Coordinate position2)
        {
            double distance = Math.Sqrt(Math.Pow(position2.X - position1.X, 2) +
                                        Math.Pow(position2.Y - position1.Y, 2) +
                                        Math.Pow(position2.Z - position1.Z, 2));
            return distance;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Создание объектов и вызов методов
            Bird bird = new Bird();
            bird.CurrentPosition = new Coordinate { X = 0, Y = 0, Z = 0 };
            Coordinate birdDestination = new Coordinate { X = 100, Y = 100, Z = 100 };
            double birdFlyTime = bird.GetFlyTime(birdDestination);
            bird.FlyTo(birdDestination);
            Console.WriteLine($"Время полета птицы: {birdFlyTime} ч");

            Airplane airplane = new Airplane();
            airplane.CurrentPosition = new Coordinate { X = 0, Y = 0, Z = 0 };
            Coordinate airplaneDestination = new Coordinate { X = 500, Y = 500, Z = 500 };
            double airplaneFlyTime = airplane.GetFlyTime(airplaneDestination);
            airplane.FlyTo(airplaneDestination);
            Console.WriteLine($"Время полета самолета: {airplaneFlyTime} ч");

            Drone drone = new Drone();
            drone.CurrentPosition = new Coordinate { X = 0, Y = 0, Z = 0 };
            Coordinate droneDestination = new Coordinate { X = 1200, Y = 1200, Z = 1200 }; // Дрон не может полететь на такую дальность
            double droneFlyTime = drone.GetFlyTime(droneDestination);
            drone.FlyTo(droneDestination);
            if (droneFlyTime != -1)
            {
                Console.WriteLine($"Время полета дрона: {droneFlyTime} ч");
            }

            Console.ReadLine();
        }
    }
}
