using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace PrinterServer
{
    class Printer
    {
        private String name;
        private int state;
        private int speed;
        private Boolean running;
        private string ip;

        private Thread documentQueueThread;
        private int bytesPrinted;
        private Document currentPrinting;
        private Queue<Document> documentQueue;

        public Printer(int speed, String name, string ip, int state = 1, Boolean running = true)
        {
            this.name = name;
            this.state = state;
            this.speed = speed;
            this.running = running;
            this.ip = ip;
            this.documentQueue = new Queue<Document>();
            this.currentPrinting = null;

            this.documentQueueThread = new Thread(queue);
            this.documentQueueThread.IsBackground = true;
            this.documentQueueThread.Start();
        }

        public String getName()
        {
            return this.name;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public int getState()
        {
            return this.state;
        }

        public string getStateInfo(int state)
        {
            if (state == 0) return "Hors ligne";
            if (state == 1) return "En ligne";
            return "En erreur";
        }

        public void setState(int state)
        {
            this.state = state;
        }

        public int getSpeed()
        {
            return this.speed;
        }

        public Boolean getRunning()
        {
            return this.running;
        }

        public void setRunning(Boolean running)
        {
            this.running = running;
        }

        public int getBytesPrinted()
        {
            return this.bytesPrinted;
        }

        public Document getCurrentPrinting()
        {
            return this.currentPrinting;
        }

        public Boolean print()
        {
            return false;
        }

        public string getIP()
        {
            return this.ip;
        }

        public void setIP(string ip)
        {
            this.ip = ip;
        }

        public void queue()
        {
            while(true)
            {
                if(this.documentQueue.Count() > 0)
                {
                    this.currentPrinting = this.documentQueue.Dequeue();

                    if(!this.printDoc())
                    {
                        MessageBox.Show("Erreur d'impression sur l'imprimante "+this.getName()+" ("+this.getIP()+")", "Erreur d'impression pour le document "+this.currentPrinting.getName());
                    }
                }

                System.Threading.Thread.Sleep(1000);
            }
        }

        private Boolean printDoc() 
        {
            this.bytesPrinted = 0;
            int remaining = this.currentPrinting.getSize();
            int ratio = 0;

            while (bytesPrinted < this.currentPrinting.getSize())
            {
                remaining = this.currentPrinting.getSize() - this.bytesPrinted;
                bytesPrinted += Math.Min(10000, remaining);
                ratio = (Math.Min(10000, remaining) / 10000);

                this.currentPrinting.setPrintingPercent(bytesPrinted / this.currentPrinting.getSize());

                System.Threading.Thread.Sleep(60 * 1000 / this.speed * ratio);
            }

            this.currentPrinting = null;
            this.bytesPrinted = 0;

            return true;
        }
    }
}
