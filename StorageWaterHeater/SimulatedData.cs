using System;
using System.Collections.Generic;
using System.Text;

namespace StorageWaterHeater
{
    class SimulatedData
    {
        

        public static List<List<double>> GetLiveTable()
        {
            List<List<double>> liveTable = new List<List<double>>();
            liveTable.Add(TemperatureData(30.0,35.0));
            liveTable.Add(TemperatureData(30.0,35.0));
            liveTable.Add(TemperatureData(30.0,35.0));
            liveTable.Add(TemperatureData(30.0,35.0));
            liveTable.Add(TemperatureData(30.0,35.0));
            liveTable.Add(TemperatureData(30.0,35.0));
            return liveTable;
        }


        public static List<double> TemperatureData(double min, double max)
        {
            List<double> TemperatureDataArray = new List<double>();
            Random randNum = new Random();

            for (int i = 0; i < 30; i++)
            {
                double a = randNum.NextDouble();
                double b = max - min;
                double c = a * b;
                double d = c + min;
                TemperatureDataArray.Insert(i, d);
            }
            return TemperatureDataArray;
        }

        public static List<double> ElectricalData(double min, double max)
        {
            List<double> ElectricalDataArray = new List<double>();
            Random randNum = new Random();

            for (int i = 0; i < 36; i++)
            {
                double a = randNum.NextDouble();
                double b = max - min;
                double c = a * b;
                double d = c + min;
                ElectricalDataArray.Insert(i, d);
            }
            return ElectricalDataArray;
        }

        public static List<double> FlowSVData(double min, double max)
        {
            List<double> FlowSVDataArray = new List<double>();
            Random randNum = new Random();

            for (int i = 0; i < 6; i++)
            {
                double a = randNum.NextDouble();
                double b = max - min;
                double c = a * b;
                double d = c + min;
                FlowSVDataArray.Insert(i, d);
            }
            return FlowSVDataArray;
        }

        public static List<double> FlowData(double min, double max)
        {
            List<double> FlowDataArray = new List<double>();
            Random randNum = new Random();

            for (int i = 0; i < 12; i++)
            {
                double a = randNum.NextDouble();
                double b = max - min;
                double c = a * b;
                double d = c + min;
                FlowDataArray.Insert(i, d);
            }
            return FlowDataArray;
        }
    }
}