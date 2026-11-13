/****************
Mã sinh viên: 202419018
Họ tên: Phạm Văn Vinh
****************/ 

using System;

class Program
{
    static void Main(string[] args)
    {
        // T1. Tao light, fan, door
        Console.WriteLine("T1. Tao light, fan, door");
        IDevice smart_light = DeviceFactory.Create("LIGHT", "Den ngu thong minh Rang Dong");
        IDevice smart_fan = DeviceFactory.Create("FaN", "Quat thong minh Daikin");
        IDevice smart_door = DeviceFactory.Create("dOoR", "Cua thong minh Advanced");

        // T2. Tao loai camera khi chua ho tro
        SeperateLine();
        Console.WriteLine("T2. Tao loai camera khi chua ho tro");
        try
        {
            var camera = DeviceFactory.Create("Camera", "Camera NIKON 26");
        }
        catch(ArgumentException ex)
        {
            Console.WriteLine($"Da bat ngoai le {ex.GetType().Name}");
            Console.WriteLine($"{ex.Message}");
        }

        // T3. Lay HomeConfiguration.Instance hai lan
        SeperateLine();
        Console.WriteLine("T3. Lay HomeConfiguration.Instance hai lan");
        var config1 = HomeConfiguration.Instance;
        var config2 = HomeConfiguration.Instance;

        if(!ReferenceEquals(config1, config2))
        {
            Console.WriteLine("config1 va config2 khong cung tham chieu den cung 1 doi tuong");
        }
        else
        {
            Console.WriteLine("Ca 2 bien cung tham chieu cung 1 doi tuong");
        }

        // T4. Goi GoToWork()
        SeperateLine();
        Console.WriteLine("T4. Goi GoToWork()");
        var facade = new SmartHomeFacade(smart_light, smart_fan, (ILockable)smart_door);
        facade.GoToWork();

        // T5. Goi GoToSleep()
        SeperateLine();
        Console.WriteLine("T5. Goi GoToSleep()");
        facade.GoToSleep();

    }

    static void SeperateLine()
    {   
        Console.WriteLine(new string('-', 40));
    }
}
