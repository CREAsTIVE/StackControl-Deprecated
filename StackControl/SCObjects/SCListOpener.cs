using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackControl.SCObjects
{
    internal class SCListOpener : SCObject
    {
        public override string StackView() => "[";
	}
    public class SCListOpenGeneratorCloser : SCObject
    {
        public override string StackView() => "⟧";
	}
}
