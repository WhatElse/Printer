using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PrinterServer
{
    public class Document
    {
        private String name;
        private String path;
        private int size;
        private FileInfo informations;
        private int numberPage;
        private float printingPercent;
        private int quantity;
        private Boolean pause;

        public Document(String name, String path, int size)
        {
            this.name = name;
            this.path = path;
            this.informations = new FileInfo(path);
            this.printingPercent = 0.0F;
            this.size = size;
            this.numberPage = (size / 100000) + 1;
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

        public int getSize()
        {
            return this.size;
        }

        public void setSize(int size)
        {
            this.size = size;
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
