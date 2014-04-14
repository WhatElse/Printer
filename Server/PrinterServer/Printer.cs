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
        private String state;
        private int speed;
        private Boolean running;

        public Printer(String name = "Noname", String state = "En ligne", int speed = 1, Boolean visible = true)
        {
            this.name = name;
            this.state = state;
            this.speed = speed;
            this.running = true;
        }

        public String getName()
        {
            return this.name;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public String getState()
        {
            return this.state;
        }

        public void setState(String state)
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
    }
}
