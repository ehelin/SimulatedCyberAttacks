using System;
using System.Collections.Generic;

namespace SimulatedCyberAttacks.attacks.web
{
    public class WebAttack : Attack
    {
        protected string Url = string.Empty;
        protected int _testStepInterval = 1000;        
        protected IList<string> attackStrings = null;

        protected void LoadSqlInjectionPayload()
        {
            attackStrings = new List<string>();

            attackStrings.Add("1=1");
            attackStrings.Add("\"");
            attackStrings.Add("\"=\"");
            attackStrings.Add(Convert.ToString((char) 8));
            attackStrings.Add(Convert.ToString((char) 0));
            attackStrings.Add(Convert.ToString((char) 13));
            attackStrings.Add(Convert.ToString((char) 9));
            attackStrings.Add(Convert.ToString((char) 26));
            attackStrings.Add(Convert.ToString((char) 92 + (char)8));
            attackStrings.Add(Convert.ToString((char) 92 + (char)0));
            attackStrings.Add(Convert.ToString((char) 92 + (char)13));
            attackStrings.Add(Convert.ToString((char) 92 + (char)9));
            attackStrings.Add(Convert.ToString((char) 92 + (char)26));
            attackStrings.Add("0");
            attackStrings.Add("b");
            attackStrings.Add("t");
            attackStrings.Add("n");
            attackStrings.Add("r");
            attackStrings.Add("Z");
            attackStrings.Add("\"");
            attackStrings.Add("%");
            attackStrings.Add("'");
            attackStrings.Add("\\");
            attackStrings.Add("_");
            attackStrings.Add("\b");
            attackStrings.Add("\0");
            attackStrings.Add("\n");
            attackStrings.Add("\r");
            attackStrings.Add("\t"); 
            attackStrings.Add("\\Z");
            attackStrings.Add("''");
            attackStrings.Add("\"\"");
            attackStrings.Add("\"=\"");
            attackStrings.Add("105");
            attackStrings.Add("1=1");
            attackStrings.Add(";");
            attackStrings.Add("--");
            attackStrings.Add("/*");
            attackStrings.Add("*/");
            attackStrings.Add("xp_");
            attackStrings.Add("[");
            attackStrings.Add("%");
            attackStrings.Add("_");
        }
    }
}
