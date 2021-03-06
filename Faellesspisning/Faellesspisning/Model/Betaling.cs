﻿using System;
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
            DagligtUdlaegMandag = Singleton.GetInstance().DenneTempUge.mandag.Udlæg;
            DagligtUdlaegTirsdag = Singleton.GetInstance().DenneTempUge.tirsdag.Udlæg;
            DagligtUdlaegOnsdag = Singleton.GetInstance().DenneTempUge.onsdag.Udlæg;
            DagligtUdlaegTorsdag = Singleton.GetInstance().DenneTempUge.torsdag.Udlæg;
        }
        public double UgentligUdlæg()
        {
            return DagligtUdlaegMandag + DagligtUdlaegTirsdag + DagligtUdlaegOnsdag + DagligtUdlaegTorsdag;
        }
        public double KuvertPris()
        {
            return UgentligUdlæg() / DeltagereIAlt();
        }
        public double DeltagereValgtHus(int i)
        {
            Bolig TempBolig = Singleton.GetInstance().DenneTempUge.BoligListe[i];

            double Mandag = TempBolig.DaglistMan[0] + TempBolig.DaglistMan[1] * 0.5 + TempBolig.DaglistMan[2] * 0.25;
            double Tirsdag = TempBolig.DaglistTir[0]+ TempBolig.DaglistTir[1] *0.5+ TempBolig.DaglistTir[2]*0.25;
            double Onsdag = TempBolig.DaglistOns[0] + TempBolig.DaglistOns[1] * 0.5 + TempBolig.DaglistOns[2] * 0.25;
            double Torsdag = TempBolig.DaglistTor[0] + TempBolig.DaglistTor[1] * 0.5 + TempBolig.DaglistTor[2] * 0.25;
            return Mandag+Tirsdag+Onsdag+Torsdag;
        }
        public double DeltagereIAlt()
        {
            double Result = 0;
            foreach (KeyValuePair<int, Bolig> hus in Singleton.GetInstance().DenneTempUge.BoligListe)
            {
                Result += DeltagereValgtHus(hus.Key);
            }
            return Result;
        }
        public string HusBetaling(int j)
        {
            string result;
            if (KuvertPris()<=0||DeltagereValgtHus(j)<=0)
            {
                result = $"Ikke nok værdier til beregning";
                return result;
            }
            result = $"{KuvertPris() * DeltagereValgtHus(j)}";
            return result;
        }
        public double DeltagereMandag()
        {
            double Result = 0;
            foreach (KeyValuePair<int, Bolig> hus in Singleton.GetInstance().DenneTempUge.BoligListe)
            {
                Bolig TempBolig = Singleton.GetInstance().DenneTempUge.BoligListe[hus.Key];


                Result = TempBolig.DaglistMan[0] + TempBolig.DaglistMan[1]*0.5 + TempBolig.DaglistMan[2]*0.25;
            }
            return Result;
        }
        public double DeltagereTirsdag()
        {
            double Result = 0;
            foreach (KeyValuePair<int, Bolig> hus in Singleton.GetInstance().DenneTempUge.BoligListe)
            {
                Bolig TempBolig = Singleton.GetInstance().DenneTempUge.BoligListe[hus.Key];


                Result = TempBolig.DaglistTir[0] + TempBolig.DaglistTir[1] * 0.5 + TempBolig.DaglistTir[2] * 0.25;
            }
            return Result;
        }
        public double DeltagereOnsdag()
        {
            double Result = 0;
            foreach (KeyValuePair<int, Bolig> hus in Singleton.GetInstance().DenneTempUge.BoligListe)
            {
                Bolig TempBolig = Singleton.GetInstance().DenneTempUge.BoligListe[hus.Key];


                Result = TempBolig.DaglistOns[0] + TempBolig.DaglistOns[1] * 0.5 + TempBolig.DaglistOns[2] * 0.25;
            }
            return Result;
        }
        public double DeltagereTorsdag()
        {
            double Result = 0;
            foreach (KeyValuePair<int, Bolig> hus in Singleton.GetInstance().DenneTempUge.BoligListe)
            {
                Bolig TempBolig = Singleton.GetInstance().DenneTempUge.BoligListe[hus.Key];


                Result = TempBolig.DaglistTor[0] + TempBolig.DaglistTor[1] * 0.5 + TempBolig.DaglistTor[2] * 0.25;
            }
            return Result;
        }
    }
}