using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MayniladSubmeterTracker
{
    internal class Submeter
    {
        //fields
        private int month;
        private int year;
        private double waterUsage;
        private double costPerCubic;
        private double amtDue;

        public Submeter() 
        {
            month = 1;
            year = 2024;
            waterUsage = 0;
            costPerCubic = 0;
            amtDue = 0;
        }

        public Submeter(int month, int year, double waterUsage, double cost, double amtDue)
        {
            this.month = month;
            this.year = year;
            this.waterUsage = waterUsage;
            this.costPerCubic = cost;
            this.amtDue = amtDue;
        }

        public int Month
        {
            get { return month; }
            set { month = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public double WaterUsage
        { 
            get { return waterUsage; } 
            set {  waterUsage = value; } 
        }       
        
        public double CostPerCubic
        { 
            get { return costPerCubic; } 
            set { costPerCubic = value; } 
        }

        public double Amount
        { 
            get { return amtDue; } 
            set {  amtDue = value; } 
        }
    }
}
