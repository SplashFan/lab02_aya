//Задание 1
Console.WriteLine("Задание 1\n");
Pupil p1 = new Pupil("Ivan");
Pupil p2 = new BadPupil("Anton");
Pupil p3 = new GoodPupil("Kolya");
Pupil p4 = new ExellentPupil("Grzegorz Brzęczyszczykiewicz");

var firstClassRoom = new ClassRoom(p1);
var secondClassRoom = new ClassRoom(p1, p2);
var thirdClassRomm = new ClassRoom(p1, p2, p3);
var forthClassRomm = new ClassRoom(p1, p2, p3, p4);
forthClassRomm.GetPupilsRead();

//Задание 2
Console.WriteLine("Задание 2\n");
Plane plane1 = new Plane(25000, 500, 2021, 200, 50);
plane1.Show();

Ship ship1 = new Ship(15000, 120, 2019, "Северный порт", 100);
ship1.Show();

Car car1 = new Car(12000, 180, 2009);
car1.Show();

//Задание 3
Console.WriteLine("Задание 3\n");
const string PRO_LICENSE = "111";
const string EXP_LICENSE = "222";

Console.WriteLine("Введите ключ доступа");
var license = Console.ReadLine();

DocumentWorker worker;

switch (license)
{
    case PRO_LICENSE: worker = new ProDocumentWorker(); break;
    case EXP_LICENSE: worker = new ExpertDocumentWorker(); break;
    default: worker = new DocumentWorker(); break;
}

while (true)
{
    Console.WriteLine("Enter Command (o/e/s/q): ");
    switch (Console.ReadLine())
    {
        case "o": worker.OpenDocument(); break;
        case "e": worker.EditDocument(); break;
        case "s": worker.SaveDocument(); break;
        case "q": return;
    }
}
public class Pupil //Класс для задания 1
{
    public string PupilName;

    public Pupil(string name)
    {
        PupilName = name;
    }

    private string GetPupilNameAndStatus()
    {
        return String.Format("{0} {1}", GetType().Name, PupilName);
    }

    public virtual void Read()
    {
        Console.WriteLine("{0} {1}", GetPupilNameAndStatus(), "Читает");
    }

    public virtual void Write()
    {
        Console.WriteLine("{0} {1}", GetPupilNameAndStatus(), "Пишет");
    }

    public virtual void Relax()
    {
        Console.WriteLine("{0} {1}", GetPupilNameAndStatus(), "Отдыхает");
    }

    public virtual void Study()
    {
        Console.WriteLine("{0} {1}", GetPupilNameAndStatus(), "Учится");
    }
}

public class ExellentPupil : Pupil
{
    public ExellentPupil(string name) : base(name)
    { }
    public override void Read()
    {
        Console.WriteLine("ExcellentPupil {0} читает больше всех", PupilName);
    }
    public override void Write()
    {
        Console.WriteLine("ExcellentPupil {0} пишет больше всех", PupilName);
    }
    public override void Relax()
    {
        Console.WriteLine("ExcellentPupil {0} отдыхает меньше всех", PupilName);
    }
    public override void Study()
    {
        Console.WriteLine("ExcellentPupil {0} учится больше всех", PupilName);
    }
}

public class GoodPupil : Pupil
{
    public GoodPupil(string name) : base(name)
    { }
}

public class BadPupil : Pupil
{
    public BadPupil(string name)
        : base(name)
    { }
    public override void Read()
    {
        Console.WriteLine("BadPupil {0} читает меньше всех", PupilName);
    }
    public override void Write()
    {
        Console.WriteLine("BadPupil {0} пишет меньше всех", PupilName);
    }
    public override void Relax()
    {
        Console.WriteLine("BadPupil {0} отдыхает больше всех", PupilName);
    }
    public override void Study()
    {
        Console.WriteLine("BadPupil {0} учится меньше всех", PupilName);
    }
}

public class ClassRoom
{
    public readonly List<Pupil> Pupils = new List<Pupil>();
    public ClassRoom(params Pupil[] pupils)
    {
        Pupils.AddRange(pupils);
    }
    public void GetPupilsRead()
    {
        foreach (var pupil in Pupils)
        {
            pupil.Read();
        }
    }
}

class Vehicle //Класс для задания 2
{
    private int Price;
    private int Speed;
    private int ReleaseDate;
    private int CountOfPassangers;

    public Vehicle(int price, int speed, int releaseDate)
    {
        this.Price = price;
        this.Speed = speed;
        this.ReleaseDate = releaseDate;
    }

    public Vehicle(int price, int speed, int releaseDate, int countOfPassangers)
    {
        this.Price = price;
        this.Speed = speed;
        this.ReleaseDate = releaseDate;
        this.CountOfPassangers = countOfPassangers;
    }

    public virtual void Show()
    {
        Console.WriteLine("Цена средства передвижения {0} ", Price);
        Console.WriteLine("Скорость {0} ", Speed);
        Console.WriteLine("Дата выпуска {0} ", ReleaseDate);
        Console.WriteLine("Число пассажиров {0} ", CountOfPassangers);
    }
}

class Plane : Vehicle
{
    private int Height;

    public Plane(int price, int speed, int releaseDate, int height, int countOfPassangers) : base(price, speed, releaseDate, countOfPassangers)
    {

        this.Height = height;
    }

    public override void Show()
    {
        Console.WriteLine("\nЭто самолет");
        base.Show();
        Console.WriteLine("Высота полета {0}", Height);
    }

}
class Ship : Vehicle
{
    private string Port;

    public Ship(int price, int speed, int releaseDate, string port, int countOfPassangers) : base(price, speed, releaseDate, countOfPassangers)
    {
        this.Port = port;
    }

    public override void Show()
    {
        Console.WriteLine("\nЭто лодка");
        base.Show();
        Console.WriteLine("В порту {0}", Port);
    }
}

class Car : Vehicle
{
    public Car(int price, int speed, int releaseDate) : base(price, speed, releaseDate)
    {

    }
    public override void Show()
    {
        Console.WriteLine("\nЭто машина");
        base.Show();
    }
}

class DocumentWorker //Класс для задания 3
{
    public virtual void OpenDocument()
    {
        Console.WriteLine("Документ открыт");
    }

    public virtual void EditDocument()
    {
        Console.WriteLine("Редактирование документа доступно в версии Про");
    }

    public virtual void SaveDocument()
    {
        Console.WriteLine("Сохранение документа доступно в версии Про");
    }
}

class ProDocumentWorker : DocumentWorker
{
    public override void EditDocument()
    {
        Console.WriteLine("Документ отредактирован");
    }

    public override void SaveDocument()
    {
        Console.WriteLine("Документ сохранен в старом формате, сохранение в остальных форматах доступно в версии Эксперт");
    }
}

class ExpertDocumentWorker : ProDocumentWorker
{
    public override void SaveDocument()
    {
        Console.WriteLine("Документ сохранен в новом формате");
    }
}