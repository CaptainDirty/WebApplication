using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class ClassMidCalcModels
    {
        public ClassMidCalcPut GasCalc(ClassInputModels ci)
        {
            ClassMidCalcPut mc = new ClassMidCalcPut();
            mc.perH2O = (0.1244 * ci.Vlagosod) / (1 + 0.00124 * ci.Vlagosod);
            mc.perCH4 = (ci.CH4 * ((100 - mc.perH2O))) / 100;
            mc.perC2H6 = (ci.C2H6 * ((100 - mc.perH2O))) / 100;
            mc.perC3H8 = (ci.C3H8 * ((100 - mc.perH2O))) / 100;
            mc.perC4H10 = (ci.C4H10 * ((100 - mc.perH2O))) / 100;
            mc.perC5H12 = (ci.C5H12 * ((100 - mc.perH2O))) / 100;
            mc.perN2 = (ci.N2 * ((100 - mc.perH2O))) / 100;
            mc.perCO2 = (ci.CO2 * ((100 - mc.perH2O))) / 100;
            mc.Qniz = (358 * ci.CH4) + (590 * ci.C2H6) + (913 * ci.C3H8) + (1185 * ci.C4H10) + (1465 * ci.C5H12);
            mc.HimNedogeg = (ci.himnedog / 100) * mc.Qniz;
            mc.VO2 = 0.01 * ((2 * ci.CH4) + (3 * ci.C2H6) + (5 * ci.C3H8) + (6.5 * ci.C4H10) + (8 * ci.C5H12));
            mc.LO = (1 + 3.762) * mc.VO2;
            mc.Lalfa = mc.LO * ci.alfa;
            mc.LBO = (1 + 0.001244 * ci.Vlagosod) * mc.LO;
            mc.VCO2o = 0.01 * (mc.perCO2 + mc.perCH4);
            mc.VoRO2 = 0.01 * ((mc.perCH4 + (2 * mc.perC2H6) + (3 * mc.perC3H8) + (4 * mc.perC4H10) + (5 * mc.perC5H12)));
            mc.VoH2O = 0.01 * ((mc.perH2O + (2 * mc.perCH4) + (3 * mc.perC2H6) + (4 * mc.perC3H8) + (5 * mc.perC4H10) + (6 * mc.perC5H12)));
            mc.VoN2 = (0.01 * mc.perN2) + (3.76 * mc.VO2);
            mc.V0 = mc.VCO2o + mc.VoRO2 + mc.VoH2O + mc.VoN2;
            mc.ValfaH2O = mc.VoH2O + (ci.alfa - 1) * 0.001244 * ci.Vlagosod * mc.LO;
            mc.ValfaN2 = mc.VoN2 + (ci.alfa - 1) * 3.76 * mc.VO2;
            mc.VO2izb = (ci.alfa - 1) * mc.VO2;
            mc.Valfa = mc.VCO2o + mc.ValfaH2O + mc.ValfaN2 + mc.VO2izb;
            mc.VL = ((mc.Lalfa - mc.LO) / mc.Valfa) * 100;
            if (ci.alfa == 1)
            {
                mc.RO2 = (mc.VoRO2 / mc.V0) * 100;
                mc.H2O = (mc.VoH2O / mc.V0) * 100;
                mc.N2 = (mc.VoN2 / mc.V0) * 100;
                mc.Qizb = 0;
            }
            else
            {
                mc.RO2 = (mc.VoRO2 / mc.Valfa) * 100;
                mc.H2O = (mc.VoH2O / mc.Valfa) * 100;
                mc.N2 = (mc.VoN2 / mc.Valfa) * 100;
                mc.Qizb = (mc.VO2izb / mc.Valfa) * 100;
            }
            mc.Ctopl = 0.01 * (mc.perN2 * (0.0001 * ci.Tpodgas + 1.2796) + mc.perCO2 * (0.0005 * ci.Tpodgas + 1.6876) + mc.perH2O * (0.0002 * ci.Tpodgas + 1.4756) + mc.perCH4 * (0.0011 * ci.Tpodgas + 1.5699) + mc.perC2H6 * (0.0022 * ci.Tpodgas + 2.36) + mc.perC3H8 * (0.0032 * ci.Tpodgas + 3.3462) + mc.perC4H10 * (0.004 * ci.Tpodgas + 4.4928) + mc.perC5H12 * (0.0048 * ci.Tpodgas + 5.5781));
            mc.Cb = 0.0001 * (ci.CH4 + ci.C2H6 + ci.C3H8 + ci.C4H10 + ci.C5H12 + ci.N2 + ci.CO2) + 1.285;
            mc.Qnizfiztopl = mc.Ctopl * ci.Tpodgas;
            mc.Qnizfizvosd = mc.Cb * ci.Tpodvosd * mc.Lalfa;
            if (ci.alfa == 1)
            {
                mc.ihim = mc.Qniz / mc.V0;
                mc.itopl = (mc.Ctopl * ci.Tpodgas) / mc.V0;
                mc.ivoz = (mc.Cb * ci.Tpodvosd * mc.LO) / mc.V0;
                mc.iobsht = mc.ihim + mc.itopl + mc.ivoz;
                mc.ihimnedog = ((ci.himnedog / 100) * mc.Qniz) / mc.V0;
                mc.iobshb = mc.iobsht - mc.ihimnedog;
            }
            else
            {
                mc.ihim = mc.Qniz / mc.Valfa;
                mc.itopl = (mc.Ctopl * ci.Tpodgas) / mc.Valfa;
                mc.ivoz = (mc.Cb * ci.Tpodvosd * mc.LO) / mc.Valfa;
                mc.iobsht = mc.ihim + mc.itopl + mc.ivoz;
                mc.ihimnedog = ((ci.himnedog / 100) * mc.Qniz) / mc.Valfa;
                mc.iobshb = mc.iobsht - mc.ihimnedog;
            }
            return mc;
        }
    }
}
