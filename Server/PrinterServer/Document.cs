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
        private float printingPercent;

        public Document(String name, String path)
        {
            this.name = name;
            this.path = path;
            this.informations = new FileInfo(path);
            this.pause = false;
            this.printingPercent = 0.0F;
        }


    }
}
