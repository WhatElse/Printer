using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace PrinterServer
{
    public class Printer
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
            int remaining = this.currentPrinting.getWeight();
            float ratio = 0;

            //MessageBox.Show(this.currentPrinting.getName()+" débute son impression");

            while (bytesPrinted < this.currentPrinting.getWeight())
            {
                remaining = this.currentPrinting.getWeight() - this.bytesPrinted;
                bytesPrinted += Math.Min(10000, remaining);
                // MessageBox.Show("Taille : "+this.currentPrinting.getWeight()+" || Bytes printed : "+bytesPrinted);
                ratio = (Math.Min(10000, remaining) / 10000);

                this.currentPrinting.setPrintingPercent((float) ((float)bytesPrinted / (float) this.currentPrinting.getWeight()));
                if(MainWindow.avancement.ContainsKey(this.currentPrinting.getName()))
                {
                    MainWindow.avancement.Remove(this.currentPrinting.getName());
                }
                MainWindow.avancement.Add(this.currentPrinting.getName(), ((float) ((float)bytesPrinted / (float) this.currentPrinting.getWeight())));

                Thread.Sleep((int) (60 * 1000 / this.speed * ratio));
                //MessageBox.Show(this.currentPrinting.getName() + " : " + (int)((float)bytesPrinted / (float) this.currentPrinting.getWeight() * 100.0) + "%");

            }

            //MessageBox.Show(this.currentPrinting.getName()+" a fini son impression");

            this.currentPrinting = null;
            this.bytesPrinted = 0;

            return true;
        }

        public int getEstimatedEndTime()
        {
            int secondsRemaining = 0;

            if (currentPrinting == null)
                return 0;

            // Current printing doc
            int remaining = this.currentPrinting.getWeight() - this.bytesPrinted;
            float ratio = (Math.Min(10000, remaining) / 10000);

            secondsRemaining += (int) (60 / this.speed * ratio);

            foreach(Document doc in this.documentQueue.ToArray())
            {
                ratio = doc.getWeight() / 10000;

                secondsRemaining += (int) (60 / this.speed * ratio);
            }

            return secondsRemaining;
        }

        public void addDocument(Document doc)
        {
            this.documentQueue.Enqueue(doc);
        }
    }
}
