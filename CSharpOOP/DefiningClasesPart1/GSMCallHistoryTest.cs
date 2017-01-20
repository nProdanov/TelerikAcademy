namespace GSMModels
{
    using System;
    class GSMCallHistoryTest
    {
        static int LongestCall(GSM gsm)
        {
            int pos=0;
            ulong max = ulong.MinValue;
            for (int i = 0; i <gsm.CallHistory.Count ; i++)
            {
                ulong currentDuration = gsm.CallHistory[i].Duration;
                if (max< currentDuration)
                {
                    max = currentDuration;
                    pos =i;
                }   

            }
            return pos;
        }

        public static void TestCallshistory()
        {
            GSM beautifulGSM = new GSM("130", "Nokia");
            beautifulGSM.AddCall(2016, 05, 21, 21, 23, 50, "+359888777666", 120);
            beautifulGSM.AddCall(2016, 05, 01, 20, 23, 52, "+359888555444", 60);
            beautifulGSM.AddCall(2016, 05, 17, 15, 53, 20, "+359888222333", 60);
            beautifulGSM.AddCall(2016, 05, 11, 15, 33, 10, "+359888999222", 360);
            beautifulGSM.AddCall(2016, 05, 13, 11, 26, 29, "+359888111222", 180);
            beautifulGSM.AddCall(2014, 4, 4, 22, 45, 45, "+359888888888", 60);
            
            beautifulGSM.PrintCallHistory();

            beautifulGSM.PrintCallPrice();

            int posLongestCall = GSMCallHistoryTest.LongestCall(beautifulGSM);
            beautifulGSM.DeleteCall(beautifulGSM.CallHistory[posLongestCall]);
          
            beautifulGSM.PrintCallPrice();

            beautifulGSM.ClearHistory();
            beautifulGSM.PrintCallHistory();
        }
    }
}
