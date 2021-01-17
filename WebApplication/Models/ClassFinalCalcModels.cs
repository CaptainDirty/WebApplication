using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class ClassFinalCalcModels
    {
        const double WB1 = 10;
        const double WB2 = 0.5;
        const double t2 = 400;
        const double cm = 0.84;
        const double tm1 = 100;
        const double cvl = 4.19;
        const double ip100 = 2675;
        const double Gm = 1.75;
        const double cp = 2.09;
        const double i_v = 26;
        public ClassOutputModels FinalResult(ClassInputModels ci, ClassMidCalcPut mc)
        {
            ClassKoeffModels ck = new ClassKoeffModels();
            ClassOutputModels co = new ClassOutputModels();
            co.WC1 = WB1 / (1 - (0.01 * WB1));
            co.WC2 = WB2 / (1 - (0.01 * WB2));
            co.tm2 = t2 - 150;
            co.inach_pv = tm1 * cvl;
            co.i1 = tm1 * ck.AGasCOCKS(40) + ck.BGasCOCKS(40);
            co.i2 = tm1 * ck.AGasCOCKS(20) + ck.BGasCOCKS(20);
            co.i3 = t2 * ck.AGasCOCKS(20) + ck.BGasCOCKS(20);
            co.i4 = ci.KPD * mc.iobshb;
            co.M = (co.i4 - co.i3) / (co.i3 - i_v);
            co.S = Math.PI * ci.L * ci.D;
            co.tsr = 0.5 * (t2 + tm1);
            co.tmsr = 0.5 * (tm1 + co.tm2);
            co.tsrsr = 0.5 * (co.tsr + co.tmsr);
            co.TtoV = 8 * 0.06 * co.tsrsr;
            co.Q1 = (cm + 0.01 * co.WC2 * cvl) * (co.tm2 - tm1) + 0.01 * (co.WC1 - co.WC2) * (ip100 - cvl * tm1 + cp * (t2 - 100)) * (ci.ParPr*0.27);
            co._q1 = co.Q1;
            co._q2 = (co.i1 + co.M * (co.inach_pv - i_v)) * mc.Valfa;
            co._q3 = 0.02 * mc.Qniz;
            co._q4 = (1 - ci.KPD) * mc.Qniz;
            co._q5 = 0.001 * co.TtoV * (co.tsrsr - 2) * co.S;
            co.RashodQ = (co._q1 + co._q5) / (mc.Qniz + mc.Qnizfiztopl + mc.Qnizfizvosd - co._q2 - co._q3 - co._q4);
            co.Q_x = mc.Qniz * co.RashodQ;
            co.Q_fiztopl = mc.Qnizfiztopl * co.RashodQ;
            co.Q_fizvozd = mc.Qnizfizvosd * co.RashodQ;
            co.Q2 = co._q2 * co.RashodQ;
            co.Q3 = co._q3 * co.RashodQ;
            co.Q5_top = co._q4 * co.RashodQ;
            co.Q5_rp = 0.001 * co.TtoV * (co.tsrsr - 20) * co.S;
            co.KPD_agr = (co._q1 / (co.RashodQ * mc.Qniz))*100;
            return co;
        }
    }
}
