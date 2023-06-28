namespace CarRace;
class Program
{

    static async Task Main(string[] args)
    {
        Console.WriteLine("Welcome To Grand Prix Monaco");
        Console.WriteLine();
        Console.WriteLine("Press any key to start");
        Console.WriteLine("--------------------------------");
        Console.ReadKey();
        CarModelClass firstCar = new CarModelClass()
        {
            Id = 1,
            Name = "Ferrari ",
            Speed = 120,
            TimeSec = 0,
            DistanceKm = 0,
            PenaltyTimer = 0,
            PreviousChance = 0
        };
        CarModelClass secondCar = new CarModelClass()
        {
            Id = 2,
            Name = "Mercedes Benz",
            Speed = 120,
            TimeSec = 0,
            DistanceKm = 0,
            PenaltyTimer = 0,
            PreviousChance = 0
        };

        CarModelClass thirdCar = new CarModelClass()
        {
            Id = 2,
            Name = "Red Bull",
            Speed = 120,
            TimeSec = 0,
            DistanceKm = 0,
            PenaltyTimer = 0,
            PreviousChance = 0
        };
        List<CarModelClass> carList = new()
        {
                firstCar, secondCar, thirdCar
        };


        bool first = false;
        int racelength = 10;
        var taskFirst = RunRace(firstCar, racelength);
        var taskSecond = RunRace(secondCar, racelength);
        var taskThird = RunRace(thirdCar, racelength);
        var carStatusTask = RaceStatus(carList, racelength);
        var raceTasks = new List<Task> { taskFirst, taskSecond, taskThird, carStatusTask };


        while (raceTasks.Count > 0)
        {
            Task finishedTask = await Task.WhenAny(raceTasks);
            if (finishedTask == carStatusTask)
            {
                Console.WriteLine("Race Done");
            }
            else if (finishedTask == taskFirst)
            {

                if (first == false)
                {
                    first = true;
                    Console.WriteLine($"{firstCar.Name} has crossed the finished line first with {firstCar.TimeSec} Sec {firstCar.Speed} Km/h");
                    Console.WriteLine("--------------------------------");
                }
                else
                {
                    Console.WriteLine($"{firstCar.Name} has crossed the finished line with {firstCar.TimeSec} Sec {firstCar.Speed} Km/h");
                    Console.WriteLine("--------------------------------");
                }
            }
            else if (finishedTask == taskSecond)
            {
                if (first == false)
                {
                    first = true;
                    Console.WriteLine($"{secondCar.Name} has crossed the finished line first with {secondCar.TimeSec} Sec {secondCar.Speed} Km/h");
                    Console.WriteLine("--------------------------------");
                }
                else
                {
                    Console.WriteLine($"{secondCar.Name} has crossed the finished line with {secondCar.TimeSec} Sec {secondCar.Speed} Km/h");
                    Console.WriteLine("--------------------------------");
                }
            }

            else if (finishedTask == taskThird)
            {
                if (first == false)
                {
                    first = true;
                    Console.WriteLine($"{thirdCar.Name} has crossed the finished line first with {thirdCar.TimeSec} Sec {thirdCar.Speed} Km/h");
                    Console.WriteLine("--------------------------------");
                }
                else
                {
                    Console.WriteLine($"{thirdCar.Name} has crossed the finished line with {thirdCar.TimeSec} Sec {thirdCar.Speed} Km/h");
                    Console.WriteLine("--------------------------------");
                }
            }
            await finishedTask;
            raceTasks.Remove(finishedTask);
        }

    }

    public async static Task Wait(int delay = 1)
    {
        await Task.Delay(TimeSpan.FromSeconds(delay));
    }


