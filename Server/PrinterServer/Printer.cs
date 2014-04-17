using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterServer
{
    class Printer
    {
        private String name;
        private int state;
        private int speed;
        private Boolean running;
        private string ip;

        public Printer(int speed, String name, string ip, int state = 1, Boolean running = true)
        {
            this.name = name;
            this.state = state;
            this.speed = speed;
            this.running = running;
            this.ip = ip;
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
    }
}
