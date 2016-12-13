using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faellesspisning
{
    class Betaling
    {
        public Double DagligtUdlaegMandag { get; set; }
        public Double DagligtUdlaegTirsdag { get; set; }
        public Double DagligtUdlaegOnsdag { get; set; }
        public Double DagligtUdlaegTorsdag { get; set; }

        public Betaling()
        {
            DagligtUdlaegMandag = 0;
            DagligtUdlaegTirsdag = 0;
            DagligtUdlaegOnsdag =0;
            DagligtUdlaegTorsdag = 1;
        }

        public double UgentligUdlæg()
        {
            return DagligtUdlaegMandag + DagligtUdlaegTirsdag + DagligtUdlaegOnsdag + DagligtUdlaegTorsdag;
        }

        public double KuvertPris()
        {
            return UgentligUdlæg()/ DeltagereIAlt() ;
        }
        public double DeltagerePerHus()
        {
            return 2;
        }

        public double DeltagereIAlt()
        {
            return 5;
        }

        public double HusBetaling()
        {
            return 10;
        }

    }
}
