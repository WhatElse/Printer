using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PrinterServer
{
    class Document
    {
        private String name;
        private String path;
        private FileInfo informations;
        private Boolean pause;
        private int numberPage;
        private float printingPercent;
        private int quantity;

        public Document(String name, String path, int numberPage)
        {
            this.name = name;
            this.path = path;
            this.informations = new FileInfo(path);
            this.pause = false;
            this.printingPercent = 0.0F;
            this.numberPage = numberPage;
            this.quantity = 1;
        }

        public string getName()
        {
            return this.name;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public string getPath()
        {
            return this.path;
        }

        public void setPath(string path)
        {
            this.path = path;
        }

        public FileInfo getInformations()
        {
            return this.informations;
        }

        public void setInformations(FileInfo informations)
        {
            this.informations = informations;
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
