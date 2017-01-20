namespace GSMModels
{
    using System;
    using System.Collections.Generic;
    class GSMTest
    {
        public static void TestGSM()
        {
            List<GSM> GSMArray = new List<GSM>();
            GSMArray.Add(new GSM("iPhone 6s", "Apple", 1000, "Nikolay", new Battery("2200Mah", 30, 12, BatteryType.Li_Po), new Display(4.7, 256000000)));
            GSMArray.Add(new GSM("Galaxy S7", "Samsung", 1300, "Gencho", new Battery("2500Mah", 50, 11, BatteryType.Li_Ion), new Display(5.3, 256000000)));
            GSMArray.Add(new GSM("G5", "LG", 1200, "Stanko", new Battery("3300Mah", 50, 11, BatteryType.Li_Ion), new Display(5.5, 256000000)));
            GSMArray.Add(new GSM("Desire 820", "HTC"));
            GSMArray.Add(new GSM("P9", "Huawei"));
            GSMArray.Add(GSM.iPhone4s);

            for (int i = 0; i < GSMArray.Count; i++)
            {
                Console.WriteLine(GSMArray[i]);
                Console.WriteLine();
            }

            

        }

    }
}