    public static async Task<CarModelClass> RunRace(CarModelClass car, int racelength)
    {
        Console.WriteLine($"{car.Name} starts the race");
        Console.WriteLine("--------------------------------");
        Random random = new();
        int ticTracker = 0;
        while (car.DistanceKm < racelength)
        {
            await Wait();
            ticTracker += 1;
            car.TimeSec += 1;
            if (ticTracker % 30 == 0)
            {
                int chance = random.Next(1, 51);


                if (chance == 1)
                {
                    if (car.PreviousChance == chance)
                    {
                        Console.WriteLine($"Status: {car.Name}'s pit crew dont seem to know what they are doing and lose another 30 sec");
                        Console.WriteLine("--------------------------------");
                        await Wait(30);
                    }
                    else
                    {
                        Console.WriteLine($"Status: {car.Name} has run out of gas. Refuling for 30 sec");
                        Console.WriteLine("--------------------------------");
                        await Wait(30);
                    }
                    car.PenaltyTimer += 30;
                }
                else if (chance >= 2 && chance <= 3)
                {
                    if (car.PreviousChance >= 2 && car.PreviousChance <= 3)
                    {
                        Console.WriteLine($"Status: {car.Name}'s crew dont know which way to turn the bolts and lose another 20 sec");
                        Console.WriteLine("--------------------------------");
                        await Wait(20);

                    }

                    else
                    {
                        Console.WriteLine($"Status: {car.Name} is changing tiers for 15 sec");
                        Console.WriteLine("--------------------------------");
                        await Wait();
                    }
                    car.PenaltyTimer += 20;
                }
                else if (chance >= 4 && chance <= 8)
                {
                    if (car.PreviousChance >= 4 && car.PreviousChance <= 8)
                    {
                        Console.WriteLine($"Status: {car.Name}'s driver is still trying to get the bug out and loses another 10 sec");
                        Console.WriteLine("--------------------------------");
                        await Wait(10);
                    }
                    else
                    {
                        Console.WriteLine($"Status: {car.Name} lost 15 sec trying to get a bug out of the car");
                        Console.WriteLine("--------------------------------");
                        await Wait(15);
                    }
                    car.PenaltyTimer += 10;
                }
                else if (chance >= 41 && chance <= 50)
                {
                    if (car.PreviousChance >= 41 && car.PreviousChance <= 50)
                    {
                        Console.WriteLine($"Status: {car.Name}'s has Engine problem we can see & lost 1kmh speed");
                        Console.WriteLine("--------------------------------");
                    }
                    else
                    {
                        Console.WriteLine($"Status: {car.Name}'s has Engine problem we can see & lost 1kmh speed");
                        Console.WriteLine("--------------------------------");
                    }
                    car.Speed -= 1;
                }
                car.PreviousChance = chance;


            }



            if (car.PenaltyTimer > 0)
            {
                car.PenaltyTimer += -1;
            }
            else
            {
                car.DistanceKm += car.Speed / Math.Pow(60, 2);

            }

        }

        return car;
    }





    public async static Task RaceStatus(List<CarModelClass> cars, int racelength)
    {
        Console.WriteLine();
        Console.WriteLine("Press Enter for see status in FM1 Grand prix Monaco");
        Console.WriteLine("--------------------------------");
        Console.WriteLine();


        await Task.Delay(1);

        cars.ForEach(Car =>
        {
            Console.WriteLine($"Status: {Car.Name}: {Car.DistanceKm}Km {Car.TimeSec}Sec {Car.Speed}Km/h");
            Console.WriteLine("--------------------------------");
            Console.WriteLine();

        });

        while (true)
        {


            bool gotkey = false;
            DateTime start = DateTime.Now;

            while ((DateTime.Now - start).TotalSeconds < 1)
            {
                if (Console.KeyAvailable)
                {
                    gotkey = true;
                    break;
                }
            }
            if (gotkey == true)
            {
                var s = Console.ReadKey();
                cars.ForEach(Car =>
                {
                    Console.WriteLine($"Status: {Car.Name}: {Car.DistanceKm}Km {Car.TimeSec}Sec {Car.Speed}Km/h");
                    Console.WriteLine("--------------------------------");
                });
                gotkey = false;
            }

            var finishedRace = cars.Select(car => car.RemainingDistance(racelength)).Sum();
            if (finishedRace <= 0)
            {
                cars.ForEach(Car =>
                {
                    Console.WriteLine($"Status: {Car.Name}: {racelength}Km & Finished at {Car.TimeSec}Sec {Car.Speed}Km/h");
                    Console.WriteLine("--------------------------------");
                });
                return;
            }
        }
    }

}
