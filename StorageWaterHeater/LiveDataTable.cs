using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageWaterHeater
{
    public class RowItems
    {
        
        public string RowName { get; set; }
        public double Column1Value{ get; set; }
        public double Column2Value{ get; set; }        
        public double Column3Value{ get; set; }        
        public double Column4Value{ get; set; }        
        public double Column5Value{ get; set; }        
        public double Column6Value { get; set; }
    }

    public class Tabulator
    {
        public List<RowItems> rowItems = new List<RowItems>();
        
        public Tabulator()
        {
            rowItems.Add(new RowItems() { RowName="Row1", Column1Value = 12.34, Column2Value = 56.78, Column3Value = 90.12, Column4Value = 34.56, Column5Value = 78.90, Column6Value = 12.34});
            rowItems.Add(new RowItems() { RowName="Row1", Column1Value = 12.34, Column2Value = 56.78, Column3Value = 90.12, Column4Value = 34.56, Column5Value = 78.90, Column6Value = 12.34});
            rowItems.Add(new RowItems() { RowName="Row1", Column1Value = 12.34, Column2Value = 56.78, Column3Value = 90.12, Column4Value = 34.56, Column5Value = 78.90, Column6Value = 12.34});
            rowItems.Add(new RowItems() { RowName="Row1", Column1Value = 12.34, Column2Value = 56.78, Column3Value = 90.12, Column4Value = 34.56, Column5Value = 78.90, Column6Value = 12.34});
            rowItems.Add(new RowItems() { RowName="Row1", Column1Value = 12.34, Column2Value = 56.78, Column3Value = 90.12, Column4Value = 34.56, Column5Value = 78.90, Column6Value = 12.34});
            rowItems.Add(new RowItems() { RowName="Row1", Column1Value = 12.34, Column2Value = 56.78, Column3Value = 90.12, Column4Value = 34.56, Column5Value = 78.90, Column6Value = 12.34});
            rowItems.Add(new RowItems() { RowName="Row1", Column1Value = 12.34, Column2Value = 56.78, Column3Value = 90.12, Column4Value = 34.56, Column5Value = 78.90, Column6Value = 12.34});
            rowItems.Add(new RowItems() { RowName="Row1", Column1Value = 12.34, Column2Value = 56.78, Column3Value = 90.12, Column4Value = 34.56, Column5Value = 78.90, Column6Value = 12.34});
            rowItems.Add(new RowItems() { RowName="Row1", Column1Value = 12.34, Column2Value = 56.78, Column3Value = 90.12, Column4Value = 34.56, Column5Value = 78.90, Column6Value = 12.34});
            rowItems.Add(new RowItems() { RowName="Row1", Column1Value = 12.34, Column2Value = 56.78, Column3Value = 90.12, Column4Value = 34.56, Column5Value = 78.90, Column6Value = 12.34});
            rowItems.Add(new RowItems() { RowName="Row1", Column1Value = 12.34, Column2Value = 56.78, Column3Value = 90.12, Column4Value = 34.56, Column5Value = 78.90, Column6Value = 12.34});
            rowItems.Add(new RowItems() { RowName="Row1", Column1Value = 12.34, Column2Value = 56.78, Column3Value = 90.12, Column4Value = 34.56, Column5Value = 78.90, Column6Value = 12.34});
            rowItems.Add(new RowItems() { RowName="Row1", Column1Value = 12.34, Column2Value = 56.78, Column3Value = 90.12, Column4Value = 34.56, Column5Value = 78.90, Column6Value = 12.34});
            rowItems.Add(new RowItems() { RowName="Row1", Column1Value = 12.34, Column2Value = 56.78, Column3Value = 90.12, Column4Value = 34.56, Column5Value = 78.90, Column6Value = 12.34});
        }



    }

    public class LiveDataTable
    {
        
    }
}
