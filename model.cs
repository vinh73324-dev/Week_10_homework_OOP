/****************
Mã sinh viên: 202419018
Họ tên: Phạm Văn Vinh
****************/ 
using System;

#region Device Model
public interface IDevice
{
    void TurnOn();
    void TurnOff();
}

public interface ILockable
{
    void Lock();
    void Unlock();
}

public class SmartLight: IDevice
{
    public string Name {get; private set;}

    public SmartLight(string name)
    {
        Name = name;
    }

    public void TurnOn()
    {
        Console.WriteLine($"{Name}: ON");
    }

    public void TurnOff()
    {
        Console.WriteLine($"{Name}: OFF");
    }
}

public class SmartFan: IDevice
{
    public string Name {get; private set;}

    public SmartFan(string name)
    {
        Name = name;
    }

    public void TurnOn()
    {
        Console.WriteLine($"{Name}: ON");
    }

    public void TurnOff()
    {
        Console.WriteLine($"{Name}: OFF");
    }
}

public class SmartDoor: IDevice, ILockable
{
    public string Name {get; private set;}

    public SmartDoor(string name)
    {
        Name = name;
    }

    public void TurnOn()
    {
        Console.WriteLine($"{Name}: ON");
    }

    public void TurnOff()
    {
        Console.WriteLine($"{Name}: OFF");
    }

    public void Lock()
    {
        Console.WriteLine($"{Name}: LOCKED");
    }

    public void Unlock()
    {
        Console.WriteLine($"{Name}: UNLOCKED");
    }
}

#endregion

#region Factory
public static class DeviceFactory
{
    public static IDevice Create(string type, string name)
    {
        return type.Trim().ToLowerInvariant() switch
        {
            "light" => new SmartLight(name),
            "fan"   => new SmartFan(name),
            "door"  => new SmartDoor(name),
            _       => throw new ArgumentException($"Unsupported device type: {type}")
        };
    }
}

#endregion

#region Singleton
public sealed class HomeConfiguration
{
    private static readonly Lazy<HomeConfiguration> lazy = new(() => new HomeConfiguration());
    public static HomeConfiguration Instance => lazy.Value;

    public string HomeName {get; set;} = "My Home";
    public int NightLightLevel {get; set;} = 30;

    private HomeConfiguration(){}
}
#endregion

#region Facade
public sealed class SmartHomeFacade
{
    private readonly IDevice light;
    private readonly IDevice fan;
    private readonly ILockable door;

    public SmartHomeFacade(
        IDevice light,
        IDevice fan,
        ILockable door
    )
    {
        this.light = light;
        this.fan = fan;
        this.door = door;
    }

    public void GoToWork()
    {
        light.TurnOff();
        fan.TurnOff();
        door.Lock();
    }

    public void GoToSleep()
    {
        fan.TurnOff();
        door.Lock();
        light.TurnOn();

        int level = HomeConfiguration.Instance.NightLightLevel;
        Console.WriteLine($"Night light level: {level}%");
    }
}
#endregion
