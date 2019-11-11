using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioConciliacao.Application.Interface
{
    public interface IParseOFXContent
    {
        T ToObject<T>(string[] lines);
    }
}
