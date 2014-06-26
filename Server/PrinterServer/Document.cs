using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace PrinterServer
{
    public class Document
    {
        private String name;
        private int weight;
        private int numberPage;
        private float printingPercent;
        private int quantity;
        private Boolean pause;

        public Document(String name, int weight)
        {
            this.name = name;
            this.weight = weight;
            this.printingPercent = 0.0F;
            this.numberPage = weight / 10 + 1;
            this.quantity = 1;
            this.pause = false;
        }

        public string getName()
        {
            return this.name;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public int getWeight()
        {
            return this.weight * 2000;
        }

        public void setWeight(int weight)
        {
            this.weight = weight;
        }

        public int getNumberPage()
        {
            return this.numberPage;
        }

        public void setNumberPage(int numberPage)
        {
            this.numberPage = numberPage;
        }

        public float getPrintingPercent()
        {
            System.Console.WriteLine("percent");
            return this.printingPercent;
        }

        public void setPrintingPercent(float printingPercent)
        {
            this.printingPercent = printingPercent;
        }

        public bool getPause()
        {
            return this.pause;
        }

        public void setPause(bool pause)
        {
            this.pause = pause;
        }
        public int getQuantity()
        {
            return this.quantity;
        }

        public void setQuantity(int quantity)
        {
            this.quantity = quantity;
        }
    }
}
