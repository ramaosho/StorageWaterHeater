using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Printing;
using System.Text;
using System.Windows;
using StorageWaterHeater;
using SharpModbus;

namespace StorageWaterHeater
{
    public class ProcessData
    {
        public static List<List<double>> MasterDataView = new List<List<double>>();

        public static List<List<double>> LiveTableView()
        {
            List<double> ColumnOneData = new List<double>(14);
            List<double> ColumnTwoData = new List<double>(14);
            List<double> ColumnThreeData = new List<double>(14);
            List<double> ColumnFourData = new List<double>(14);
            List<double> ColumnFiveData = new List<double>(14);
            List<double> ColumnSixData = new List<double>(14);

            List<double> Row01 = new List<double>(6);
            List<double> Row02 = new List<double>(6);
            List<double> Row03 = new List<double>(6);
            List<double> Row04 = new List<double>(6);
            List<double> Row05 = new List<double>(6);
            List<double> Row06 = new List<double>(6);
            List<double> Row07 = new List<double>(6);
            List<double> Row08 = new List<double>(6);
            List<double> Row09 = new List<double>(6);
            List<double> Row10 = new List<double>(6);
            List<double> Row11 = new List<double>(6);
            List<double> Row12 = new List<double>(6);
            List<double> Row13 = new List<double>(6);
            List<double> Row14 = new List<double>(6);

            List<double> TemperatureArray = new List<double>(30);
            List<double> FlowSVDataArray = new List<double>(6);
            List<double> FlowDataArray = new List<double>(12);
            List<double> ElectricalDataArray = new List<double>(36);

            TemperatureArray = SimulatedData.TemperatureData(30.0, 35.0);
            FlowSVDataArray = SimulatedData.FlowSVData(2.0, 20.0);
            FlowDataArray = SimulatedData.FlowData(0.0, 16.0);
            ElectricalDataArray = SimulatedData.ElectricalData(200.0, 235.0);


            /*Row01 Data*/
            Row01.Insert(0, TemperatureArray[0]);
            Row01.Insert(1, TemperatureArray[5]);
            Row01.Insert(2, TemperatureArray[10]);
            Row01.Insert(3, TemperatureArray[15]);
            Row01.Insert(4, TemperatureArray[20]);
            Row01.Insert(5, TemperatureArray[25]);

            /*Row02 Data*/
            Row02.Insert(0, TemperatureArray[1]);
            Row02.Insert(1, TemperatureArray[6]);
            Row02.Insert(2, TemperatureArray[11]);
            Row02.Insert(3, TemperatureArray[16]);
            Row02.Insert(4, TemperatureArray[21]);
            Row02.Insert(5, TemperatureArray[26]);

            /*Row03 Data*/
            Row03.Insert(0, TemperatureArray[2]);
            Row03.Insert(1, TemperatureArray[7]);
            Row03.Insert(2, TemperatureArray[12]);
            Row03.Insert(3, TemperatureArray[17]);
            Row03.Insert(4, TemperatureArray[22]);
            Row03.Insert(5, TemperatureArray[27]);

            /*Row04 Data*/
            Row04.Insert(0, TemperatureArray[3]);
            Row04.Insert(1, TemperatureArray[8]);
            Row04.Insert(2, TemperatureArray[13]);
            Row04.Insert(3, TemperatureArray[18]);
            Row04.Insert(4, TemperatureArray[23]);
            Row04.Insert(5, TemperatureArray[28]);


            /*Row05 Data*/
            Row05.Insert(0, TemperatureArray[4]);
            Row05.Insert(1, TemperatureArray[9]);
            Row05.Insert(2, TemperatureArray[14]);
            Row05.Insert(3, TemperatureArray[19]);
            Row05.Insert(4, TemperatureArray[24]);
            Row05.Insert(5, TemperatureArray[29]);


            /*Row06 Data*/
            Row06.Insert(0, FlowSVDataArray[0]);
            Row06.Insert(1, FlowSVDataArray[1]);
            Row06.Insert(2, FlowSVDataArray[2]);
            Row06.Insert(3, FlowSVDataArray[3]);
            Row06.Insert(4, FlowSVDataArray[4]);
            Row06.Insert(5, FlowSVDataArray[5]);

            /*Row07 Data*/
            Row07.Insert(0, FlowDataArray[0]);
            Row07.Insert(1, FlowDataArray[2]);
            Row07.Insert(2, FlowDataArray[4]);
            Row07.Insert(3, FlowDataArray[6]);
            Row07.Insert(4, FlowDataArray[8]);
            Row07.Insert(5, FlowDataArray[10]);

            /*Row08 Data*/
            Row08.Insert(0, FlowDataArray[1]);
            Row08.Insert(1, FlowDataArray[3]);
            Row08.Insert(2, FlowDataArray[5]);
            Row08.Insert(3, FlowDataArray[7]);
            Row08.Insert(4, FlowDataArray[9]);
            Row08.Insert(5, FlowDataArray[11]);

            /*Row09 Data*/
            Row09.Insert(0, ElectricalDataArray[0]);
            Row09.Insert(1, ElectricalDataArray[6]);
            Row09.Insert(2, ElectricalDataArray[12]);
            Row09.Insert(3, ElectricalDataArray[18]);
            Row09.Insert(4, ElectricalDataArray[24]);
            Row09.Insert(5, ElectricalDataArray[30]);


            /*Row10 Data*/
            Row10.Insert(0, ElectricalDataArray[1]);
            Row10.Insert(1, ElectricalDataArray[7]);
            Row10.Insert(2, ElectricalDataArray[13]);
            Row10.Insert(3, ElectricalDataArray[19]);
            Row10.Insert(4, ElectricalDataArray[25]);
            Row10.Insert(5, ElectricalDataArray[31]);



            /* ColumnOneData */
            ColumnOneData.Insert(0, TemperatureArray[0]);
            ColumnOneData.Insert(1, TemperatureArray[1]);
            ColumnOneData.Insert(2, TemperatureArray[2]);
            ColumnOneData.Insert(3, TemperatureArray[3]);
            ColumnOneData.Insert(4, TemperatureArray[4]);

            ColumnOneData.Insert(5, FlowSVDataArray[0]);

            ColumnOneData.Insert(6, FlowDataArray[0]);
            ColumnOneData.Insert(7, FlowDataArray[1]);

            ColumnOneData.Insert(8, ElectricalDataArray[0]);
            ColumnOneData.Insert(9, ElectricalDataArray[1]);
            ColumnOneData.Insert(10, ElectricalDataArray[2]);
            ColumnOneData.Insert(11, ElectricalDataArray[3]);
            ColumnOneData.Insert(12, ElectricalDataArray[4]);
            ColumnOneData.Insert(13, ElectricalDataArray[5]);


            /* ColumnTwoData */
            ColumnTwoData.Insert(0, TemperatureArray[5]);
            ColumnTwoData.Insert(1, TemperatureArray[6]);
            ColumnTwoData.Insert(2, TemperatureArray[7]);
            ColumnTwoData.Insert(3, TemperatureArray[8]);
            ColumnTwoData.Insert(4, TemperatureArray[9]);

            ColumnTwoData.Insert(5, FlowSVDataArray[1]);

            ColumnTwoData.Insert(6, FlowDataArray[2]);
            ColumnTwoData.Insert(7, FlowDataArray[3]);

            ColumnTwoData.Insert(8, ElectricalDataArray[6]);
            ColumnTwoData.Insert(9, ElectricalDataArray[7]);
            ColumnTwoData.Insert(10, ElectricalDataArray[8]);
            ColumnTwoData.Insert(11, ElectricalDataArray[9]);
            ColumnTwoData.Insert(12, ElectricalDataArray[10]);
            ColumnTwoData.Insert(13, ElectricalDataArray[11]);


            /* ColumnThreeData */
            ColumnThreeData.Insert(0, TemperatureArray[10]);
            ColumnThreeData.Insert(1, TemperatureArray[11]);
            ColumnThreeData.Insert(2, TemperatureArray[12]);
            ColumnThreeData.Insert(3, TemperatureArray[13]);
            ColumnThreeData.Insert(4, TemperatureArray[14]);

            ColumnThreeData.Insert(5, FlowSVDataArray[2]);

            ColumnThreeData.Insert(6, FlowDataArray[4]);
            ColumnThreeData.Insert(7, FlowDataArray[5]);

            ColumnThreeData.Insert(8, ElectricalDataArray[12]);
            ColumnThreeData.Insert(9, ElectricalDataArray[13]);
            ColumnThreeData.Insert(10, ElectricalDataArray[14]);
            ColumnThreeData.Insert(11, ElectricalDataArray[15]);
            ColumnThreeData.Insert(12, ElectricalDataArray[16]);
            ColumnThreeData.Insert(13, ElectricalDataArray[17]);


            /* ColumnFourData */
            ColumnFourData.Insert(0, TemperatureArray[15]);
            ColumnFourData.Insert(1, TemperatureArray[16]);
            ColumnFourData.Insert(2, TemperatureArray[17]);
            ColumnFourData.Insert(3, TemperatureArray[18]);
            ColumnFourData.Insert(4, TemperatureArray[19]);

            ColumnFourData.Insert(5, FlowSVDataArray[3]);

            ColumnFourData.Insert(6, FlowDataArray[6]);
            ColumnFourData.Insert(7, FlowDataArray[7]);

            ColumnFourData.Insert(8, ElectricalDataArray[18]);
            ColumnFourData.Insert(9, ElectricalDataArray[19]);
            ColumnFourData.Insert(10, ElectricalDataArray[20]);
            ColumnFourData.Insert(11, ElectricalDataArray[21]);
            ColumnFourData.Insert(12, ElectricalDataArray[22]);
            ColumnFourData.Insert(13, ElectricalDataArray[23]);


            /* ColumnFiveData */
            ColumnFiveData.Insert(0, TemperatureArray[20]);
            ColumnFiveData.Insert(1, TemperatureArray[21]);
            ColumnFiveData.Insert(2, TemperatureArray[22]);
            ColumnFiveData.Insert(3, TemperatureArray[23]);
            ColumnFiveData.Insert(4, TemperatureArray[24]);

            ColumnFiveData.Insert(5, FlowSVDataArray[4]);

            ColumnFiveData.Insert(6, FlowDataArray[8]);
            ColumnFiveData.Insert(7, FlowDataArray[9]);

            ColumnFiveData.Insert(8, ElectricalDataArray[24]);
            ColumnFiveData.Insert(9, ElectricalDataArray[25]);
            ColumnFiveData.Insert(10, ElectricalDataArray[26]);
            ColumnFiveData.Insert(11, ElectricalDataArray[27]);
            ColumnFiveData.Insert(12, ElectricalDataArray[28]);
            ColumnFiveData.Insert(13, ElectricalDataArray[29]);


            /* ColumnSixData */
            ColumnSixData.Insert(0, TemperatureArray[25]);
            ColumnSixData.Insert(1, TemperatureArray[26]);
            ColumnSixData.Insert(2, TemperatureArray[27]);
            ColumnSixData.Insert(3, TemperatureArray[28]);
            ColumnSixData.Insert(4, TemperatureArray[29]);

            ColumnSixData.Insert(5, FlowSVDataArray[5]);

            ColumnSixData.Insert(6, FlowDataArray[10]);
            ColumnSixData.Insert(7, FlowDataArray[11]);

            ColumnSixData.Insert(8, ElectricalDataArray[30]);
            ColumnSixData.Insert(9, ElectricalDataArray[31]);
            ColumnSixData.Insert(10, ElectricalDataArray[32]);
            ColumnSixData.Insert(11, ElectricalDataArray[33]);
            ColumnSixData.Insert(12, ElectricalDataArray[34]);
            ColumnSixData.Insert(13, ElectricalDataArray[35]);

            /* MasterDataView */
            MasterDataView.Insert(0, Row01);
            MasterDataView.Insert(1, Row02);
            MasterDataView.Insert(2, Row03);
            MasterDataView.Insert(3, Row04);
            MasterDataView.Insert(4, Row05);
            MasterDataView.Insert(5, Row06);
            MasterDataView.Insert(6, Row06);
            MasterDataView.Insert(7, Row06);
            MasterDataView.Insert(8, Row06);
            MasterDataView.Insert(9, Row06);
            MasterDataView.Insert(10, Row06);
            MasterDataView.Insert(11, Row06);
            MasterDataView.Insert(12, Row06);
            MasterDataView.Insert(13, Row06);

            return MasterDataView;
        }
    }
}

