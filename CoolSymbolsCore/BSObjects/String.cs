using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulSymbols.BSObjects
{
    public class String : BSObject
    {
        public String(string value) => this.Value = value;
        public string Value;

        public override string StackView() => $"\"{Value}\"";

        public override BSObject Clone() => new String(Value);
    }
}
