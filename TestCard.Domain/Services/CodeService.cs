using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCard.Domain.Services
{
    public class CodeService : DomainServiceBase<Code>
    {
        public CodeService() { }

        public CodeService(TestCardContext context)
            : base(context) { }

        public string NextCode(CodeTypes type)
        {
            var typeID = (int)type;

            var code = _DbContext.Codes.FirstOrDefault(x => x.CodeTypeID == typeID);

            var current = string.Format("{0}{1}{2}", code.Prefix, (code.Seed + code.Count * code.IncrementStep).ToString().PadLeft(code.Length, '0'), code.Suffix);

            code.Count++;

            Update(code);

            return current;
        }
    }
}
