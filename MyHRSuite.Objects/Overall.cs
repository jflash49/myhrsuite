using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHRSuite.Objects
{
    public class Overall
    {
        public int HrCore { get; set; }
        public int FuncSit { get; set; }
        public int Posts { get; set; }
        public int YearsofService { get; set; }
        public int Benefits { get; set; }
        public int Leave { get; set; }
        public int Entitlements { get; set; }
        public int MedicalInfo { get; set; }
        public int MedicalAdd { get; set; }
        public int Beneficiaries { get; set; }
        public int Awards { get; set; }
        public int DisciplinaryAction { get; set; }
        public int Unions { get; set; }
        public int Attachments { get; set; }

        public int Allowances { get; set; }
        public int Deductions { get; set; }
        public int BankAccounts { get; set; }

        public virtual HRCore HRCore { get; set; }

    }

}
