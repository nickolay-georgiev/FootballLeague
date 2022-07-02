using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Abstraction.CQS.Result
{
    public interface IResult
    {
        bool Succeed { get; }
    }
    public class FailedResult : IResult
    {
        public bool Succeed => false;
    }
}
